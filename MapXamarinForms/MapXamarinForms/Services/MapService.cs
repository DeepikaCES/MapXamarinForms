using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Flurl.Http;
using Flurl.Http.Configuration;
using MapXamarinForms.Model;
using MapXamarinForms.Model.Response;
using MapXamarinForms.Services.Interfaces;

namespace MapXamarinForms.Services
{
    public class MapService : IMapService
    {
        private readonly IFlurlClient _flurlClient;
        private readonly IMapper _mapper;

        public MapService(IFlurlClientFactory flurlClientFactory, IMapper mapper)
        {
            _mapper = mapper;
            _flurlClient = flurlClientFactory.Get("https://run.mocky.io/v3/");           
        }

        public async Task<List<Cluster>> GetClustersDataAsync()
        {
            return _mapper.Map<List<ClusterResponse>, List<Cluster>>(await _flurlClient.Request("b9720902-676a-4d57-99fe-2893950fa9a4").GetJsonAsync<List<ClusterResponse>>());
        }

        public async Task<GeoJson> GetGeoJsonDataAsync()
        {
            return _mapper.Map<GeoJsonResponse, GeoJson>(await _flurlClient.Request("d72d95b4-b0f6-4503-9c10-bf2fdd1f953b").GetJsonAsync<GeoJsonResponse>());
        }
    }
}
