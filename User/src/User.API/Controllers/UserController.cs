namespace User.API.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using User.Application.User.Commands;
    using User.Application.User.Queries;
    using User.Application.User.VM;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<UserVM>> Get(int id)
        {
            return await this.Mediator.Send(new GetSingleUserQuery { UserID = id });
        }

        [HttpGet]
        public async Task<ActionResult<UserVM>> Get()
        {
            return await this.Mediator.Send(new GetAllUserQuery());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(AddUserCommand command)
        {
            return await this.Mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Put(UpdateUserCommand command)
        {
            return await this.Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await this.Mediator.Send(new DeleteUserCommand { UserID = id });
        }
    }
}