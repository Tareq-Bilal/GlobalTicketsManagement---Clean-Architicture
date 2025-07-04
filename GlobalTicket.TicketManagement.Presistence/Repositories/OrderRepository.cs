using GlobalTicket.TicketManagement.Application.Contracts.Presistence;
using GloboTicket.TicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Presistence.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly GlobalTicketDbContext _dbcontext;
        public OrderRepository(GlobalTicketDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Order>> GetOrdersByCustomerAsync(Guid userId)
        {
            var orders = await _dbcontext.Orders.Where(o => o.UserId == userId).ToListAsync();
            return orders;
        }
    }
}
