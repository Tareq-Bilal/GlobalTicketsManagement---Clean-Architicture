﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Application.Features.Orders.Queries.GetOrdersByCustomer
{
    public class GetOrdersByCustomerQuery : IRequest<List<OrderDto>>
    {
        public Guid UserId { get; set; }

    }
}
