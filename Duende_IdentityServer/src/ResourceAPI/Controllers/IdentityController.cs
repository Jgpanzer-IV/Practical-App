using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ResourceAPI.Models;

namespace ResourceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class IdentityController : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(typeof(List<IdentityDTO>),200)]
        [ProducesResponseType(403)]
        public IActionResult GetIdentity(){
            
            if (User.Claims != null)
                return Ok(new List<object>(
                    User.Claims.Select(e => new IdentityDTO{
                        Claim = e.Type,
                        Value = e.Value
                }).ToList()));
            else
                return Forbid();
        }

    }
}