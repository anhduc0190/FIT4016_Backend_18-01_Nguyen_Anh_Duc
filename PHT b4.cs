using System;
using System.Text;

// TODO 1: Định nghĩa Lớp SinhVien
class SinhVien
{
    // TODO 2: Khai báo các properties (thuộc tính) public
    public string HoTen { get; set; }
    public int Tuoi { get; set; }
    public double Diem { get; set; }

    // TODO 3: Viết Constructor (hàm khởi tạo)
    public SinhVien(string hoTen, int tuoi, double diem)
    {
        // Gán giá trị tham số truyền vào cho các thuộc tính của lớp
        HoTen = hoTen;
        Tuoi = tuoi;
        Diem = diem;
    }

    // TODO 4: Viết Method XepLoai() để trả về xếp loại
    public string XepLoai()
    {
        if (Diem >= 8.0)
        {
            return "Giỏi";
        }
        else if (Diem >= 6.5)
        {
            return "Khá";
        }
        else if (Diem >= 5.0)
        {
            return "Trung bình";
        }
        else
        {
            return "Yếu";
        }
    }

    // TODO 5: Viết Method HienThiThongTin() để in thông tin sinh viên
    public void HienThiThongTin()
    {
        Console.WriteLine($"Tên: {HoTen}, Tuổi: {Tuoi}, Điểm: {Diem}, Xếp loại: {XepLoai()}");
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("=== Quản lý Sinh viên ===\n");

        // TODO 6: Tạo các đối tượng SinhVien (Instantiate objects)
        SinhVien sv1 = new SinhVien("Nguyễn Văn A", 20, 8.5);
        SinhVien sv2 = new SinhVien("Trần Thị B", 21, 7.2);
        SinhVien sv3 = new SinhVien("Lê Văn C", 19, 5.8);

        // TODO 7: Gọi method HienThiThongTin() để in thông tin
        sv1.HienThiThongTin();
        sv2.HienThiThongTin();
        sv3.HienThiThongTin();

        // TODO 8: (Tùy chọn) Tính trung bình điểm của 3 sinh viên
        double diemTB = (sv1.Diem + sv2.Diem + sv3.Diem) / 3;
        
        Console.WriteLine($"\nĐiểm trung bình lớp: {diemTB:F2}");
        
        Console.ReadLine();
    }
}