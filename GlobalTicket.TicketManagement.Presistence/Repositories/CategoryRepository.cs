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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly GlobalTicketDbContext _dbcontext;

        public CategoryRepository(GlobalTicketDbContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> CategoryNameExist(string name)
        {
            var category =  await _dbcontext.Categories.FindAsync(name);
             
            return category != null;
        }

        public async Task<List<Category>> GetCategoriesWithEvents(bool InclusePassedEevnts)
        {
            if (InclusePassedEevnts)
                return await _dbcontext.Categories.Include(x => x.Events).ToListAsync();
        
            else
                return await _dbcontext.Categories.ToListAsync();

        }
    }
}
