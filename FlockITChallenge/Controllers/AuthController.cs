using FlockITChallenge.Entitie;
using FlockITChallenge.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlockITChallenge.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _AuthService;
        private readonly ILogService _LogService;

        public AuthController(IAuthService authService, ILogService logService)
        {
            _AuthService = authService;
            _LogService = logService;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> getAuth([FromBody] UserEntitie user)
        {
            _LogService.LogInfo("Ingresando a GetAuth");
            return Ok(await _AuthService.getAuth(user, _LogService));

        }
    }
}
