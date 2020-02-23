using CodeChallenge.Services.Interfaces;
using CodeChallenge.Utils;
using CodeChallenge.ViewModels.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CodeChallenge.ViewModels
{
    class DetailsViewModel : BaseViewModel
    {
        #region Attributes
        private IMovieService _movieService;
        private int _movieId;
        #endregion

        #region Bindable Properties

        #region Title
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        #endregion

        #region PosterPath
        private string _posterPath;
        public string PosterPath
        {
            get => _posterPath;
            set => SetProperty(ref _posterPath, value);
        }
        #endregion

        #region BackdropPath
        private string _backdropPath;
        public string BackdropPath
        {
            get => _backdropPath;
            set => SetProperty(ref _backdropPath, value);
        }
        #endregion

        #region ReleaseDate
        private DateTimeOffset _releaseDate;
        public DateTimeOffset ReleaseDate
        {
            get => _releaseDate;
            set => SetProperty(ref _releaseDate, value);
        }
        #endregion

        #region Genres
        private string _genres;
        public string Genres
        {
            get => _genres;
            set => SetProperty(ref _genres, value);
        }
        #endregion

        #region Description
        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }
        #endregion

        #endregion

        #region Constructors
        public DetailsViewModel(IMovieService movieService)
        {
            _movieService = movieService;
        }
        #endregion

        #region BaseViewModel Methods
        public override async Task Initialize(object parameter = null)
        {
            if( parameter is int )
            {
                _movieId = (int)parameter;
                UpdateMovieData();
            }
            else
            {
                throw new Exception("DetailsViewModel needs an integer movie id parameter.");
            }

        }
        #endregion

        #region Private Methods
        private async Task UpdateMovieData()
        {
            IsBusy = true;
            var result = await _movieService.GetMovie(_movieId);

            if( result.IsError )
            {
                // TODO: Show Error Message.
                IsBusy = false;
                return;
            }

            var details = result.Result;

            Title = details.Title;
            PosterPath = MovieImageUrlBuilder.BuildPosterUrl(details.PosterPath);
            BackdropPath = MovieImageUrlBuilder.BuildBackdropUrl(details.BackdropPath);
            ReleaseDate = details.ReleaseDate;

            if (details.Genres != null)
            {
                Genres = string.Join(", ", details.Genres.Select(g => g.Name));
            }
            else
            {
                Genres = "Unavaliable";
            }

            Description = details.Overview;

            IsBusy = false;
        }
        #endregion
    }
}
