using System.Threading.Tasks;
using Wepgcomp.Api.Infrastructure.Database;
using Wepgcomp.Api.Infrastructure.Database.DataModel.Models.Workshops;

namespace Wepgcomp.Api.Features.Workshops
{
    public class CreateWorkshop
    {
        public readonly ApiDBContext _context;

        public CreateWorkshop(ApiDBContext context)
        {
            _context = context;
        }

        public async Task Save(Workshop workshop)
        {
            _context.Add(workshop);
            await _context.SaveChangesAsync();
        }
    }
}
