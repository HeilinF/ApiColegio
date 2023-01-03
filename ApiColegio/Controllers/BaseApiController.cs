using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiColegio.Controllers
{
    [ApiController]
    public abstract class BaseApiController<T> : ControllerBase
    {
        protected IMediator _mediatorInstance;
        protected ILogger<T> _loggerInstance;
        protected IMediator _mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();
        protected ILogger<T> _logger => _loggerInstance ??= HttpContext.RequestServices.GetService<ILogger<T>>();
    }
}

