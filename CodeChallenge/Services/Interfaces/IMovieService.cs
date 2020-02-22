using CodeChallenge.Models;
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
        Task<Movie> GetMovie(int movieId);
    }
}
