using System;
using System.ComponentModel.DataAnnotations;

namespace Wepgcomp.Api.Models.Workshops
{
    public class WorkshopResponse
    {
        /// <summary>
        /// Workshop's identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The workshop's title.
        /// </summary>
        /// <value></value>
        [Required, MaxLength(150)]
        public string Title { get; set; }

        /// <summary>
        /// A date and time that represents when the workshop goes to start.
        /// </summary>
        /// <value></value>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// A date and time that represents when the workshop goes to finish.
        /// </summary>
        /// <value></value>
        [Required]
        public DateTime EndDate { get; set; }
    }
}
