namespace Course.Application.User.Queries
{
    using AutoMapper;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using StudentCourse.Application.StudentCourse.VM;
    using StudentCourse.Domain.UnitOfWork;
    using StudentCourse.Application.Common.BaseClass;
    using StudentCourse.Application.Common.Interfaces;

    public class GetSingleStudentCourseQuery : IRequest<StudentCourseVM>
    {
        public int CourseID { get; set; }
        public class GetSingleUserHandler : ApplicationBase, IRequestHandler<GetSingleStudentCourseQuery, StudentCourseVM>
        {
            public GetSingleUserHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<StudentCourseVM> Handle(GetSingleStudentCourseQuery request, CancellationToken cancellationToken)
            {
                //var res = this.Mapper.Map(this.UnitOfWork.Users.GetCourse(request.CourseID).Result, new CourseDTO());
                //return await Task.FromResult(new CourseVM() { CourseList = new List<CourseDTO> { res } });
                return await Task.Run(() => new StudentCourseVM(), cancellationToken);
            }
        }
    }
}
