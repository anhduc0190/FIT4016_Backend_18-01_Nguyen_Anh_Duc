using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== SCHOOL MANAGEMENT SYSTEM ===");
                Console.WriteLine("1. Create new student");
                Console.WriteLine("2. Read students list");
                Console.WriteLine("3. Update student");
                Console.WriteLine("4. Delete student");
                Console.WriteLine("5. Exit");
                Console.Write("\nSelect option (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateStudent();
                        break;
                    case "2":
                        ReadStudents();
                        break;
                    case "3":
                        UpdateStudent();
                        break;
                    case "4":
                        DeleteStudent();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // CREATE student (1.5 điểm)
        static void CreateStudent()
        {
            Console.Clear();
            Console.WriteLine("=== CREATE NEW STUDENT ===\n");

            try
            {
                using (var context = new SchoolDbContext())
                {
                    var student = new Student();

                    // Input form với dữ liệu học sinh
                    Console.Write("Enter Student ID (5-20 characters): ");
                    student.StudentId = Console.ReadLine();

                    Console.Write("Enter Full Name (2-100 characters): ");
                    student.FullName = Console.ReadLine();

                    Console.Write("Enter Email: ");
                    student.Email = Console.ReadLine();

                    Console.Write("Enter Phone (10-11 digits): ");
                    student.Phone = Console.ReadLine();

                    // Hiển thị danh sách trường để chọn
                    Console.WriteLine("\nAvailable Schools:");
                    var schools = context.Schools.ToList();
                    foreach (var school in schools)
                    {
                        Console.WriteLine($"{school.Id}. {school.Name}");
                    }

                    Console.Write("\nSelect School ID: ");
                    student.SchoolId = int.Parse(Console.ReadLine());

                    // Validate input sử dụng Data Annotations
                    var validationContext = new ValidationContext(student);
                    var validationResults = new List<ValidationResult>();

                    bool isValid = Validator.TryValidateObject(
                        student, validationContext, validationResults, true);

                    if (!isValid)
                    {
                        Console.WriteLine("\nValidation errors:");
                        foreach (var error in validationResults)
                        {
                            Console.WriteLine($"- {error.ErrorMessage}");
                        }
                        return;
                    }

                    // Thêm student sử dụng Entity Framework
                    context.Students.Add(student);
                    context.SaveChanges();

                    Console.WriteLine("\nStudent created successfully!");
                }
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"\nDatabase error: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }

        // READ students với phân trang (2 điểm)
        static void ReadStudents()
        {
            Console.Clear();
            Console.WriteLine("=== STUDENTS LIST ===\n");

            try
            {
                using (var context = new SchoolDbContext())
                {
                    const int pageSize = 10;
                    int currentPage = 1;

                    while (true)
                    {
                        // Lấy students với phân trang (10 items/page)
                        var students = context.Students
                            .Include(s => s.School)  // Join với School để hiển thị tên trường
                            .OrderBy(s => s.Id)
                            .Skip((currentPage - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

                        if (!students.Any())
                        {
                            Console.WriteLine("No students found.");
                            break;
                        }

                        // Hiển thị thông tin students dạng bảng
                        Console.WriteLine($"Page {currentPage}\n");
                        Console.WriteLine(String.Format("{0,-5} {1,-15} {2,-25} {3,-30} {4,-15} {5,-30}",
                            "ID", "Student ID", "Full Name", "Email", "Phone", "School"));
                        Console.WriteLine(new string('-', 130));

                        foreach (var student in students)
                        {
                            Console.WriteLine(String.Format("{0,-5} {1,-15} {2,-25} {3,-30} {4,-15} {5,-30}",
                                student.Id,
                                student.StudentId,
                                student.FullName,
                                student.Email,
                                student.Phone ?? "N/A",
                                student.School.Name));
                        }

                        int totalCount = context.Students.Count();
                        int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                        Console.WriteLine($"\nShowing page {currentPage} of {totalPages}");
                        Console.WriteLine("\nN: Next page | P: Previous page | Q: Quit");
                        Console.Write("Your choice: ");

                        string choice = Console.ReadLine()?.ToUpper();

                        if (choice == "N" && currentPage < totalPages)
                        {
                            currentPage++;
                            Console.Clear();
                            Console.WriteLine("=== STUDENTS LIST ===\n");
                        }
                        else if (choice == "P" && currentPage > 1)
                        {
                            currentPage--;
                            Console.Clear();
                            Console.WriteLine("=== STUDENTS LIST ===\n");
                        }
                        else if (choice == "Q")
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }

        // UPDATE student (1.5 điểm)
        static void UpdateStudent()
        {
            Console.Clear();
            Console.WriteLine("=== UPDATE STUDENT ===\n");

            try
            {
                using (var context = new SchoolDbContext())
                {
                    Console.Write("Enter Student ID to update: ");
                    int id = int.Parse(Console.ReadLine());

                    var student = context.Students
                        .Include(s => s.School)
                        .FirstOrDefault(s => s.Id == id);

                    if (student == null)
                    {
                        Console.WriteLine("Student not found!");
                        return;
                    }

                    // Hiển thị thông tin hiện tại
                    Console.WriteLine($"\nCurrent information:");
                    Console.WriteLine($"Student ID: {student.StudentId}");
                    Console.WriteLine($"Full Name: {student.FullName}");
                    Console.WriteLine($"Email: {student.Email}");
                    Console.WriteLine($"Phone: {student.Phone}");
                    Console.WriteLine($"School: {student.School.Name}");

                    // Form cập nhật với dữ liệu hiện tại
                    Console.WriteLine("\nEnter new information (press Enter to keep current):\n");

                    Console.Write($"Full Name [{student.FullName}]: ");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newName))
                        student.FullName = newName;

                    Console.Write($"Email [{student.Email}]: ");
                    string newEmail = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newEmail))
                        student.Email = newEmail;

                    Console.Write($"Phone [{student.Phone}]: ");
                    string newPhone = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newPhone))
                        student.Phone = newPhone;

                    Console.WriteLine("\nAvailable Schools:");
                    var schools = context.Schools.ToList();
                    foreach (var school in schools)
                    {
                        Console.WriteLine($"{school.Id}. {school.Name}");
                    }

                    Console.Write($"\nSchool ID [{student.SchoolId}]: ");
                    string newSchoolId = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newSchoolId))
                        student.SchoolId = int.Parse(newSchoolId);

                    student.UpdatedAt = DateTime.Now;

                    // Validate input trước khi update
                    var validationContext = new ValidationContext(student);
                    var validationResults = new List<ValidationResult>();

                    bool isValid = Validator.TryValidateObject(
                        student, validationContext, validationResults, true);

                    if (!isValid)
                    {
                        Console.WriteLine("\nValidation errors:");
                        foreach (var error in validationResults)
                        {
                            Console.WriteLine($"- {error.ErrorMessage}");
                        }
                        return;
                    }

                    // Update sử dụng Entity Framework
                    context.Students.Update(student);
                    context.SaveChanges();

                    Console.WriteLine("\nStudent updated successfully!");
                }
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"\nDatabase error: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }

        // DELETE student (1 điểm)
        static void DeleteStudent()
        {
            Console.Clear();
            Console.WriteLine("=== DELETE STUDENT ===\n");

            try
            {
                using (var context = new SchoolDbContext())
                {
                    Console.Write("Enter Student ID to delete: ");
                    int id = int.Parse(Console.ReadLine());

                    var student = context.Students
                        .Include(s => s.School)
                        .FirstOrDefault(s => s.Id == id);

                    if (student == null)
                    {
                        Console.WriteLine("Student not found!");
                        return;
                    }

                    // Hiển thị thông tin student trước khi xóa
                    Console.WriteLine($"\nStudent information:");
                    Console.WriteLine($"Student ID: {student.StudentId}");
                    Console.WriteLine($"Full Name: {student.FullName}");
                    Console.WriteLine($"Email: {student.Email}");
                    Console.WriteLine($"School: {student.School.Name}");

                    // Hộp thoại xác nhận trước khi xóa
                    Console.Write("\nAre you sure you want to delete this student? (Y/N): ");
                    string confirm = Console.ReadLine()?.ToUpper();

                    if (confirm == "Y")
                    {
                        // Xóa student sử dụng Entity Framework
                        context.Students.Remove(student);
                        context.SaveChanges();

                        Console.WriteLine("\nStudent deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("\nDeletion cancelled.");
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"\nDatabase error: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }
    }
}
