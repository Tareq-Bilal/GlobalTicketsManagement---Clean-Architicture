using FluentValidation;
using GlobalTicket.TicketManagement.Application.Contracts.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        public CreateOrderCommandValidator(IOrderRepository orderRepository)
        {

            _orderRepository = orderRepository;

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(UserExist).WithMessage($"Not Found User With this Id");

            RuleFor(x => x.OrderTotal)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.OrderPlaced)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(x => x.OrderPaid)
                .NotNull();

        }

        private async Task<bool> UserExist(Guid userId , CancellationToken c)
        {
              var user =  await _orderRepository.GetByIdAsync(userId);
              return user == null;
        }

    }
}
