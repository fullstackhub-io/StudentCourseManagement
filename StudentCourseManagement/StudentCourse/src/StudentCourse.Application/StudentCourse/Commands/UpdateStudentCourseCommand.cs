namespace Course.Application.User.Commands
{
    using AutoMapper;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using StudentCourse.Application.Common.BaseClass;
    using StudentCourse.Application.Common.Interfaces;
    using StudentCourse.Domain.UnitOfWork;

    public class UpdateStudentCourseCommand : IRequest<bool>
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CrouseShortName { get; set; }
        public int CreditHour { get; set; }
        public class UpdateStudentCourseHandler : ApplicationBase, IRequestHandler<UpdateStudentCourseCommand, bool>
        {
            public UpdateStudentCourseHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<bool> Handle(UpdateStudentCourseCommand request, CancellationToken cancellationToken)
            {
                //var user = await this.UnitOfWork.Users.GetCourse(request.CourseID);
                //if (user == null)
                //{
                //    throw new NotFoundException($"The User ID {request.CourseID} is not found");
                //}

                //user.CourseName = request.CourseName;
                //user.CrouseShortName = request.CrouseShortName;
                //user.CreditHour = request.CreditHour;
                //this.UnitOfWork.StartTransaction();
                //var res = UnitOfWork.Users.UpdateCourse(user).Result;
                //this.UnitOfWork.Commit();
                //return await Task.Run(() => res, cancellationToken);
                return await Task.Run(() => true, cancellationToken);
            }
        }
    }
}
