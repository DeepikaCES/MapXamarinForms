using System;
using AutoMapper;
using Flurl.Http;
using Flurl.Http.Configuration;
using MapXamarinForms.Services;
using MapXamarinForms.Services.Interfaces;
using MapXamarinForms.Utils;
using MapXamarinForms.ViewModel;
using MapXamarinForms.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MapXamarinForms
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
           : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            FlurlHttp.Configure(settings => settings.HttpClientFactory = new CustomHttpClientFactory());


            await NavigationService.NavigateAsync("NavigationPage/MapPage");

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
            containerRegistry.RegisterSingleton<IMapService, MapService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MapPage, MapPageViewModel>();
            containerRegistry.RegisterForNavigation<GeoJsonMapPage, GeoJsonMapPageViewModel>();
            containerRegistry.RegisterForNavigation<ClusterMapPage, ClusterMapPageViewModel>();

            containerRegistry.RegisterInstance(new MapperConfiguration(cfg => cfg.AddMaps(typeof(App).Assembly)).CreateMapper());
        }
    }
}
