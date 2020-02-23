// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomePageViewModel.cs" company="ArcTouch LLC">
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
//   Defines the HomeViewModel type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CodeChallenge.Models;
using CodeChallenge.Models.Data;
using CodeChallenge.Services.Interfaces;
using CodeChallenge.ViewModels.Base;
using CodeChallenge.ViewModels.Cells;
using Xamarin.Forms;

namespace CodeChallenge.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region Attributes
        private readonly IMovieService _movieService;
        private readonly INavigationService _navigationService;
        private int _currentPage = 1;
        #endregion

        #region Bindable Properties

        #region Movies
        private ObservableCollection<MovieItemViewModel> _movies;
        public ObservableCollection<MovieItemViewModel> Movies
        {
            get => _movies;
            set => SetProperty(ref _movies, value);
        }
        #endregion

        #region ItemsThreshold
        private int _itemsThreshold;

        public int ItemsThreshold
        {
            get => _itemsThreshold;
            set => SetProperty(ref _itemsThreshold, value);
        }
        #endregion

        #endregion

        #region Commands
        public Command LoadMoreCommand { get; }
        public Command<MovieItemViewModel> SelectMovieCommand { get; }
        #endregion

        #region Constructors
        public HomeViewModel(IMovieService movieService, INavigationService navigationService)
        {
            _movieService = movieService;
            _navigationService = navigationService;

            _movies = new ObservableCollection<MovieItemViewModel>();

            LoadMoreCommand = new Command(async () => await ExecuteLoadMoreCommand());
            SelectMovieCommand = new Command<MovieItemViewModel>(async (movie) => await ExecuteSelectMovieCommand(movie));
        }
        #endregion

        #region BaseViewModel Methods
        public override async Task OnAppearing()
        {
            IsBusy = true;

            _currentPage = 1;
            Movies.Clear();

            await UpdateMovies();
        }
        #endregion

        #region Private Methods
        private async Task UpdateMovies()
        {
            var upcomingMoviesResponse = await _movieService.UpcomingMovies(_currentPage);
            foreach (var movie in upcomingMoviesResponse.Results)
            {
                Movies.Add(ToMovieItemViewModel(movie));
            }
            IsBusy = false;
        }

        private MovieItemViewModel ToMovieItemViewModel(Movie result) => new MovieItemViewModel(result);
        #endregion Private Methods

        #region Command Methods
        private async Task ExecuteLoadMoreCommand()
        {
            // Do not load more if another operation is taking place.
            if (IsBusy) return;

            IsBusy = true;
            _currentPage++;

            UpdateMovies();
        }

        private async Task ExecuteSelectMovieCommand(MovieItemViewModel movie)
        {
            if (movie == null) return;

            await _navigationService.NavigateToAsync<DetailsViewModel>(movie.Id);
        }
        #endregion
    }
}
