using System.Threading.Tasks;
using Wepgcomp.Api.Infrastructure.Database;
using Wepgcomp.Api.Infrastructure.Database.DataModel.Models.Workshops;

namespace Wepgcomp.Api.Features.Workshops
{
    public class DeleteWorkshop
    {
        private readonly ApiDBContext _context;

        public DeleteWorkshop(ApiDBContext context)
        {
            _context = context;
        }

        public async Task Delete(Workshop workshop)
        {
            _context.Remove(workshop);
            await _context.SaveChangesAsync();
        }
    }
}
