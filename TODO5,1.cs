using System;
using System.Text; // Thư viện để hỗ trợ gõ tiếng Việt có dấu

namespace BasicClass
{
    public class Student
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public double GPA { get; set; }

        public void Display()
        {
            Console.WriteLine($"Mã SV: {StudentId} | Tên: {Name} | Điểm GPA: {GPA}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Student sv1 = new Student();
            sv1.StudentId = "B25001";
            sv1.Name = "Nguyễn Văn An";
            sv1.GPA = 8.5;

            Student sv2 = new Student();
            sv2.StudentId = "B25002";
            sv2.Name = "Trần Thị Bích";
            sv2.GPA = 7.2;

            Student sv3 = new Student();
            sv3.StudentId = "B25003";
            sv3.Name = "Lê Văn C";
            sv3.GPA = 4.5;
            sv3.Display();

            Console.WriteLine("--- DANH SÁCH SINH VIÊN ---");
            sv1.Display();
            sv2.Display();

            Console.ReadLine();
        }
    }
}