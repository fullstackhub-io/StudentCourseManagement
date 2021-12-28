namespace User.Application.User.Commands
{
    using FluentValidation;
    using global::User.Application.Common.Interfaces;
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator(IConfigConstants constant)
        {
            this.RuleFor(v => v.UserID).GreaterThan(0).WithMessage(constant.MSG_USER_NULLUSERID);
            this.RuleFor(v => v.PhoneNumber).NotEmpty().WithMessage(constant.MSG_USER_NULLPHNUM);
            this.RuleFor(v => v.City).NotEmpty().WithMessage(constant.MSG_USER_NULLCITY);
            this.RuleFor(v => v.State).NotEmpty().WithMessage(constant.MSG_USER_NULLSTATE);
            this.RuleFor(v => v.Country).NotEmpty().WithMessage(constant.MSG_USER_NULLCOUNTRY);
        }
    }
}