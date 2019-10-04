using DotNetCoreWebAPI_3._0.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI_3._0.DTO
{
    public class BeerDTO
    {
        public long? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public BeerType Type { get; set; }
    }
}
