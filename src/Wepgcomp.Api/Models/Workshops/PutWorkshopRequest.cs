using System;
using System.ComponentModel.DataAnnotations;
using Wepgcomp.Api.Infrastructure.Database.DataModel.Models.Workshops;

namespace Wepgcomp.Api.Models.Workshops
{
    public class PutWorkshopRequest
    {
        /// <summary>
        /// The workshop's title
        /// </summary>
        /// <value></value>
        [Required, MaxLength(150)]
        public string Title { get; set; }

        /// <summary>
        /// A date and time that represents when the workshop goes to start
        /// </summary>
        /// <value></value>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// A date and time that represents when the workshop goes to finish
        /// </summary>
        /// <value></value>
        [Required]
        public DateTime EndDate { get; set; }

        public void MapTo(Workshop workshop)
        {
            workshop.Title = Title;
            workshop.StartDate = StartDate;
            workshop.EndDate = EndDate;
        }
    }
}
