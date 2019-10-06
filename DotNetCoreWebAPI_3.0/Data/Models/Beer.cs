using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreWebAPI_3._0.Data.Models
{
    [Table("beer")]
    public class Beer : IEntity
    {
        [Key]
        public long? Id { get; set; }

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required]
        public string Name { get; set; }

        [Required]
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
