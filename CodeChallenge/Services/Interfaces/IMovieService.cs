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
