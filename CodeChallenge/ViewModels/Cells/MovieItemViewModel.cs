// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MovieItemViewModel.cs" company="ArcTouch LLC">
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
//   Defines the MovieItemViewModel type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using CodeChallenge.Models;
using CodeChallenge.Models.Data;
using CodeChallenge.ViewModels.Base;

namespace CodeChallenge.ViewModels.Cells
{
    public class MovieItemViewModel : BaseViewModel
    {
        #region Bindable Properties
        public string Title { get; set; }

        private string posterPath;
        public string PosterPath { get => this.posterPath; set => SetProperty(ref this.posterPath, value); }

        public DateTimeOffset ReleaseDate { get; set; }

        public string Genres { get; set; }

        public int Id { get; set; }
        #endregion

        #region Constructor
        public MovieItemViewModel(Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
            PosterPath = Utils.MovieImageUrlBuilder.BuildPosterUrl(movie.PosterPath);
            ReleaseDate = movie.ReleaseDate;
            Genres = string.Join(", ", movie.GenreIds.Select(m => App.Genres?.First(g => g.Id == m)?.Name));
        }
        #endregion

    }
}
