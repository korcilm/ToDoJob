using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.DataAccess.Concrete.EntityFramework.Mapping
{
    public class AciliyetMap:IEntityTypeConfiguration<Aciliyet>
    {
        public void Configure(EntityTypeBuilder<Aciliyet> builder)
        {
            builder.Property(I => I.Description).HasMaxLength(100);
        }
    }
}
