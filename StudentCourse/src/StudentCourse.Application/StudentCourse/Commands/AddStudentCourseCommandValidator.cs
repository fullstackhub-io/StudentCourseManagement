namespace Course.Application.User.Commands
{
    using FluentValidation;
    using StudentCourse.Application.Common.Interfaces;
    using StudentCourse.Application.User.Commands;

    public class AddCourseCommandValidator : AbstractValidator<AddStudentCourseCommand>
    {
        public AddCourseCommandValidator(IConfigConstants constant)
        {
            //this.RuleFor(v => v.CourseName).NotEmpty().WithMessage(constant.MSG_USER_NULLFIRSTNAME);
            //this.RuleFor(v => v.CreditHour).GreaterThan(0).WithMessage(constant.MSG_USER_NULLLASTNAME);
        }
    }
}