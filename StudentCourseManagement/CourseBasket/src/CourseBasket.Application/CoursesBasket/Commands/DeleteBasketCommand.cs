using AutoMapper;
using CourseBasket.Application.Common.BaseClass;
using CourseBasket.Application.Common.Interfaces;
using CourseBasket.Domain.Entities;
using CourseBasket.Domain.UnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CoursesBasket.Application.CoursesBasket.Commands
{
    public class DeleteBasketCommand : IRequest<bool>
    {
        public string UserName { get; set; }
        public class DeleteBasketHandler : ApplicationBase, IRequestHandler<DeleteBasketCommand, bool>
        {
            public DeleteBasketHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork)
                : base(constant, unitOfWork, mapper)
            {
            }

            public async Task<bool> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
            {
                return await this.UnitOfWork.Basket.DeleteBasket(request.UserName);
            }
        }
    }
}
