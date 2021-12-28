namespace User.Application.User.Commands
{
    using AutoMapper;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using global::User.Application.Common.BaseClass;
    using global::User.Application.Common.Exceptions;
    using global::User.Application.Common.Interfaces;
    using global::User.Domain.UnitOfWork;
    public class UpdateUserCommand : IRequest<bool>
    {
        public int UserID { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public class UpdateUserHandler : ApplicationBase, IRequestHandler<UpdateUserCommand, bool>
        {
            public UpdateUserHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var user = await this.UnitOfWork.Users.GetUser(request.UserID);
                if (user == null)
                {
                    throw new NotFoundException($"The User ID {request.UserID} is not found");
                }

                user.PhoneNumber = request.PhoneNumber;
                user.City = request.City;
                user.State = request.State;
                user.Zip = request.Zip;
                user.Country = request.Country;
                this.UnitOfWork.StartTransaction();
                var res = UnitOfWork.Users.UpdateUser(user).Result;
                this.UnitOfWork.Commit();
                return await Task.Run(() => res, cancellationToken);
            }
        }
    }
}
