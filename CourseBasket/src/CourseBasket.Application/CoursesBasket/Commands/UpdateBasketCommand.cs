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
    public class UpdateBasketCommand : IRequest<BasketCart>
    {
        public BasketCart Basket { get; set; }
        public class UpdateBasketHandler : ApplicationBase, IRequestHandler<UpdateBasketCommand, BasketCart>
        {
            public UpdateBasketHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<BasketCart> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
            {
                return await this.UnitOfWork.Basket.UpdateBasket(request.Basket);
            }
        }
    }
}
