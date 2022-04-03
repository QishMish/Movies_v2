using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Poco;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.PersistanceDB.Conifg
{
   
    public class MovieConfig : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            //builder.HasOne(x => x.User).WithMany(x => x.Movies);
        }
    }
}
