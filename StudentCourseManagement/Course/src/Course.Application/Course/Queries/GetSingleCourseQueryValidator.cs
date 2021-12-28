namespace Course.Application.User.Queries
{
    using FluentValidation;
    using global::Course.Application.Common.Interfaces;
    public class GetSingleCourseQueryValidator : AbstractValidator<GetSingleCourseQuery>
    {
        public GetSingleCourseQueryValidator(IConfigConstants constant)
        {
            this.RuleFor(v => v.CourseID).GreaterThan(0).WithMessage(constant.MSG_COURSE_COURSEID);
        }
    }
}
