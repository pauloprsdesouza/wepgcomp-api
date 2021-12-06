using System.Linq;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wepgcomp.Api.Features.Workshops;
using Wepgcomp.Api.Infrastructure.Database;
using Wepgcomp.Api.Infrastructure.Database.DataModel.Models.Workshops;
using Wepgcomp.Api.Infrastructure.Serialization;
using Wepgcomp.Api.Models.Workshops;

namespace Wepgcomp.Api.Controllers
{
    [Route("workshops")]
    public class WorkshopsController : Controller
    {
        private readonly ApiDBContext _context;
        public WorkshopsController(ApiDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get workshops
        /// </summary>
        /// <remarks>
        /// Registered workshops.
        /// </remarks>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(WorkshopResponse), StatusCodes.Status200OK)]
        public IActionResult List()
        {
            ICollection<Workshop> workshops = _context.Workshops.GetAll().ToList();

            return Ok(new GetWorkshopResponse
            {
                Workshops = workshops.Select(workshop => workshop.MapToResponse())
            });
        }

        /// <summary>
        /// Create a workshop
        /// </summary>
        /// <param name="request"></param>
        /// <returns>
        /// Create a workshop to allow adding sessions
        /// </returns>
        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(WorkshopResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] PostWorkshopRequest request)
        {
            var createWorkshop = new CreateWorkshop(_context);
            var workshop = request.ToWorkshop();

            await createWorkshop.Save(workshop);

            return Ok(workshop.MapToResponse());
        }

        /// <summary>
        /// Find a workshop
        /// </summary>
        /// <remarks>
        /// Find a workshop by Id.
        /// </remarks>
        /// <param name="workshopId" example="1">Workshop's ID</param>
        [HttpGet, Route("{workshopId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(WorkshopResponse), StatusCodes.Status200OK)]
        public IActionResult Find([FromRoute] int workshopId)
        {
            var workshopSearch = new WorkshopSearch(_context);
            var workshop = workshopSearch.Find(workshopId);

            if (workshopSearch.WorkshopNotFound)
            {
                return NotFound(new WorkshopNotFoundError(workshopId));
            }

            return Ok(workshop.MapToResponse());
        }

        /// <summary>
        /// Update a workshop
        /// </summary>
        /// <remarks>
        /// Update a created previously workshop.
        /// </remarks>
        /// <param name="workshopId" example="1">Workshop's ID</param>
        /// <param name="request">Workshop's content</param>
        [HttpPut, Route("{workshopId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(WorkshopResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(WorkshopNotFoundError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Update([FromRoute] int workshopId, [FromBody] PutWorkshopRequest request)
        {
            var workshopSearch = new WorkshopSearch(_context);
            var workshop = workshopSearch.Find(workshopId);

            if (workshopSearch.WorkshopNotFound)
            {
                return NotFound(new WorkshopNotFoundError(workshopId));
            }

            request.MapTo(workshop);

            var workshopUpdate = new WorkshopUpdate(_context);
            await workshopUpdate.Update(workshop);

            return Ok(workshop.MapToResponse());
        }

        /// <summary>
        /// Delete a workshop
        /// </summary>
        /// <remarks>
        /// Delete a created previously workshop.
        /// </remarks>
        /// <param name="workshopId">Workshop's Id</param>
        [HttpDelete, Route("{workshopId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(WorkshopResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(WorkshopNotFoundError), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete([FromRoute] int workshopId)
        {
            var workshopSearch = new WorkshopSearch(_context);
            var workshop = workshopSearch.Find(workshopId);

            if (workshopSearch.WorkshopNotFound)
            {
                return NotFound(new WorkshopNotFoundError(workshopId));
            }

            var deleteWorkshop = new DeleteWorkshop(_context);
            await deleteWorkshop.Delete(workshop);

            return Json(Ok(workshop.MapToResponse()));
        }
    }
}
