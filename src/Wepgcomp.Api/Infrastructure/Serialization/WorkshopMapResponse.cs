using Wepgcomp.Api.Infrastructure.Database.DataModel.Models.Workshops;
using Wepgcomp.Api.Models.Workshops;

namespace Wepgcomp.Api.Infrastructure.Serialization
{
    public static class WorkshopMapResponse
    {
        public static WorkshopResponse MapToResponse(this Workshop workshop)
        {
            return new WorkshopResponse
            {
                Id = workshop.Id,
                Title = workshop.Title,
                StartDate = workshop.StartDate,
                EndDate = workshop.EndDate
            };
        }
    }
}
