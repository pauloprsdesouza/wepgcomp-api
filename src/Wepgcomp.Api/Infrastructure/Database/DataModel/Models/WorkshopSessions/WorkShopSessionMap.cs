using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wepgcomp.Api.Infrastructure.Database.DataModel.Models.WorkshopSessions
{
    public static class WorkShopSessionMap
    {
        public static void Configure(this EntityTypeBuilder<WorkshopSession> workshopSession)
        {
            workshopSession.ToTable("workshop_session");

            workshopSession.HasKey(p => new { p.Id, p.IdWorkshop });

            workshopSession.Property(p => p.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

            workshopSession.Property(p => p.IdWorkshop)
                           .HasColumnName("id_workshop")
                           .ValueGeneratedOnAdd();

            workshopSession.Property(p => p.SessionDate)
                    .HasColumnName("session_date");

            workshopSession.Property(p => p.Status)
                    .HasColumnName("status");
        }
    }
}
