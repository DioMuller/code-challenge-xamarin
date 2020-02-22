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
//   Defines the HomePageViewModel type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CodeChallenge.Models;
using CodeChallenge.Services.Interfaces;
using CodeChallenge.ViewModels.Base;
using CodeChallenge.ViewModels.Cells;

namespace CodeChallenge.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private readonly IMovieService movieService;
        private ObservableCollection<MovieItemViewModel> movies;

        public HomePageViewModel(IMovieService movieService)
        {
            this.movieService = movieService;
            this.movies = new ObservableCollection<MovieItemViewModel>();
        }

        public ObservableCollection<MovieItemViewModel> Movies
        {
            get => this.movies;
            set => SetProperty(ref this.movies, value);
        }

        public override async Task OnAppearing()
        {
            UpcomingMoviesResponse upcomingMoviesResponse = await this.movieService.UpcomingMovies(1);
            foreach (var movie in upcomingMoviesResponse.Results)
            {
                Movies.Add(ToMovieItemViewModel(movie));
            }
        }

        public MovieItemViewModel ToMovieItemViewModel(Movie result) => new MovieItemViewModel(result);
    }
}
