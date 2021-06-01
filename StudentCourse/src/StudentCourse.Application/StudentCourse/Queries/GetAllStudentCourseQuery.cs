namespace StudentCourse.Application.User.Queries
{
    using AutoMapper;
    using global::StudentCourse.Application.Common.BaseClass;
    using global::StudentCourse.Application.Common.Interfaces;
    using global::StudentCourse.Application.StudentCourse.DTO;
    using global::StudentCourse.Application.StudentCourse.VM;
    using global::StudentCourse.Domain.UnitOfWork;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

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
                var res = Mapper.Map(UnitOfWork.UserCourse.GetAllStudentCourse().Result, new List<StudentCourseDTO>());
                var rr = new StudentCourseVM() { CourseList = res };
                return await Task.FromResult(new StudentCourseVM() { CourseList = res });
                //return await Task.Run(() => res, cancellationToken);
            }
        }
    }
}
