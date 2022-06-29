using System;
using System.Collections.Generic;

namespace MapXamarinForms.Model
{
    public class Feature
    {
        public string Type { get; set; }

        public Properties Properties { get; set; }

        public Geometry Geometry { get; set; }

        public string Id { get; set; }
    }

    public class Geometry
    {
        public string Type { get; set; }

        public List<object> Coordinates { get; set; }
    }

    public class Metadata
    {
        public long Generated { get; set; }

        public string Url { get; set; }

        public string Title { get; set; }

        public int Status { get; set; }

        public string Api { get; set; }

        public int Count { get; set; }
    }

    public class Properties
    {
        public double? Mag { get; set; }

        public string Place { get; set; }

        public long? Time { get; set; }

        public long? Updated { get; set; }

        public long? Tz { get; set; }

        public Uri Url { get; set; }

        public Uri Detail { get; set; }

        public long? Felt { get; set; }

        public double? Cdi { get; set; }

        public double? Mmi { get; set; }

        public string Alert { get; set; }

        public string Status { get; set; }

        public long? Tsunami { get; set; }

        public long? Sig { get; set; }

        public string Net { get; set; }

        public string Code { get; set; }

        public string Ids { get; set; }

        public string Sources { get; set; }

        public string Types { get; set; }

        public long? Nst { get; set; }

        public double? Dmin { get; set; }

        public double? Rms { get; set; }

        public double? Gap { get; set; }

        public string MagType { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }
    }

    public class GeoJson
    {
        public string Type { get; set; }

        public Metadata Metadata { get; set; }

        public List<Feature> Features { get; set; }

        public List<double> Bbox { get; set; }
    }
}
