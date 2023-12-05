using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NikolaevNikita_KT_42_20.Models;
using NikolaevNikita_KT_42_20.Database.Helpers;

namespace NikolaevNikita_KT_42_20.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {

        private const string TableName = "Student";
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .HasKey(p => p.StudentId)
                .HasName($"pk_{TableName}_student_id");

            //для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.StudentId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.StudentId)
                .HasColumnName("student_id")
                .HasComment("Идентификатор записи студента");

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("first_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя студента");

            builder.Property(p => p.MiddleName)
                .IsRequired()
                .HasColumnName("middle_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Отчество");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("last_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия");

            builder.Property(p => p.GroupId)
               .HasColumnName("group_id")
               .HasComment("Идентификатор группы");

            builder.ToTable(TableName)
                .HasOne(p => p.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupId)
                .HasConstraintName("fk_f_group_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.GroupId, $"idx_{TableName}_fk_f_group_id");

            builder.Navigation(p => p.Group)
            .AutoInclude();




        }


    }
}

