namespace User.Application.User.Commands
{
    using FluentValidation;
    using global::User.Application.Common.Interfaces;
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator(IConfigConstants constant)
        {
            this.RuleFor(v => v.UserID).GreaterThan(0).WithMessage(constant.MSG_USER_NULLUSERID);
        }
    }
}