using System;

namespace DotNetCoreWebAPI_3._0.Data.Models
{
    public class Beer: IEntity
    {
        public long? Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }
        public BeerType Type { get; set; }
    }

    public enum BeerType
    {
        WHITE,
        BLOND,
        RED,
        API,
        BROWN,
        BLACK
    }
}
