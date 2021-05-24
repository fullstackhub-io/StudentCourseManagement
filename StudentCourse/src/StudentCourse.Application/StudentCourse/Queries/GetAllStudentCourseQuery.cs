namespace Course.Application.User.Queries
{
    using AutoMapper;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using StudentCourse.Application.Common.BaseClass;
    using StudentCourse.Application.Common.Interfaces;
    using StudentCourse.Application.StudentCourse.VM;
    using StudentCourse.Domain.UnitOfWork;

    public class GetAllStudentCourseQuery : IRequest<StudentCourseVM>
    {
        public class GetAllStudentCourseHandler : ApplicationBase, IRequestHandler<GetAllStudentCourseQuery, StudentCourseVM>
        {
            public GetAllStudentCourseHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<StudentCourseVM> Handle(GetAllStudentCourseQuery request, CancellationToken cancellationToken)
            {
                //var res = Mapper.Map(UnitOfWork.Users.GetAllCourses().Result, new List<CourseDTO>());
                //return await Task.FromResult(new CourseVM() { CourseList = res });
                return await Task.Run(() => new StudentCourseVM(), cancellationToken);
            }
        }
    }
}
