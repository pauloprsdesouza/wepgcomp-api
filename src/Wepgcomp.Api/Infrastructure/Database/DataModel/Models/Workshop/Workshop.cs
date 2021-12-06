using System;

namespace Wepgcomp.Api.Infrastructure.Database.DataModel.Models.Workshop
{
    public class Workshop
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
