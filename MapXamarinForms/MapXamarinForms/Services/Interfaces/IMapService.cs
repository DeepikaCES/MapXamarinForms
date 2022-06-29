using System.Collections.Generic;
using System.Threading.Tasks;
using MapXamarinForms.Model;

namespace MapXamarinForms.Services.Interfaces
{
    public interface IMapService
    {
        Task<GeoJson> GetGeoJsonDataAsync();

        Task<List<Cluster>> GetClustersDataAsync();
    }
}
