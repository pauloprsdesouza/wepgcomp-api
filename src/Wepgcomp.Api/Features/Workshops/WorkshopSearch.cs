using Wepgcomp.Api.Infrastructure.Database;
using Wepgcomp.Api.Infrastructure.Database.DataModel.Models.Workshops;

namespace Wepgcomp.Api.Features.Workshops
{
    public class WorkshopSearch
    {
        private readonly ApiDBContext _context;

        public WorkshopSearch(ApiDBContext context)
        {
            _context = context;
        }

        public bool WorkshopNotFound { get; private set; }

        public Workshop Find(int id)
        {
            Workshop workshop = _context.Workshops.ById(id);

            WorkshopNotFound = workshop == null;

            return workshop;
        }
    }
}
