using GlobalTicket.TicketManagement.Application.Contracts.Presistence;
using GloboTicket.TicketManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTicket.TicketManagement.Presistence.Repositories
{
    public class EeventRepository : BaseRepository<Event>, IEventRepository
    {
        private readonly GlobalTicketDbContext _dbcontext;

        public EeventRepository(GlobalTicketDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public Task<bool> IsEventNameAndDateUnique(string name, DateTime date)
        {
            var result = _dbcontext.Events.Any(x => x.Name.Equals(name) && x.Date.Date.Equals(date));
            return Task.FromResult(result);
        }
    }
}
