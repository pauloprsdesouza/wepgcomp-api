using System.Linq;

namespace Wepgcomp.Api.Infrastructure.Database.DataModel.Models.Workshops
{
    public static class WorkshopQuery
    {
        public static Workshop ById(this IQueryable<Workshop> workshops, int id){
            return workshops.Where(p => p.Id == id).FirstOrDefault();
        }

        public static IQueryable<Workshop> GetAll(this IQueryable<Workshop> workshops){
            return workshops;
        }
    }
}
