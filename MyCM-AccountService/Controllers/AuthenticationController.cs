using Account_Infrastructure.Dtos.Authentication;
using Acount_Service.Features.Account.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCM_AccountService.Controllers
{
    [Route("ocrm/authen")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<LoginToken> Login(LoginDto login)
        {
            var result = await _mediator.Send(login);
            return result;
        }
    }
}
