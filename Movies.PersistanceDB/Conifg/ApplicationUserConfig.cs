using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Poco;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.PersistanceDB.Conifg
{
    public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasMany(x => x.Movies).WithOne(x => x.User);
            //builder.HasMany(x => x.Purchase).WithMany();
        }
    }
}
