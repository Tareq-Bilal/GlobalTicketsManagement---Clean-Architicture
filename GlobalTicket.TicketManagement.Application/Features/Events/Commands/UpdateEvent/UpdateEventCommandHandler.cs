using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Presistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IMapper _mapper;
        public UpdateEventCommandHandler(
            IMapper mapper,
            IAsyncRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {

            var @eventToUpdate = await _eventRepository.GetByIdAsync(request.EventId);

            /*
             What _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event)); does:

             It tells AutoMapper:
             
             "Take the values from the request object (which is of type UpdateEventCommand)."
             
             "And apply those values to the eventToUpdate object (which is of type Event)."
             
             "Specifically, you are mapping from an UpdateEventCommand to an Event object."
              (The typeof(...) parameters explicitly tell AutoMapper the source and
              destination types for this particular mapping operation,
              which can be useful when you have multiple mappings between similar types).
              */

            _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));
            
            await _eventRepository.UpdateAsync(eventToUpdate);
        }
    }
}
