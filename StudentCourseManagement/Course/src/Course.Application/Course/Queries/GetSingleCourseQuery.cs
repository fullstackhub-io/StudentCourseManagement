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

    public class GetSingleCourseQuery : IRequest<CourseVM>
    {
        public int CourseID { get; set; }
        public class GetSingleUserHandler : ApplicationBase, IRequestHandler<GetSingleCourseQuery, CourseVM>
        {
            public GetSingleUserHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<CourseVM> Handle(GetSingleCourseQuery request, CancellationToken cancellationToken)
            {
                var res = this.Mapper.Map(this.UnitOfWork.Users.GetCourse(request.CourseID).Result, new CourseDTO());
                return await Task.FromResult(new CourseVM() { CourseList = new List<CourseDTO> { res } });
            }
        }
    }
}
