using API.Helper;
using Application.Products.Commands.Create;
using Application.Products.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly JwtService _jwtService;

        public ProductController(IMediator mediator, JwtService jwtService)
        {
            _mediator = mediator;
            _jwtService = jwtService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] string? userName)
        {
            return Ok(await _mediator.Send(new GetAllProduct(userName)));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromBody] CreateProduct command)
        {
            command.AppUserId = _jwtService.GetTokenClaims(Request.GetJWTTokenFromRequest())
                                                .FirstOrDefault(q => q.Key == ClaimTypes.NameIdentifier).Value;
            
            return Ok(await _mediator.Send(command));
        }
    }
}
