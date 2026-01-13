using Microsoft.EntityFrameworkCore;
using System;

namespace SchoolManagement
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connection string cho SQL Server LocalDB
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=SchoolManagementDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Định nghĩa datetime cố định để seed data
            var createdAt = new DateTime(2026, 1, 13, 10, 0, 0);
            var updatedAt = new DateTime(2026, 1, 13, 10, 0, 0);

            // Configure Primary Keys
            modelBuilder.Entity<School>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Student>()
                .HasKey(s => s.Id);

            // Configure unique constraints
            modelBuilder.Entity<School>()
                .HasIndex(s => s.Name)
                .IsUnique();

            modelBuilder.Entity<Student>()
                .HasIndex(s => s.StudentId)
                .IsUnique();

            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Email)
                .IsUnique();

            // Configure 1-to-many relationship with Foreign Key
            modelBuilder.Entity<Student>()
                .HasOne(s => s.School)
                .WithMany(sc => sc.Students)
                .HasForeignKey(s => s.SchoolId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed data cho Schools (tối thiểu 10 bản ghi)
            modelBuilder.Entity<School>().HasData(
                new School { Id = 1, Name = "Harvard University", Principal = "John Smith", Address = "Cambridge, MA", CreatedAt = createdAt, UpdatedAt = updatedAt },
                new School { Id = 2, Name = "Stanford University", Principal = "Mary Johnson", Address = "Stanford, CA", CreatedAt = createdAt, UpdatedAt = updatedAt },
                new School { Id = 3, Name = "MIT", Principal = "Robert Brown", Address = "Cambridge, MA", CreatedAt = createdAt, UpdatedAt = updatedAt },
                new School { Id = 4, Name = "Oxford University", Principal = "Emily Davis", Address = "Oxford, UK", CreatedAt = createdAt, UpdatedAt = updatedAt },
                new School { Id = 5, Name = "Cambridge University", Principal = "Michael Wilson", Address = "Cambridge, UK", CreatedAt = createdAt, UpdatedAt = updatedAt },
                new School { Id = 6, Name = "Yale University", Principal = "Sarah Miller", Address = "New Haven, CT", CreatedAt = createdAt, UpdatedAt = updatedAt },
                new School { Id = 7, Name = "Princeton University", Principal = "David Garcia", Address = "Princeton, NJ", CreatedAt = createdAt, UpdatedAt = updatedAt },
                new School { Id = 8, Name = "Columbia University", Principal = "Jennifer Martinez", Address = "New York, NY", CreatedAt = createdAt, UpdatedAt = updatedAt },
                new School { Id = 9, Name = "UC Berkeley", Principal = "James Anderson", Address = "Berkeley, CA", CreatedAt = createdAt, UpdatedAt = updatedAt },
                new School { Id = 10, Name = "Caltech", Principal = "Patricia Taylor", Address = "Pasadena, CA", CreatedAt = createdAt, UpdatedAt = updatedAt }
            );

            // Seed data cho Students (tối thiểu 20 bản ghi)
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, StudentId = "STU001", FullName = "Alice Walker", Email = "alice.walker@email.com", Phone = "1234567890", SchoolId = 1, CreatedAt = createdAt, UpdatedAt = updatedAt },
                new Student { Id = 2, StudentId = "STU002", FullName = "Bob Martin", Email = "bob.martin@email.com", Phone = "2345678901", SchoolId = 1, CreatedAt = createdAt, UpdatedAt = updatedAt },
                new Student { Id = 3, StudentId = "STU003", FullName = "Carol White", Email = "carol.white@email.com", Phone = "3456789012", SchoolId = 2, CreatedAt = createdAt, UpdatedAt = updatedAt },
                new Student { Id = 4, StudentId = "STU004", FullName = "Daniel Harris", Email = "daniel.harris@email.com", Phone = "4567890123", SchoolId = 2, CreatedAt = createdAt, UpdatedAt = updatedAt },
                new Student { Id = 5, StudentId = "STU005", FullName = "Emma Clark", Email = "emma.clark@email.com", Phone = "5678901234", SchoolId = 3, CreatedAt = createdAt, UpdatedAt = updatedAt },
                new Student { Id = 6, StudentId = "STU006", FullName = "Frank Lewis", Email = "frank.lewis@email.com", Phone = "6789012345", SchoolId = 3, CreatedAt = createdAt, UpdatedAt = updatedAt },
                new Student { Id = 7, StudentId = "STU007", FullName = "Grace Lee", Email = "grace.lee@email.com", Phone = "7890123456", SchoolId = 4, CreatedAt = createdAt, UpdatedAt = updatedAt },
                new Student { Id = 8, StudentId = "STU008", FullName = "Henry King", Email = "henry.king@email.com", Phone = "8901234567", SchoolId = 4, CreatedAt = createdAt, UpdatedAt = updatedAt },
                new Student { Id = 9, StudentId = "STU009", FullName = "Iris Moore", Email = "iris.moore@email.com", Phone = "9012345678", SchoolId = 5, CreatedAt = createdAt, UpdatedAt = updatedAt },
                new Student { Id = 10, StudentId = "STU010", FullName = "Jack Scott", Email = "jack.scott@email.com", Phone = "1122334455", SchoolId = 5, CreatedAt = createdAt, UpdatedAt = updatedAt },
                new Student { Id = 11, StudentId = "STU011", FullName = "Karen Young", Email = "karen.young@email.com", Phone = "2233445566", SchoolId = 6, CreatedAt = createdAt, UpdatedAt = updatedAt },
                new Student { Id = 12, StudentId = "STU012", FullName = "Leo Allen", Email = "leo.allen@email.com", Phone = "3344556677", SchoolId = 6, CreatedAt = createdAt, UpdatedAt = updatedAt },
                new Student { Id = 13, StudentId = "STU013", FullName = "Mia Hall", Email = "mia.hall@email.com", Phone = "4455667788", SchoolId = 7, CreatedAt = createdAt, UpdatedAt = updatedAt },
                new Student { Id = 14, StudentId = "STU014", FullName = "Noah Adams", Email = "noah.adams@email.com", Phone = "5566778899", SchoolId = 7, CreatedAt = createdAt, UpdatedAt = updatedAt },
                new Student { Id = 15, StudentId = "STU015", FullName = "Olivia Baker", Email = "olivia.baker@email.com", Phone = "6677889900", SchoolId = 8, CreatedAt = createdAt, UpdatedAt = updatedAt },
                new Student { Id = 16, StudentId = "STU016", FullName = "Paul Carter", Email = "paul.carter@email.com", Phone = "7788990011", SchoolId = 8, CreatedAt = createdAt, UpdatedAt = updatedAt },
                new Student { Id = 17, StudentId = "STU017", FullName = "Quinn Nelson", Email = "quinn.nelson@email.com", Phone = "8899001122", SchoolId = 9, CreatedAt = createdAt, UpdatedAt = updatedAt },
                new Student { Id = 18, StudentId = "STU018", FullName = "Rachel Green", Email = "rachel.green@email.com", Phone = "9900112233", SchoolId = 9, CreatedAt = createdAt, UpdatedAt = updatedAt },
                new Student { Id = 19, StudentId = "STU019", FullName = "Sam Turner", Email = "sam.turner@email.com", Phone = "1011121314", SchoolId = 10, CreatedAt = createdAt, UpdatedAt = updatedAt },
                new Student { Id = 20, StudentId = "STU020", FullName = "Tina Phillips", Email = "tina.phillips@email.com", Phone = "1112131415", SchoolId = 10, CreatedAt = createdAt, UpdatedAt = updatedAt }
            );
        }
    }
}
