namespace Course.Application.User.Commands
{
    using AutoMapper;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using global::Course.Application.Common.BaseClass;
    using global::Course.Application.Common.Exceptions;
    using global::Course.Application.Common.Interfaces;
    using global::Course.Domain.UnitOfWork;
    public class UpdateCourseCommand : IRequest<bool>
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseShortName { get; set; }
        public int CreditHour { get; set; }
        public class UpdateUserHandler : ApplicationBase, IRequestHandler<UpdateCourseCommand, bool>
        {
            public UpdateUserHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<bool> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
            {
                var user = await this.UnitOfWork.Users.GetCourse(request.CourseID);
                if (user == null)
                {
                    throw new NotFoundException($"The User ID {request.CourseID} is not found");
                }

                user.CourseName = request.CourseName;
                user.CourseShortName = request.CourseShortName;
                user.CreditHour = request.CreditHour;
                this.UnitOfWork.StartTransaction();
                var res = UnitOfWork.Users.UpdateCourse(user).Result;
                this.UnitOfWork.Commit();
                return await Task.Run(() => res, cancellationToken);
            }
        }
    }
}
