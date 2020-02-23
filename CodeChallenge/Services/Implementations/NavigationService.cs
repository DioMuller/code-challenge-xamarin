// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NavigationService.cs" company="ArcTouch LLC">
//   Copyright 2020 ArcTouch LLC.
//   All rights reserved.
//
//   This file, its contents, concepts, methods, behavior, and operation
//   (collectively the "Software") are protected by trade secret, patent,
//   and copyright laws. The use of the Software is governed by a license
//   agreement. Disclosure of the Software to third parties, in any form,
//   in whole or in part, is expressly prohibited except as authorized by
//   the license agreement.
// </copyright>
// <summary>
//   Defines the NavigationService type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

using CodeChallenge.Services.Interfaces;
using CodeChallenge.Utils;
using CodeChallenge.ViewModels;
using CodeChallenge.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CodeChallenge.Services.Implementations
{
    public class NavigationService : INavigationService
    {
        #region Attributes
        private static readonly Dictionary<Type, Type> _mappings = new Dictionary<Type, Type>();
        #endregion

        #region Static Methods
        public static void RegisterMap<TViewModel, TPage>() where TViewModel : BaseViewModel where TPage : Page
        {
            if (!_mappings.ContainsKey(typeof(TViewModel)))
            {
                _mappings.Add(typeof(TViewModel), typeof(TPage));
                IoCContainer.Instance.Register<TViewModel>();
            }
        }
        #endregion

        #region INavigationService Methods
        public async Task NavigateToAsync<TViewModel>(object parameter = null) where TViewModel : BaseViewModel
        {
            // Create page and bind it, then initialize ViewModel.
            // In the case the page doesn't exist, an exception will be thrown by CreateAndBindPage.
            var page = CreateAndBindPage<TViewModel>();
            await (page.BindingContext as BaseViewModel).Initialize(parameter);

            // Setup Navigation Page.
            var navigationPage = Application.Current.MainPage as NavigationPage;

            if (navigationPage == null)
            {
                var navigation = new NavigationPage(page);
                Application.Current.MainPage = navigation;
                NavigationPage.SetHasNavigationBar(navigation, false);
            }
            else
            {
                await navigationPage.PushAsync(page, true);
            }
        }

        public async Task NavigateBackAsync()
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            await navigationPage?.PopAsync();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Creates a Page and binds it with it's linked ViewModel.
        /// </summary>
        /// <param name="viewModelType">View Model Type.</param>
        /// <returns></returns>
        private Page CreateAndBindPage<TViewModel>() where TViewModel : BaseViewModel
        {
            // Find Page and Instantiate it.
            var viewModelType = typeof(TViewModel);
            var pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"There is no mapping for {viewModelType} on the Navigation Service.");
            }

            var page = Activator.CreateInstance(pageType) as Page;
            var viewModel = IoCContainer.Instance.Resolve<TViewModel>() as BaseViewModel;

            // Set Context and Sign events.
            page.BindingContext = viewModel;

            page.Appearing += async (sender, e) => await viewModel.OnAppearing();
            page.Disappearing += async (sender, e) => await viewModel.OnDisappearing();

            return page;
        }

        /// <summary>
        /// Gets the page type linked to a View Model.
        /// </summary>
        /// <param name="viewModelType">View Model Type.</param>
        /// <returns>Page Type.</returns>
        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (_mappings.ContainsKey(viewModelType))
                return _mappings[viewModelType];

            return null;
        }
        #endregion
    }
}
