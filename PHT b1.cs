// TODO 1: Khai báo namespace
using System;

// TODO 2: Khai báo class
class Program
{
    // TODO 3: Khai báo Main method (điểm khởi đầu của chương trình)
    static void Main()
    {
        // TODO 4: In ra một thông điệp
        Console.WriteLine("Chao mung đen voi C#!");

        // TODO 5: Khai báo 3 biến và hiển thị chúng
        string ten = "Nguyen Van A";  
        int tuoi = 20;                
        double diem = 8.5;            

        Console.WriteLine("Ten: " + ten);
        Console.WriteLine("Tuoi: " + tuoi);
        Console.WriteLine("Diem: " + diem);

        // TODO 6: Sử dụng string interpolation (cách hiện đại)
        Console.WriteLine($"Thong tin: {ten}, tuoi {tuoi}, điem {diem}");
    }
}


