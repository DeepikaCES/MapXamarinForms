using AutoMapper;
using MapXamarinForms.Model.Response;
using MapXamarinForms.Model;

namespace MapXamarinForms.Profiles
{
    public class GeoJsonProfile: Profile
    {
       public GeoJsonProfile()
        {
            CreateMap<GeoJsonResponse, GeoJson>();
            CreateMap<FeatureResponse, Feature>();
            CreateMap<GeometryResponse, Geometry>();
            CreateMap<MetadataResponse, Metadata>();
            CreateMap<PropertiesResponse, Properties>();
        }
    }   
}
