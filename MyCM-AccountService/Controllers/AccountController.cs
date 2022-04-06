using Account_Infrastructure.Dtos.Account;
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
    [Route("ocrm/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccountById(AccountQuery query)
        {
            var result = await _mediator.Send(query);
            if(result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("accounts")]
        public async Task<IActionResult> GetAccountsPaging(int pageSize, int pageIdx)
        {
            var result = await _mediator.Send(new GetListAccountQuery { 
                PageIdx = pageIdx,
                PageSize = pageSize
            });
            return Ok(result);
        }
    }
}
