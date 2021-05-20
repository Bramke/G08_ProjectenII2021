using G08_Project2021.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G08_Project2021.Data.Mapper
{
    public class GebruikerConfiguration : IEntityTypeConfiguration<Gebruiker>
    {
        public void Configure(EntityTypeBuilder<Gebruiker> builder)
        {
            builder.ToTable("GEBRUIKER");
            builder.HasKey(g => g.Id).HasName("GebruikerId");
            builder.Property(g => g.Bedrijf).IsRequired();
            builder.Property(g => g.Gebruikersnaam).IsRequired();
            builder.Property(g => g.Naam).IsRequired();
            builder.Property(g => g.Rol).IsRequired();
            builder.Property(g => g.Status).IsRequired();
            builder.Property(g => g.Voornaam).IsRequired();
            builder.Property(g => g.Email).IsRequired();
        }
    }
}
