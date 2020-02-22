using CodeChallenge.ViewModels;
using CodeChallenge.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CodeChallenge.Services.Interfaces
{
    public interface INavigationService
    {
        Task NavigateToAsync<TViewModel>(object parameter = null) where TViewModel : BaseViewModel;
        Task NavigateBackAsync();
    }
}
