using MapXamarinForms.Model;
using MapXamarinForms.Services.Interfaces;
using Prism.Navigation;

namespace MapXamarinForms.ViewModel
{
    public class GeoJsonMapPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMapService _mapService;
        private GeoJson geoJsonData;

        public GeoJsonMapPageViewModel(INavigationService navigationService, IMapService mapService) : base(navigationService)
        {
            _navigationService = navigationService;
            _mapService = mapService;
        }

        public GeoJson GeoJsonData
        {
            get => geoJsonData;
            set => SetProperty(ref geoJsonData, value);
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.GetNavigationMode() == NavigationMode.New)
            {
                GeoJsonData = await _mapService.GetGeoJsonDataAsync();
            }
        }
    }
}
