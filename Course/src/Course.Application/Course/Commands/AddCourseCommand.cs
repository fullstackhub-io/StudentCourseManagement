namespace Course.Application.User.Commands
{
    using AutoMapper;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using global::Course.Application.Common.BaseClass;
    using global::Course.Application.Common.Interfaces;
    using global::Course.Domain.UnitOfWork;
    using global::Course.Domain.Entities;
    public class AddCourseCommand : IRequest<int>
    {
        public string CourseName { get; set; }
        public string CourseShortName { get; set; }
        public int CreditHour { get; set; }

        public class AddNewUserHandler : ApplicationBase, IRequestHandler<AddCourseCommand, int>
        {
            public AddNewUserHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<int> Handle(AddCourseCommand request, CancellationToken cancellationToken)
            {
                var user = new Course
                {
                    CourseName = request.CourseName,
                    CourseShortName = request.CourseShortName,
                    CreditHour = request.CreditHour,
                };
                this.UnitOfWork.StartTransaction();
                var res = UnitOfWork.Users.AddCourse(user).Result;
                this.UnitOfWork.Commit();
                return await Task.Run(() => res, cancellationToken);
            }
        }
    }
}
