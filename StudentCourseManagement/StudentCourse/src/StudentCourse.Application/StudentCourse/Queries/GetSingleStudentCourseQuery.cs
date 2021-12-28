namespace StudentCourse.Application.User.Queries
{
    using AutoMapper;
    using global::StudentCourse.Application.Common.BaseClass;
    using global::StudentCourse.Application.Common.Interfaces;
    using global::StudentCourse.Application.StudentCourse.VM;
    using global::StudentCourse.Domain.UnitOfWork;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

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
