using System;
using System.Collections.Generic;
using MapXamarinForms.Model;
using MapXamarinForms.Services.Interfaces;
using Prism.Navigation;

namespace MapXamarinForms.ViewModel
{
    public class ClusterMapPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMapService _mapService;
        private List<Cluster> _clusterResponseData;

        public ClusterMapPageViewModel(INavigationService navigationService, IMapService mapService) : base(navigationService)
        {
            _navigationService = navigationService;
            _mapService = mapService;
        }

        public List<Cluster> ClusterData
        {
            get { return _clusterResponseData; }
            set { SetProperty(ref _clusterResponseData, value); }
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            ClusterData = await _mapService.GetClustersDataAsync();
        }
      
    }
}
