using System;
using Wepgcomp.Api.Infrastructure.Database.DataModel.Models.Workshops;

namespace Wepgcomp.Api.Infrastructure.Database.DataModel.Models.WorkshopSessions
{
    public class WorkshopSession
    {
        public int Id { get; set; }
        public int IdWorkshop { get; set; }
        public DateTime SessionDate { get; set; }
        public string Status { get; set; }

        public Workshop WorkShop { get; set; }
    }
}
