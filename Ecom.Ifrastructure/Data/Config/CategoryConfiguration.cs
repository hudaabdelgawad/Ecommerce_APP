using Ecom.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Data.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(30);
            builder.HasData(

                new Category { Id = 1, Name = "cat1", Description = "category one" },
                new Category { Id = 2, Name = "cat2", Description = "category two" },
               new Category { Id = 3, Name = "cat3", Description = "category third" }




                );
        }
    }
}
