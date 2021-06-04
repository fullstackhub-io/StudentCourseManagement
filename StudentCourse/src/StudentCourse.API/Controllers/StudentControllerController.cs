using Course.Application.User.Commands;
using Microsoft.AspNetCore.Mvc;
using StudentCourse.Application.StudentCourse.DTO;
using StudentCourse.Application.StudentCourse.VM;
using StudentCourse.Application.User.Commands;
using StudentCourse.Application.User.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentCourse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : BaseController
    {

        //[HttpGet("{id}")]
        //public async Task<ActionResult<CourseVM>> Get(int id)
        //{
        //    return await this.Mediator.Send(new GetSingleCourseQuery { CourseID = (int)id });
        //}

        [HttpGet]
        public async Task<ActionResult<StudentCourseVM>> Get()
        {
            return await this.Mediator.Send(new GetAllStudentCourseQuery());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(List<StudentCourseDTO> courses)
        {
            return await this.Mediator.Send(new AddStudentCourseCommand() {Courses = courses });
        }

        //[HttpPut]
        //public async Task<ActionResult<bool>> Put(UpdateCourseCommand command)
        //{
        //    return await this.Mediator.Send(command);
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            return await this.Mediator.Send(new DeleteStudentCourseCommand { StudentCourseID = id });
        }

    }
}
