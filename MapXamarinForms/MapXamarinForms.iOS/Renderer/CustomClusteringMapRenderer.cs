using System;
using System.ComponentModel;
using CoreGraphics;
using CoreLocation;
using Foundation;
using Google.Maps;
using Google.Maps.Utility;
using MapXamarinForms.Control;
using MapXamarinForms.iOS.Models;
using MapXamarinForms.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ClusterMap), typeof(CustomClusteringMapRenderer))]
namespace MapXamarinForms.iOS.Renderer
{
    public class CustomClusteringMapRenderer : MapRenderer
    {
        private double cameraLatitude = -33.8;
        private double cameraLongitude = 151.2;
        double extent = 0.2;

        private MapView mapView;
        private MapDelegate mapDelegate;
        private ClusterManager clusterManager;
        private UIViewController uIViewController ;
       
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if(e.PropertyName == "ClusterData")
            {
                var data = ((ClusterMap)sender).ClusterData;
                SetRemoveButton();
                SetClusterManager();
                for (int index = 0; index < data.Count; index++)
                {
                    double lat = data[index].Lat + extent * GetRandomNumber(-1.0, 1.0);
                    double lng = data[index].Lng + extent * GetRandomNumber(-1.0, 1.0);
                    var item = new ClusterMarker(data[index].Title + index, new CLLocationCoordinate2D(lat, lng));
                    clusterManager.AddItem(item);
                }

                clusterManager.Cluster();
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var window = UIApplication.SharedApplication.KeyWindow;
                uIViewController = window?.RootViewController;

                var camera = CameraPosition.FromCamera(cameraLatitude, cameraLongitude, 10);
                mapView = MapView.FromCamera(CGRect.Empty, camera);

                uIViewController.View = mapView;              
            }
        }

        private void SetRemoveButton()
        {
            UIBarButtonItem removeButton = new UIBarButtonItem()
            {
                Target = this,
                Title = "Remove",
                Style = UIBarButtonItemStyle.Plain
            };
            removeButton.Clicked -= RemoveButton_Clicked;
            removeButton.Clicked += RemoveButton_Clicked;
            uIViewController.NavigationItem.RightBarButtonItems = new UIBarButtonItem[] { removeButton };
        }


        private void SetClusterManager()
        {
            mapDelegate = new MapDelegate(mapView);
            var iconGenerator = IconGeneratorWithImages();
            var algorithm = new NonHierarchicalDistanceBasedAlgorithm();
            var renderer = new DefaultClusterRenderer(mapView, iconGenerator) { WeakDelegate = mapDelegate };
            clusterManager = new ClusterManager(mapView, algorithm, renderer);
            clusterManager.SetDelegate(mapDelegate, mapDelegate);  
        }

        void RemoveButton_Clicked(object sender, EventArgs e)
        {
            clusterManager = null;
        }

        public double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        private DefaultClusterIconGenerator DefaultIconGenerator()
        {
            return new DefaultClusterIconGenerator();
        }

        private DefaultClusterIconGenerator IconGeneratorWithImages()
        {
            return new DefaultClusterIconGenerator(new NSNumber[] { 50, 100, 250, 500, 1000 }, new UIImage[] { UIImage.FromBundle("m1"), UIImage.FromBundle("m2"), UIImage.FromBundle("m3"), UIImage.FromBundle("m4"), UIImage.FromBundle("m5") });
        }
        internal class MapDelegate : MapViewDelegate, IClusterManagerDelegate, IClusterRendererDelegate
        {
            private MapView mapView;

            public MapDelegate(MapView mapView)
            {
                this.mapView = mapView;
            }
            public override void DidTapAtCoordinate(MapView mapView, CLLocationCoordinate2D coordinate)
            {
                Console.WriteLine(string.Format("Tapped at location: ({0}, {1})", coordinate.Latitude, coordinate.Longitude));
            }

            public override bool TappedMarker(MapView mapView, Marker marker)
            {
                if (marker.UserData is ClusterMarker)
                {
                    Console.WriteLine("Did tap marker for cluster item " + ((ClusterMarker)marker.UserData).Title);
                }
                else
                {
                    Console.WriteLine("Did tap a normal marker");
                }
                return false;
            }

            [Export("clusterManager:didTapCluster:")]
            public bool DidTapCluster(ClusterManager clusterManager, ICluster cluster)
            {
                mapView.MoveCamera(CameraUpdate.SetTarget(cluster.Position, mapView.Camera.Zoom + 1));
                return true;
            }

            [Export("renderer:willRenderMarker:")]
            public void WillRenderMarker(IClusterRenderer renderer, Marker marker)
            {
                if (marker.UserData is ClusterMarker)
                {
                    marker.Title = ((ClusterMarker)marker.UserData).Title;
                }
            }
        }
    }
}
