// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMovieService.cs" company="ArcTouch LLC">
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
//   Defines the IMovieService type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------

using CodeChallenge.Models;
using CodeChallenge.Services.API;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeChallenge.Services.Interfaces
{
    public interface IMovieService
    {
        List<Genre> Genres { get; }

        Task<bool> CacheGenres();
        Task<Response<GenreList>> GetGenres();
        Task<Response<SearchResult>> UpcomingMovies(int page);
        Task<Response<SearchResult>> Search(string query, int page);
        Task<Response<MovieDetail>> GetMovie(int movieId);
    }
}
