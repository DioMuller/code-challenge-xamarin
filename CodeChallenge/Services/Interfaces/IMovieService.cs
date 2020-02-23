using CodeChallenge.Models;
using CodeChallenge.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Services.Interfaces
{
    public interface IMovieService
    {
        Task<GenreResponse> GetGenres();
        Task<UpcomingMoviesResponse> UpcomingMovies(int page);
        Task<SearchResponse> Search(string query, int page);
        Task<MovieDetailResponse> GetMovie(int movieId);
    }
}
