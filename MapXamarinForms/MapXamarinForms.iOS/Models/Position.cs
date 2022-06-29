using System;
using Newtonsoft.Json;

namespace MapXamarinForms.iOS.Models
{
    public class Position
    {
        [JsonProperty(PropertyName = "lat")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "lng")]
        public double Longitude { get; set; }
    }
}
