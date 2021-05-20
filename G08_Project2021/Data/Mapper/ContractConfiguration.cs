using G08_Project2021.Models;
using G08_Project2021.Models.Domein;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G08_Project2021.Data.Mapper
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("CONTRACT");
            builder.HasKey(g => g.Id);
            builder.HasOne(g => g.Gebruiker).WithMany().IsRequired(true).OnDelete(DeleteBehavior.Restrict);
        }
    }
}