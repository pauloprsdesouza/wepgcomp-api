using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wepgcomp.Api.Infrastructure.Database.DataModel.Models.Workshops
{
    public class WorkshopNotFoundError : IActionResult
    {
        public WorkshopNotFoundError() { }

        public WorkshopNotFoundError(int workshopId)
        {
            WorkshopId = workshopId;
        }

        private int WorkshopId { get; set; }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var jsonResult = new JsonResult(this);
            jsonResult.StatusCode = StatusCodes.Status404NotFound;

            await jsonResult.ExecuteResultAsync(context);
        }
    }
}
