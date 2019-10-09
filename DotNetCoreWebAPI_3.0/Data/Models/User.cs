using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreWebAPI_3._0.Data.Models
{
    [Table("user")]
    public class User : IEntity
    {
        [Key]
        public long? Id { get; set; }

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }

    public class Role
    {
        public const string ADMIN = "ADMIN";
        public const string MEMBER = "MEMBER";
    }
}
