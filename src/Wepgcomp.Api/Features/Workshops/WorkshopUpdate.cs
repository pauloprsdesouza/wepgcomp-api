using System.Threading.Tasks;
using Wepgcomp.Api.Infrastructure.Database;
using Wepgcomp.Api.Infrastructure.Database.DataModel.Models.Workshops;

namespace Wepgcomp.Api.Features.Workshops
{
    public class WorkshopUpdate
    {
        private readonly ApiDBContext _context;

        public WorkshopUpdate(ApiDBContext context)
        {
            _context = context;
        }

        public async Task Update(Workshop workshop)
        {
            _context.Update(workshop);
            await _context.SaveChangesAsync();
        }
    }
}
