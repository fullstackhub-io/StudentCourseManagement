namespace User.Application.User.Queries
{
    using AutoMapper;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using global::User.Application.Common.BaseClass;
    using global::User.Application.Common.Interfaces;
    using global::User.Application.User.DTO;
    using global::User.Application.User.VM;
    using global::User.Domain.UnitOfWork;

    public class GetSingleUserQuery : IRequest<UserVM>
    {
        public int UserID { get; set; }
        public class GetSingleUserHandler : ApplicationBase, IRequestHandler<GetSingleUserQuery, UserVM>
        {
            public GetSingleUserHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<UserVM> Handle(GetSingleUserQuery request, CancellationToken cancellationToken)
            {
                var res = this.Mapper.Map(this.UnitOfWork.Users.GetUser(request.UserID).Result, new UserDTO());
                return await Task.FromResult(new UserVM() { UserList = new List<UserDTO> { res } });
            }
        }
    }
}
