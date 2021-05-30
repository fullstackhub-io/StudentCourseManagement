using CourseBasket.Application.CoursesBasket.Commands;
using CourseBasket.Application.CoursesBasket.VM;
using CourseBasket.Domain.Entities;
using CoursesBasket.API.Controllers;
using CoursesBasket.Application.CoursesBasket.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseBasket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesBasketController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<ActionResult<List<CourseBasketVM>>> GetAll(List<string> userNames)
        {
            return await this.Mediator.Send(new GetAllItemBasketQuery { UserNames = userNames });
        }

        [HttpGet]
        public async Task<ActionResult<BasketCart>> Get(string userName)
        {
            return await this.Mediator.Send(new GetBasketQuery { UserName = userName });
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Put(UpdateBasketCommand command)
        {
            return await this.Mediator.Send(command);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post(CheckoutBasketCommand command)
        {
            return await this.Mediator.Send(command);
        }

        [HttpDelete("{userName}")]
        public async Task<ActionResult<bool>> Delete(string userName)
        {
            return await this.Mediator.Send(new DeleteBasketCommand { UserName = userName });
        }
    }
}
