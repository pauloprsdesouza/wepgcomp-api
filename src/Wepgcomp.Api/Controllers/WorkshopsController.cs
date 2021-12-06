using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wepgcomp.Api.Infrastructure.Database;
using Wepgcomp.Api.Infrastructure.Database.DataModel.Models.Workshop;

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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            Workshop workshop = new Workshop();
            workshop.Title = "WePGCOMP 20222";
            workshop.StartDate = DateTime.Now;
            workshop.EndDate = DateTime.Now;

            _context.Add(workshop);
            await _context.SaveChangesAsync();

            return Json(Ok());
        }
    }
}
