using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.DataAccess.Concrete.EntityFramework.Mapping
{
    public class JobMap : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Name).HasMaxLength(200);
            builder.Property(I => I.Description).HasColumnType("ntext");

            builder.HasOne(I => I.Aciliyet).WithMany(I => I.Jobs).HasForeignKey(I => I.AciliyetId);
        }
    
    }
}
