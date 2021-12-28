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
    public class GetAllUserQuery : IRequest<UserVM>
    {
        public class GetAllUserHandler : ApplicationBase, IRequestHandler<GetAllUserQuery, UserVM>
        {
            public GetAllUserHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<UserVM> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
            {
                var res = Mapper.Map(UnitOfWork.Users.GetAllUsers().Result, new List<UserDTO>());
                return await Task.FromResult(new UserVM() { UserList = res });
            }
        }
    }
}
