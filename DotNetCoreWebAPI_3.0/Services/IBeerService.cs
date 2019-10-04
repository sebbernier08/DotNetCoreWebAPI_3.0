using DotNetCoreWebAPI_3._0.Data.Models;
using DotNetCoreWebAPI_3._0.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI_3._0.Services
{
    public interface IBeerService
    {
        public List<BeerDTO> GetAll();
        public BeerDTO GetOneBy(Func<Beer, bool> predicate);
        public void Save(BeerDTO beerDTO);
        public void Delete(long id);
    }
}
