using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.FluentApiConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(k => k.ID);

            builder.Property(k => k.ID)
                .HasColumnType("int")
                .HasColumnOrder(1)
                .HasColumnName("Identity");

            builder.Property(k => k.Name)
                .HasColumnType("string")
                .HasColumnOrder(2)
                .HasColumnName("Name");

            builder.Property(k => k.FamilyName)
                .HasColumnType("string")
                .HasColumnOrder(3)
                .HasColumnName("FamilyName");

            builder.Property(k => k.UserName)
                .HasColumnType("string")
                .HasColumnOrder(4)
                .HasColumnName("UserName");

            builder.Property(k => k.Tel)
                .HasColumnType("string")
                .HasColumnOrder(5)
                .HasColumnName("tel");

            builder.Property(k => k.nationalCode)
                .HasColumnType("string")
                .HasColumnOrder(6)
                .HasColumnName("nationalCode");

            builder.Property(k => k.BirthDate)
                .HasColumnType("string")
                .HasColumnOrder(7)
                .HasColumnName("BirthDate");
        }
    }
}
