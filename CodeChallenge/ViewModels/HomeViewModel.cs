﻿// --------------------------------------------------------------------------------------------------------------------
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

using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Models;
using CodeChallenge.Services.API;
using CodeChallenge.Services.Interfaces;
using CodeChallenge.Utils;
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
        private readonly IDialogService _dialogService;
        private int _currentPage = 1;
        private string _lastSearch = null;
        #endregion

        #region Bindable Properties

        #region Movies
        private RangeObservableCollection<MovieItemViewModel> _movies;
        public RangeObservableCollection<MovieItemViewModel> Movies
        {
            get => _movies;
            set => SetProperty(ref _movies, value);
        }
        #endregion

        #region SearchText
        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
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
        public Command SearchCommand { get; }
        public Command RefreshCommand { get;  }
        public Command<MovieItemViewModel> SelectMovieCommand { get; }
        #endregion

        #region Constructors
        public HomeViewModel(IMovieService movieService, INavigationService navigationService, IDialogService dialogService)
        {
            _movieService = movieService;
            _navigationService = navigationService;
            _dialogService = dialogService;

            _movies = new RangeObservableCollection<MovieItemViewModel>();

            LoadMoreCommand = new Command(async () => await ExecuteLoadMoreCommand());
            SearchCommand = new Command(async () => await ExecuteSearchCommand());
            RefreshCommand = new Command(async () => await ExecuteRefreshCommand());
            SelectMovieCommand = new Command<MovieItemViewModel>(async (movie) => await ExecuteSelectMovieCommand(movie));
            
        }
        #endregion

        #region BaseViewModel Methods
        public override async Task OnAppearing()
        {
            IsBusy = true;

            await RefreshMovies();
        }
        #endregion

        #region Private Methods
        private async Task UpdateMovies()
        {
            if( _movieService.Genres == null )
            {
                if (!await _movieService.CacheGenres())
                    return;
            }

            Response<SearchResult> result;

            if (string.IsNullOrWhiteSpace(_lastSearch))
                result = await _movieService.UpcomingMovies(_currentPage);
            else
                result = await _movieService.Search(_lastSearch, _currentPage);

            if (result.IsError)
            {
                if (result.IsApiError)
                    _dialogService.ShowDialog($"Error trying to obtain data\nStatus Code: {result.StatusCode}", "Error");
                else
                    _dialogService.ShowDialog("Error executing operation.", "Error");

                IsBusy = false;
                return;
            }

            var movies = result.Result;

            Movies.AddRange(movies.Results.Select(m => new MovieItemViewModel(_movieService, m)));

            IsBusy = false;
        }

        private async Task RefreshMovies()
        {
            _movies.Clear();
            _currentPage = 1;

            await UpdateMovies();
        }

        private MovieItemViewModel ToMovieItemViewModel(Movie result) => new MovieItemViewModel(_movieService, result);
        #endregion Private Methods

        #region Command Methods
        private async Task ExecuteLoadMoreCommand()
        {
            // Do not load more if another operation is taking place.
            if (IsBusy) return;

            IsBusy = true;
            _currentPage++;

            await UpdateMovies();
        }

        private async Task ExecuteSearchCommand()
        {
            // Do not load more if another operation is taking place.
            if ( IsBusy ) return;

            IsBusy = true;
            _lastSearch = SearchText;

            await RefreshMovies();
        }

        private async Task ExecuteRefreshCommand()
        {
            // Do not load more if another operation is taking place.
            if (IsBusy) return;

            IsBusy = true;
            await RefreshMovies();
        }

        private async Task ExecuteSelectMovieCommand(MovieItemViewModel movie)
        {
            if (movie == null) return;

            await _navigationService.NavigateToAsync<DetailsViewModel>(movie.Id);
        }
        #endregion
    }
}
