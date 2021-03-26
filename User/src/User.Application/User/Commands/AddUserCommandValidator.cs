namespace User.Application.User.Commands
{
    using FluentValidation;
    using System.Linq;
    using global::User.Application.Common.Interfaces;
    public class AddUserCommandValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserCommandValidator(IConfigConstants constant)
        {
            this.RuleFor(v => v.FirstName).NotEmpty().WithMessage(constant.MSG_USER_NULLFIRSTNAME);
            this.RuleFor(v => v.LastName).NotEmpty().WithMessage(constant.MSG_USER_NULLLASTNAME);
            this.RuleFor(v => v.DOB).NotEmpty().WithMessage(constant.MSG_USER_NULLDOB);
            this.RuleFor(v => v.Gender).Must(x => (new string[] { "M", "F", "m", "f" }).Contains(x)).WithMessage(constant.MSG_USER_NULLGENDER);
            this.RuleFor(v => v.EmailAddress).NotEmpty().WithMessage(constant.MSG_USER_NULLEMAILADDR);
            this.RuleFor(v => v.PhoneNumber).NotEmpty().WithMessage(constant.MSG_USER_NULLPHNUM);
            this.RuleFor(v => v.City).NotEmpty().WithMessage(constant.MSG_USER_NULLCITY);
            this.RuleFor(v => v.State).NotEmpty().WithMessage(constant.MSG_USER_NULLSTATE);
            this.RuleFor(v => v.Country).NotEmpty().WithMessage(constant.MSG_USER_NULLCOUNTRY);
        }
    }
}