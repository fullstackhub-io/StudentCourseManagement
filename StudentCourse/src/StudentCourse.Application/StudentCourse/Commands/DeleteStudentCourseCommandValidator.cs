namespace Course.Application.User.Commands
{
    using FluentValidation;
    using StudentCourse.Application.Common.Interfaces;

    public class DeleteStudentCourseCommandValidator : AbstractValidator<DeleteStudentCourseCommand>
    {
        public DeleteStudentCourseCommandValidator(IConfigConstants constant)
        {
            this.RuleFor(v => v.StudentCourseID).GreaterThan(0).WithMessage(constant.MSG_SC_NULLStdCourseID);
        }
    }
}
