using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Presistence;
using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery , List<EventLisVM>>
    {

        private readonly IAsyncRepository<Event> _eventRepositroy;
        private readonly IMapper _mapper;

        public GetEventsListQueryHandler(IMapper mapper , IAsyncRepository<Event> eventRepositroy)
        {
            _eventRepositroy = eventRepositroy;
            _mapper = mapper;
        }
        public async Task<List<EventLisVM>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            var allEevnts = (await _eventRepositroy.GetAllAsync()).OrderBy(x => x.Date);
            return   _mapper.Map<List<EventLisVM>>(allEevnts);
        }
    }
}
