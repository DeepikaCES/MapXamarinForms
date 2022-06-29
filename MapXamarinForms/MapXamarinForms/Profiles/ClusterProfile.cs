using AutoMapper;
using MapXamarinForms.Model;
using MapXamarinForms.Model.Response;

namespace MapXamarinForms.Profiles
{
    public class ClusterProfile : Profile
    {
        public ClusterProfile()
        {
            CreateMap<ClusterResponse, Cluster>();
        }
    }
}
