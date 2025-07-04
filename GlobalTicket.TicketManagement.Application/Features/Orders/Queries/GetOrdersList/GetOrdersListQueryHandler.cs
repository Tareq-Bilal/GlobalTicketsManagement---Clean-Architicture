using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Presistence;
using GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetEventsList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrderListVM>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public GetOrdersListQueryHandler(
            IMapper mapper,
            IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }
        
        public async Task<List<OrderListVM>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var allOrders = await _orderRepository.GetAllAsync();
            
            return _mapper.Map<List<OrderListVM>>(allOrders);
        }
    }
}
