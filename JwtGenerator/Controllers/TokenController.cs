using JwtGenerator.DTO;
using JwtGenerator.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly TokenService _tokenService;
        public TokenController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public ActionResult Index([FromBody] CreateTokenDTO dto)
        {
            var result = _tokenService.CreateToken(dto);
            if (result.Success)
                return Ok(result.Data);

            return Problem(detail: result.Data);
        }
    }
}
