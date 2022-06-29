using System;
using System.Collections.Generic;
using MapXamarinForms.CustomPin;
using MapXamarinForms.Model;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MapXamarinForms.Control
{
    public class ClusterMap : Map
    {
        public List<ClusterPin> CustomPins { get; set; }

        public static readonly BindableProperty ClusterDataProperty = BindableProperty.Create(nameof(ClusterData), typeof(List<Cluster>), typeof(ClusterMap), new List<Cluster>());

        public List<Cluster> ClusterData
        {
            get { return (List<Cluster>)GetValue(ClusterDataProperty); }
            private set { SetValue(ClusterDataProperty, value); }
        }
    }
}
