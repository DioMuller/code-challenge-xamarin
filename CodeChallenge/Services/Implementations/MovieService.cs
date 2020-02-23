// --------------------------------------------------------------------------------------------------------------------
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


using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CodeChallenge.Common;
using CodeChallenge.Models;
using CodeChallenge.Services.API;
using CodeChallenge.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

namespace CodeChallenge.Services.Implementations
{
    public class MovieService : IMovieService
    {
        #region Attributes
        private ITmdbApi _api;
        #endregion

        #region Properties
        public List<Genre> Genres { get; private set; }
        #endregion

        #region IMovieService Methods
        public async Task<bool> CacheGenres()
        {
            var response = await GetGenres();

            if (response.IsError) return false;

            Genres = response.Result?.Genres;

            return Genres != null && Genres.Count > 0;
        }

        public Task<Response<GenreList>> GetGenres() => GetResponse(GetApi().GetGenres(Constants.API_KEY, Constants.DEFAULT_LANGUAGE));

        public Task<Response<SearchResult>> UpcomingMovies(int page) => GetResponse(GetApi().UpcomingMovies(Constants.API_KEY, Constants.DEFAULT_LANGUAGE, page, Constants.DEFAULT_REGION));

        public Task<Response<SearchResult>> Search(string query, int page) => GetResponse(GetApi().Search(Constants.API_KEY, query, Constants.DEFAULT_LANGUAGE, page, Constants.DEFAULT_REGION));

        public Task<Response<MovieDetail>> GetMovie(int movieId) => GetResponse(GetApi().GetMovie(Constants.API_KEY, Constants.DEFAULT_LANGUAGE, movieId));
        #endregion

        #region Private Methods
        private ITmdbApi GetApi()
        {
            if (_api == null)
            {
                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() }
                };

                var refitSettings = new RefitSettings { ContentSerializer = new JsonContentSerializer(jsonSerializerSettings) };

                var client = new HttpClient()
                {
                    BaseAddress = new Uri(Constants.API_URL),
                    Timeout = TimeSpan.FromSeconds(Constants.HTTP_TIMEOUT)
                };

                _api = RestService.For<ITmdbApi>(client, refitSettings);
            }

            return _api;
        }

        private async Task<Response<T>> GetResponse<T>(Task<T> task)
        {
            try
            {
                var result = await task;
                return new Response<T>(data: result);
            }
            catch(Exception ex)
            {
                return new Response<T>(exception: ex);
            }             
        }
        #endregion
    }
}