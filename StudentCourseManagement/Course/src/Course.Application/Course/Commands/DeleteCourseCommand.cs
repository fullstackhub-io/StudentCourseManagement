namespace Course.Application.User.Commands
{
    using AutoMapper;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using global::Course.Application.Common.BaseClass;
    using global::Course.Application.Common.Interfaces;
    using global::Course.Domain.UnitOfWork;
    public class DeleteCourseCommand : IRequest<bool>
    {
        public int CourseID { get; set; }
        public class DeleteUserHandler : ApplicationBase, IRequestHandler<DeleteCourseCommand, bool>
        {
            public DeleteUserHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<bool> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
            {
                this.UnitOfWork.StartTransaction();
                var res = UnitOfWork.Users.DeleteCourse(request.CourseID).Result;
                this.UnitOfWork.Commit();
                return await Task.Run(() => res, cancellationToken);
            }
        }
    }
}
