using AutoMapper;
using EventBus.Message.Events;
using MassTransit;
using MediatR;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using System.Threading.Tasks;

namespace Ordering.API.EventBusConsumer
{
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        public readonly IMediator mediator;
        public readonly IMapper mapper;

        public BasketCheckoutConsumer(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            var command = mapper.Map<CheckoutOrderCommand>(context.Message);
            await mediator.Send(command);
        }
    }
}
