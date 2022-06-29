using System.ComponentModel;
using CoreGraphics;
using Foundation;
using Google.Maps;
using Google.Maps.Utility;
using MapXamarinForms.Control;
using MapXamarinForms.iOS.Renderer;
using Newtonsoft.Json;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GeoJsonMap), typeof(CustomGeoJsonMapRenderer))]
namespace MapXamarinForms.iOS.Renderer
{
    public class CustomGeoJsonMapRenderer : MapRenderer
    {
        private double cameraLatitude = -33.8;
        private double cameraLongitude = 151.2;
      
        private MapView mapView;
        private UIViewController viewController ;

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

           
            if (e.PropertyName == "MapData")
            {
                var data = (sender as GeoJsonMap).MapData;
                string jsonSerialized = JsonConvert.SerializeObject(data);

                // var nsdata = NSData.FromString(jsonSerialized, NSStringEncoding.Unicode);
                // var jsonParser = new GMUGeoJSONParser(data:jsonSerialized);
                var path = NSBundle.PathForResourceAbsolute("GeoJSON_Sample", "geojson", viewController.NibBundle.BundlePath);
                var url = NSUrl.CreateFileUrl(path, null);
                var jsonParser = new GMUGeoJSONParser(url);
                jsonParser.Parse();
                var renderer = new GeometryRenderer(mapView, jsonParser.Features );
                renderer.Render();
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                SetMapView();
            }
        }

        private void SetMapView()
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            viewController = window?.RootViewController;
            var camera = CameraPosition.FromCamera(cameraLatitude, cameraLongitude, 1);
            mapView = MapView.FromCamera(CGRect.Empty, camera);
            viewController.View = mapView;
        }
    }
}
