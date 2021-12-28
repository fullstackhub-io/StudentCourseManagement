namespace StudentCourse.Application.User.Commands
{
    using AutoMapper;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using global::StudentCourse.Application.Common.BaseClass;
    using global::StudentCourse.Application.Common.Interfaces;
    using global::StudentCourse.Domain.UnitOfWork;
    using StudentCourseEntity = Domain.Entities.StudentCourse;
    using System;
    using global::StudentCourse.Application.StudentCourse.DTO;
    using System.Collections.Generic;

    public class AddStudentCourseCommand : IRequest<int>
    {
       public List<StudentCourseDTO> Courses { get; set; }

        public class AddStudentCourseHandler : ApplicationBase, IRequestHandler<AddStudentCourseCommand, int>
        {
            public AddStudentCourseHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<int> Handle(AddStudentCourseCommand request, CancellationToken cancellationToken)
            {
                var result = 0;

                this.UnitOfWork.StartTransaction();
                foreach (var course in request.Courses)
                {
                    var studentCourse = new StudentCourseEntity
                    {
                        FirstName = course.FirstName,
                        LastName = course.LastName,
                        TotalPrice = course.TotalPrice,
                        EmailAddress = course.EmailAddress,
                        Subjects = course.Subjects,
                        PhoneNumber = course.PhoneNumber,
                        Address = course.Address,
                        DateAdded = DateTime.Now,
                        SessionStartDate = DateTime.Now,
                        SessionEndDate = DateTime.Now.AddMonths(4),
                    };
                    result = UnitOfWork.UserCourse.AddStudentCourse(studentCourse).Result;
                }
                this.UnitOfWork.Commit();
                return await Task.Run(() => result, cancellationToken);
            }
        }
    }
}
