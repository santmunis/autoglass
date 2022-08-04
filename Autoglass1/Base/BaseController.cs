using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Base
{
    public abstract class BaseController : Controller
    {
        protected readonly IMediator Mediator;

        protected BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected async Task<IActionResult> Send<TResponse>(
            BaseContract<TResponse> request,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (request == null) return BadRequest();
            try
            {
                var result = await Mediator.Send(request, cancellationToken);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
