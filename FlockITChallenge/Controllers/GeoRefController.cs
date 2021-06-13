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
    public class GeoRefController : ControllerBase
    {
        private readonly IGeoRefService _geoRefService;

        public GeoRefController(IGeoRefService geoRefService)
        {
            _geoRefService = geoRefService;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> getGeoRef([FromBody] StateEntitie state)
        {

            return Ok(await _geoRefService.getGeoRefByState(state));

        }
    }
}
