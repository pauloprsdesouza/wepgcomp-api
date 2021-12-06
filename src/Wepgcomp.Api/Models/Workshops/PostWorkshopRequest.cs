using System;
using System.ComponentModel.DataAnnotations;
using Wepgcomp.Api.Infrastructure.Database.DataModel.Models.Workshops;

namespace Wepgcomp.Api.Models.Workshops
{
    public class PostWorkshopRequest
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

        public Workshop ToWorkshop()
        {
            return new Workshop()
            {
                Title = Title,
                StartDate = StartDate,
                EndDate = EndDate
            };
        }
    }
}
