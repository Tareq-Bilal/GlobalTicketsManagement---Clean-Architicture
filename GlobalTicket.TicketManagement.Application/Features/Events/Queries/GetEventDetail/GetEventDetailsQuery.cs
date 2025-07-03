using GloboTicket.TicketManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailsQuery : IRequest<EventDetailVM>
    {
        public Guid Id { get; set; }

    }
}
