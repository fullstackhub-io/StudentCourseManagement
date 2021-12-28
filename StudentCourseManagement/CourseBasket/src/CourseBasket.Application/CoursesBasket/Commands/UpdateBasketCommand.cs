using AutoMapper;
using CourseBasket.Application.Common.BaseClass;
using CourseBasket.Application.Common.Interfaces;
using CourseBasket.Domain.Entities;
using CourseBasket.Domain.UnitOfWork;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CourseBasket.Application.CoursesBasket.Commands
{
    public class UpdateBasketCommand : IRequest<bool>
    {
        public string UserEmail { get; set; }
        public List<BasketCartItem> Items { get; set; }

        public class UpdateBasketHandler : ApplicationBase, IRequestHandler<UpdateBasketCommand, bool>
        {
            private BasketCart basket;
            public UpdateBasketHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<bool> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
            {
                basket = new BasketCart { UserEmail = request.UserEmail, Items = request.Items.Distinct().ToList() };
                return await this.UnitOfWork.Basket.UpdateBasket(basket);
            }
        }
    }
}
