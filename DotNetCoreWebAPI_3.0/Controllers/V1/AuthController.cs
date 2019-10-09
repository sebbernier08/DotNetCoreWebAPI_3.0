using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreWebAPI_3._0.DTO;
using DotNetCoreWebAPI_3._0.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebAPI_3._0.Controllers.V1
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public ActionResult Login([FromBody]LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Model!");

            var token = _authService.Authenticate(loginDTO.Email, loginDTO.Password);

            if (token == null)
                return BadRequest(new { message = "Username or password is incorrect!" });

            return Ok(new { Token = token });
        }
    }
}