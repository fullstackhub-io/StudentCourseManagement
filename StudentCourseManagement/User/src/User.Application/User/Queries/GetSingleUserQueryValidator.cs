namespace User.Application.User.Queries
{
    using FluentValidation;
    using global::User.Application.Common.Interfaces;
    public class GetSingleUserQueryValidator : AbstractValidator<GetSingleUserQuery>
    {
        public GetSingleUserQueryValidator(IConfigConstants constant)
        {
            this.RuleFor(v => v.UserID).GreaterThan(0).WithMessage(constant.MSG_USER_NULLUSERID);
        }
    }
}