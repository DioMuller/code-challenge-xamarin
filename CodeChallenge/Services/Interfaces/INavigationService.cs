// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INavigationService.cs" company="ArcTouch LLC">
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
//   Defines the INavigationService type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

using CodeChallenge.ViewModels;
using CodeChallenge.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CodeChallenge.Services.Interfaces
{
    public interface INavigationService
    {
        Task NavigateToAsync<TViewModel>(object parameter = null) where TViewModel : BaseViewModel;
        Task NavigateBackAsync();
    }
}
