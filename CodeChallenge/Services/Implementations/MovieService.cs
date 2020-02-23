﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MovieService.cs" company="ArcTouch LLC">
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
//   Defines the MovieService type.
// </summary>
//  --------------------------------------------------------------------------------------------------------------------


using System.Threading.Tasks;
using CodeChallenge.Common;
using CodeChallenge.Models;
using CodeChallenge.Models.Response;
using CodeChallenge.Services.API;
using CodeChallenge.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

namespace CodeChallenge.Services.Implementations
{
    public class MovieService : IMovieService
    {
        public Task<GenreResponse> GetGenres() => GetApi().GetGenres(Constants.API_KEY, Constants.DEFAULT_LANGUAGE);

        public Task<UpcomingMoviesResponse> UpcomingMovies(int page) => GetApi().UpcomingMovies(Constants.API_KEY, Constants.DEFAULT_LANGUAGE, page, Constants.DEFAULT_REGION);

        public Task<SearchResponse> Search(string query, int page) => GetApi().Search(Constants.API_KEY, query, Constants.DEFAULT_LANGUAGE, page, Constants.DEFAULT_REGION);

        public Task<MovieDetailResponse> GetMovie(int movieId) => GetApi().GetMovie(Constants.API_KEY, Constants.DEFAULT_LANGUAGE, movieId);

        private ITmdbApi GetApi()
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() }
            };

            var refitSettings = new RefitSettings { ContentSerializer = new JsonContentSerializer(jsonSerializerSettings) };

            return RestService.For<ITmdbApi>(Constants.API_URL, refitSettings);
        }
    }
}