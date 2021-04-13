namespace Course.Application.User.Queries
{
    using AutoMapper;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using global::Course.Application.Common.BaseClass;
    using global::Course.Application.Common.Interfaces;
    using global::Course.Domain.UnitOfWork;
    using global::Course.Application.Course.VM;
    using global::Course.Application.Course.DTO;

    public class GetAllCourseQuery : IRequest<CourseVM>
    {
        public class GetAllUserHandler : ApplicationBase, IRequestHandler<GetAllCourseQuery, CourseVM>
        {
            public GetAllUserHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<CourseVM> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
            {
                var res = Mapper.Map(UnitOfWork.Users.GetAllCourses().Result, new List<CourseDTO>());
                return await Task.FromResult(new CourseVM() { CourseList = res });
            }
        }
    }
}
