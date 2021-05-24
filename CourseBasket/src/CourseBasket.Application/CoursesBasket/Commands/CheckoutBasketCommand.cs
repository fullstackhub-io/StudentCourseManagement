using AutoMapper;
using CourseBasket.Application.Common.BaseClass;
using CourseBasket.Application.Common.Interfaces;
using CourseBasket.Domain.Entities;
using CourseBasket.Domain.UnitOfWork;
using EventBusRabbitMQ.Common;
using EventBusRabbitMQ.Events;
using EventBusRabbitMQ.Producer;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CourseBasket.Application.CoursesBasket.Commands
{
    public class CheckoutBasketCommand : IRequest<bool>
    {
        public BasketCheckout BasketCheckout { get; set; }
        public class CheckoutBasketHandler : ApplicationBase, IRequestHandler<CheckoutBasketCommand, bool>
        {
            private readonly EventBusRabbitMQProducer eventBusRabbitMQProducer;
            public CheckoutBasketHandler(IConfigConstants constant, IMapper mapper, IUnitOfWork unitOfWork, EventBusRabbitMQProducer eventBusRabbitMQProducer)
                : base(constant, unitOfWork, mapper)
            {
                this.eventBusRabbitMQProducer = eventBusRabbitMQProducer;
            }

            public async Task<bool> Handle(CheckoutBasketCommand request, CancellationToken cancellationToken)
            {
                var eventMessage = this.Mapper.Map<CourseCheckoutEvent>(request.BasketCheckout);
                try
                {
                    this.eventBusRabbitMQProducer.PublishCoursesCheckout(Constants.CourseCheckoutQueue, eventMessage);
                }
                catch (Exception)
                {
                    throw;
                }

                return await Task.Run(() => true);
            }
        }
    }
}