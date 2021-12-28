namespace Course.Application.User.Commands
{
    using FluentValidation;
    using global::Course.Application.Common.Interfaces;
    public class DeleteCourseCommandValidator : AbstractValidator<DeleteCourseCommand>
    {
        public DeleteCourseCommandValidator(IConfigConstants constant)
        {
            this.RuleFor(v => v.CourseID).GreaterThan(0).WithMessage(constant.MSG_COURSE_COURSEID);
        }
    }
}
