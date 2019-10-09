using AutoMapper;
using DotNetCoreWebAPI_3._0.Data.Models;
using DotNetCoreWebAPI_3._0.DTO;

namespace DotNetCoreWebAPI_3._0.Mappers
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Beer, BeerDTO>();
            CreateMap<BeerDTO, Beer>();
        }
    }
}
