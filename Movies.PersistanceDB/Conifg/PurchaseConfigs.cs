using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Poco;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.PersistanceDB.Conifg
{
    public class PurchaseConfigs : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(x => new { x.User_id, x.Movie_id });


            builder.HasOne<ApplicationUser>(pp => pp.ApplicationUser)
                    .WithMany(p => p.Purchase)
                    .HasForeignKey(p => p.User_id);

            builder.HasOne<Movie>(pp => pp.Movie)
                  .WithMany(p => p.Purchase)
                  .HasForeignKey(p => p.Movie_id);
        }
    }
}
