using AutoMapper;
using CourseBasket.Application.Common.BaseClass;
using CourseBasket.Application.Common.Interfaces;
using CourseBasket.Domain.Entities;
using CourseBasket.Domain.UnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CourseBasket.Application.CoursesBasket.Commands
{
    public class GetBasketQuery : IRequest<BasketCart>
    {
        public string UserName { get; set; }
        public class GetBasketHandler : ApplicationBase, IRequestHandler<GetBasketQuery, BasketCart>
        {
            public GetBasketHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<BasketCart> Handle(GetBasketQuery request, CancellationToken cancellationToken)
            {
                return await this.UnitOfWork.Basket.GetBasket(request.UserName);
            }
        }
    }
}
