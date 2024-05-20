using InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialMigration.Data.Configuration
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.FName)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            builder.Property(x => x.LName)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            builder.HasOne(x => x.Office)
                   .WithOne(x => x.Instructor)
                   .HasForeignKey<Instructor>(x => x.OfficeId)
                   .IsRequired(false);

            builder.ToTable("Instructors");


            builder.HasData(LoadInstructors());

        }

        private List<Instructor> LoadInstructors()
        {
            //INSERT INTO Instructors(Id, Name, OfficeId) VALUES(1, 'Ahmed Abdullah', 1);
            //INSERT INTO Instructors(Id, Name, OfficeId) VALUES(2, 'Yasmeen Mohammed', 2);
            //INSERT INTO Instructors(Id, Name, OfficeId) VALUES(3, 'Khalid Hassan', 3);
            //INSERT INTO Instructors(Id, Name, OfficeId) VALUES(4, 'Nadia Ali', 4);
            //INSERT INTO Instructors(Id, Name, OfficeId) VALUES(5, 'Omar Ibrahim', 5);

            return new List<Instructor>
            {
                new Instructor {Id = 1 , FName = "Ahmed", LName= "Abdullah", OfficeId=1},
                new Instructor {Id = 2 , FName = "Yasmeen", LName= "Mohammed" , OfficeId=2},
                new Instructor {Id = 3 , FName = "Khalid", LName= "Hassan", OfficeId = 3},
                new Instructor {Id = 4 , FName = "Nadia", LName= "Ali", OfficeId = 4},
                new Instructor {Id = 5 , FName = "Omar", LName= "Ibrahim", OfficeId = 5},
            };


        }
    }

}
