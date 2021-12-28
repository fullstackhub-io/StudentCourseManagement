using AutoMapper;
using CourseBasket.Application.Common.BaseClass;
using CourseBasket.Application.Common.Interfaces;
using CourseBasket.Application.CoursesBasket.VM;
using CourseBasket.Domain.Entities;
using CourseBasket.Domain.UnitOfWork;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CourseBasket.Application.CoursesBasket.Commands
{
    public class GetAllItemBasketQuery : IRequest<List<CourseBasketVM>>
    {
        public List<string> UserNames { get; set; }
        public class GetAllItemBasketHandler : ApplicationBase, IRequestHandler<GetAllItemBasketQuery, List<CourseBasketVM>>
        {
            public GetAllItemBasketHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<List<CourseBasketVM>> Handle(GetAllItemBasketQuery request, CancellationToken cancellationToken)
            {
                var tt = this.UnitOfWork.Basket.GetAllItemBasket(request.UserNames).Result;
                var res = Mapper.Map(this.UnitOfWork.Basket.GetAllItemBasket(request.UserNames).Result, new List<CourseBasketVM>());
                return await Task.FromResult(res);
            }
        }
    }
}
