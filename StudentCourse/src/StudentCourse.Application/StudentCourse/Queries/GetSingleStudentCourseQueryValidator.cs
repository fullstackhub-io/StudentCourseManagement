namespace StudentCourse.Application.User.Queries
{
    using FluentValidation;
    using global::StudentCourse.Application.Common.Interfaces;

    public class GetSingleStudentCourseQueryValidator : AbstractValidator<GetSingleStudentCourseQuery>
    {
        public GetSingleStudentCourseQueryValidator(IConfigConstants constant)
        {
            this.RuleFor(v => v.CourseID).GreaterThan(0).WithMessage(constant.MSG_COURSE_COURSEID);
        }
    }
}
