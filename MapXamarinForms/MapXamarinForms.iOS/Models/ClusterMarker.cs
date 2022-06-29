﻿using System;
using CoreLocation;
using Google.Maps;
using Google.Maps.Utility;

namespace MapXamarinForms.iOS.Models
{
    public class ClusterMarker : Marker, IClusterItem
    {
        public ClusterMarker(string Title, CLLocationCoordinate2D Position)
        {
            this.Title = Title;
            this.Position = Position;
        }
    }
}
