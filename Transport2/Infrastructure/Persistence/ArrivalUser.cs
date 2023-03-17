using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ArrivalUser : IEntityTypeConfiguration<Arrival>
    {
        public void Configure(EntityTypeBuilder<Arrival> builder)
        {
            builder.HasOne<ApplicationUser>()
            .WithMany(x => x.Arrivals)
            .HasForeignKey(x => x.UserId);
        }
    }
}
