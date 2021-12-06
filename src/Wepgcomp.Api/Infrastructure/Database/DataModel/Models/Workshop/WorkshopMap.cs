using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Wepgcomp.Api.Infrastructure.Database.DataModel.Models.Workshop
{
    public static class WorkshopMap
    {
        public static void Configure(this EntityTypeBuilder<Workshop> workshop)
        {
            workshop.ToTable("workshop");

            workshop.HasKey(p => p.Id);

            workshop.Property(p => p.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

            workshop.Property(p => p.Title)
                    .HasColumnName("title");

            workshop.Property(p => p.StartDate)
                    .HasColumnName("start_date");

            workshop.Property(p => p.EndDate)
                    .HasColumnName("end_date");
        }
    }
}
