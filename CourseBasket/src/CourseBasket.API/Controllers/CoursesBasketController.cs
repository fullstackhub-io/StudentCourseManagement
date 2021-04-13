using CourseBasket.Application.CoursesBasket.Commands;
using CourseBasket.Domain.Entities;
using CoursesBasket.API.Controllers;
using CoursesBasket.Application.CoursesBasket.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CourseBasket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesBasketController : BaseController
    {
        [HttpGet("{userName}")]
        public async Task<ActionResult<BasketCart>> Get(string userName)
        {
            return await this.Mediator.Send(new GetBasketQuery { UserName = userName });
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<BasketCart>> Put(UpdateBasketCommand command)
        {
            return await this.Mediator.Send(command);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<bool>> Post(CheckoutBasketCommand command)
        {
            return await this.Mediator.Send(command);
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult<bool>> Delete(string userName)
        {
            return await this.Mediator.Send(new DeleteBasketCommand { UserName = userName });
        }
    }
}
