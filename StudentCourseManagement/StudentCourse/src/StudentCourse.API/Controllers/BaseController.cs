namespace StudentCourse.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator mediator;

        /// <summary>
        /// Gets the Mediator.
        /// </summary>
        protected IMediator Mediator => this.mediator ??= this.HttpContext.RequestServices.GetService<IMediator>();
    }
}