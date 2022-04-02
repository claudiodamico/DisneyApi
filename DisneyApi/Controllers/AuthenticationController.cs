using DisneyApi.Domain.DTOs;
using IdentityServer3.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DisneyApi.Presentation.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IUserService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        
    }
}
