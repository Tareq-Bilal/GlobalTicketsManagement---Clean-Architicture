using FluentValidation;
using FluentValidation.Validators;
using GlobalTicket.TicketManagement.Application.Contracts.Presistence;
using GloboTicket.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        public CreateEventCommandValidator(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;

            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Property Name} Must be eceed 50 characters.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(e => e)
                .MustAsync(EventNameAndDateUnique)
                .WithMessage("An event with the same name and date already exists.");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0);


        }

        private async Task<bool> EventNameAndDateUnique(CreateEventCommand e , CancellationToken c)
        {
            return await _eventRepository.IsEventNameAndDateUnique(e.Name, e.Date);   
        }

    }
}
