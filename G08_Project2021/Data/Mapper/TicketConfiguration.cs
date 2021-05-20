using G08_Project2021.Models.Domein;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace G08_Project2021.Data.Mapper
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("TICKET");
            
            builder.HasOne(t => t.Technieker).WithMany().IsRequired(true).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t => t.Klant).WithMany().IsRequired(true).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
