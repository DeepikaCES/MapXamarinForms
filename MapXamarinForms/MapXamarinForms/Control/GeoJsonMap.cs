using System;
using System.Collections.Generic;
using MapXamarinForms.CustomPin;
using MapXamarinForms.Model;
using MapXamarinForms.Model.Response;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MapXamarinForms.Control
{
    public class GeoJsonMap : Map
    {
        public List<GeoJsonPin> CustomPins { get; set; }

        public static readonly BindableProperty MapDataProperty =
            BindableProperty.Create(nameof(MapData), typeof(GeoJson), typeof(ClusterMap), null, BindingMode.TwoWay);


        public GeoJson MapData
        {
            get => (GeoJson)GetValue(MapDataProperty);
            private set => SetValue(MapDataProperty, value);
        }
    }
}
