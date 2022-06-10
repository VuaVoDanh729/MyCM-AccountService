using Account_Infrastructure.Dtos.Account;
using Acount_Service.Features.Account.Commands;
using Acount_Service.Features.Account.Queries;
using Acount_Service.Features.Account.Queries.Commands;
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
        public async Task<IActionResult> GetAccountById(string query)
        {
            var result = await _mediator.Send(new AccountQuery
            {
                Id = query
            });
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("accounts")]
        public async Task<IActionResult> GetAccountsPagging(int pageSize, int pageIdx)
        {
            var result = await _mediator.Send(new GetListAccountQuery
            {
                PageIdx = pageIdx,
                PageSize = pageSize
            });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewAccount(AddAccountCommand accountCommand)
        {
            var result = await _mediator.Send(accountCommand);
            return result == 1 ? Ok() : StatusCode(406);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAccount(UpdateAccountCommand accountCommand)
        {
            var result = await _mediator.Send(accountCommand);
            return result == 1 ? Ok() : StatusCode(406);
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommand command)
        {
            var result = await _mediator.Send(command);
            return result == 1 ? Ok() : StatusCode(406);
        }
    }
}
