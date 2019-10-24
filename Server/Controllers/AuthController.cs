using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MFA.Server.Services;
using MFA.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MFA.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController: Controller
    {
        private readonly IAuthService _authService;

        public AuthController(
            IAuthService authService)
        {
            _authService = authService;
        }
        
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto register)
        {
            var response = await _authService.RegisterUser(register.Email, register.Password);

            return Ok(response);
        }
        
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto login)
        {
            var response = await _authService.Login(login.Email, login.Password, login.Totp);

            return Ok(response);
        }
    }
}