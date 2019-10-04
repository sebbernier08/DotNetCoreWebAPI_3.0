using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebAPI_3._0.Data.Models
{
    public interface IEntity
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
