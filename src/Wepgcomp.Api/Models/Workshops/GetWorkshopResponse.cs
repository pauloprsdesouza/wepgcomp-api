using System.Collections.Generic;

namespace Wepgcomp.Api.Models.Workshops
{
    public class GetWorkshopResponse
    {
        /// <summary>
        /// Registered workshops
        /// </summary>
        /// <value></value>
        public IEnumerable<WorkshopResponse> Workshops { get; set; }
    }
}
