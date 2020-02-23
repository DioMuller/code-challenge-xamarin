// --------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="ArcTouch LLC">
//   Copyright 2019 ArcTouch LLC.
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
//   Defines the App type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using CodeChallenge.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CodeChallenge.Utils;
using CodeChallenge.Services.Interfaces;
using CodeChallenge.Services.Implementations;
using CodeChallenge.ViewModels;
using CodeChallenge.Models.Response.Data;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CodeChallenge
{
    public partial class App : Application
    {
        public static List<Genre> Genres { get; private set; }

        public App()
        {
            InitializeComponent();

            MainPage = new HomePage();
        }

        protected override async void OnStart()
        {
            InitializeServices();
            InitializeViewModels();
            InitializeContainer();

            // TODO: Find a better way to do this.
            var genreResponse = await IoCContainer.Instance.Resolve<IMovieService>().GetGenres();
            Genres = genreResponse.Genres;

            InitializeView();
        }

        #region Private Methods
        /// <summary>
        /// Register Services.
        /// </summary>
        private void InitializeServices()
        {
            // Singleton Services
            IoCContainer.Instance.RegisterSingleton<INavigationService, NavigationService>();
            IoCContainer.Instance.RegisterSingleton<IMovieService, MovieService>();
        }

        /// <summary>
        /// Register View/View Model mappings. 
        /// 
        /// This is done in an explicit form, instead of by using Reflection, so it becomes clearer to the 
        /// developer which Views are linked to which models. (As in, less "magic", but can be less confusing).
        /// </summary>
        private void InitializeViewModels()
        {
            NavigationService.RegisterMap<HomeViewModel, HomePage>();
            NavigationService.RegisterMap<DetailsViewModel, DetailsPage>();
        }

        private void InitializeContainer()
        {
            // Rebuild container with services.
            IoCContainer.Instance.Build();
        }

        /// <summary>
        /// Initialize View and navigates to initial page.
        /// </summary>
        private void InitializeView()
        {
            var navigationService = IoCContainer.Instance.Resolve<INavigationService>();

            // Create Main Page.
            navigationService.NavigateToAsync<HomeViewModel>();
        }
        #endregion
    }
}