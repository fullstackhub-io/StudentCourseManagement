namespace Course.Application.User.Commands
{
    using FluentValidation;
    using global::Course.Application.Common.Interfaces;
    public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator(IConfigConstants constant)
        {
            this.RuleFor(v => v.CourseName).NotEmpty().WithMessage(constant.MSG_COURSE_COURSENAME);
            this.RuleFor(v => v.CreditHour).GreaterThan(0).WithMessage(constant.MSG_COURSE_NULLCREDITHOUR);
        }
    }
}
