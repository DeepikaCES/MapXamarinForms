using System;
using MapXamarinForms.Views;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace MapXamarinForms.ViewModel
{
    public class MapPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public MapPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            GeoJsonCommand = new DelegateCommand(GeoJsonCommandHandler);
            ClusterCommand = new DelegateCommand(ClusterCommandHandler);
        }

        public DelegateCommand GeoJsonCommand { get; }
        public DelegateCommand ClusterCommand { get; }

        private async void GeoJsonCommandHandler()
        {

            await _navigationService.NavigateAsync($"{nameof(NavigationPage)}{nameof(GeoJsonMapPage)}");
        }

        private async void ClusterCommandHandler()
        {
            await _navigationService.NavigateAsync($"{nameof(NavigationPage)}{nameof(ClusterMapPage)}");
        }
    }
}
