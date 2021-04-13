namespace Course.API.Controllers
{
    using System.Threading.Tasks;
    using Course.Application.Course.VM;
    using Course.Application.User.Commands;
    using Course.Application.User.Queries;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : BaseController
    {

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseVM>> Get(int id)
        {
            return await this.Mediator.Send(new GetSingleCourseQuery { CourseID = (int)id });
        }

        [HttpGet]
        public async Task<ActionResult<CourseVM>> Get()
        {
            return await this.Mediator.Send(new GetAllCourseQuery());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(AddCourseCommand command)
        {
            return await this.Mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Put(UpdateCourseCommand command)
        {
            return await this.Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await this.Mediator.Send(new DeleteCourseCommand { CourseID = id });
        }
    }
}