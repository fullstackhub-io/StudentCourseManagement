namespace StudentCourse.Application.User.Commands
{
    using AutoMapper;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using global::StudentCourse.Application.Common.BaseClass;
    using global::StudentCourse.Application.Common.Interfaces;
    using global::StudentCourse.Domain.UnitOfWork;
    using StudentCourseEntity = global::StudentCourse.Domain.Entities.StudentCourse;
    using System;
    using global::StudentCourse.Application.StudentCourse.DTO;

    public class AddStudentCourseCommand : IRequest<int>
    {
        public StudentCourseDTO StudentCourse { get; set; }

        public class AddStudentCourseHandler : ApplicationBase, IRequestHandler<AddStudentCourseCommand, int>
        {
            public AddStudentCourseHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<int> Handle(AddStudentCourseCommand request, CancellationToken cancellationToken)
            {
                var studentCourse = new StudentCourseEntity
                {
                    FirstName = request.StudentCourse.FirstName,
                    LastName = request.StudentCourse.LastName,
                    TotalPrice = request.StudentCourse.TotalPrice,
                    EmailAddress = request.StudentCourse.EmailAddress,
                    PhoneNumber = request.StudentCourse.PhoneNumber,
                    Address = request.StudentCourse.Address,
                    DateAdded = DateTime.Now,
                    SessionStartDate = DateTime.Now,
                    SessionEndDate = DateTime.Now.AddMonths(4),
                };
                this.UnitOfWork.StartTransaction();
                var res = UnitOfWork.UserCourse.AddStudentCourse(studentCourse).Result;
                this.UnitOfWork.Commit();
                return await Task.Run(() => res, cancellationToken);
            }
        }
    }
}
