using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoJob.Entities.Concrete;

namespace ToDoJob.DataAccess.Concrete.EntityFramework.Mapping
{
    public class RaporMap:IEntityTypeConfiguration<Rapor>
    {
        public void Configure(EntityTypeBuilder<Rapor> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Description).HasMaxLength(100);
            builder.Property(I => I.Description).HasColumnName("Description");
            builder.Property(I => I.Description).HasColumnType("ntext");

            builder.HasOne(I => I.Job).WithMany(I => I.Raporlar).HasForeignKey(I => I.JobId);
        }
    }
}
