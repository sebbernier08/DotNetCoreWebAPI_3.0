﻿using System.ComponentModel.DataAnnotations;

namespace DotNetCoreWebAPI_3._0.DTO
{
    public class LoginDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
