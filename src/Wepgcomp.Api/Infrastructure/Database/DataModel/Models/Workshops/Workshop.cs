using System;
using System.Collections.Generic;
using Wepgcomp.Api.Infrastructure.Database.DataModel.Models.WorkshopSessions;

namespace Wepgcomp.Api.Infrastructure.Database.DataModel.Models.Workshops
{
    public class Workshop
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<WorkshopSession> Sessions { get; set; }
    }
}
