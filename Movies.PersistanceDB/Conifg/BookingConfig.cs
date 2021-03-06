using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Poco;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.PersistanceDB.Conifg
{
  
    public class BookingConfig : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(x => new { x.User_id, x.Movie_id });


            builder.HasOne<ApplicationUser>(pp => pp.ApplicationUser)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(p => p.User_id);

            builder.HasOne<Movie>(pp => pp.Movie)
                  .WithMany(p => p.Booking)
                  .HasForeignKey(p => p.Movie_id);
        }
    }
}
