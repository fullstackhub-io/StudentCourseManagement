namespace Course.Application.User.Commands
{
    using AutoMapper;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using StudentCourse.Application.Common.BaseClass;
    using StudentCourse.Domain.UnitOfWork;
    using StudentCourse.Application.Common.Interfaces;

    public class DeleteStudentCourseCommand : IRequest<bool>
    {
        public int StudentCourseID { get; set; }
        public class DeleteStudentCourseHandler : ApplicationBase, IRequestHandler<DeleteStudentCourseCommand, bool>
        {
            public DeleteStudentCourseHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<bool> Handle(DeleteStudentCourseCommand request, CancellationToken cancellationToken)
            {
                this.UnitOfWork.StartTransaction();
                var res = UnitOfWork.UserCourse.DeleteStudentCourse(request.StudentCourseID).Result;
                this.UnitOfWork.Commit();
                return await Task.Run(() => res, cancellationToken);
            }
        }
    }
}
