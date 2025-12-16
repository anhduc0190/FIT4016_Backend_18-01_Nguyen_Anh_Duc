using System;

// TODO 1: Viết hàm XepLoai
string XepLoai(double diem)
{
    if (diem >= 8.5)
    {
        return "Gioi";
    }
    else if (diem >= 7.0)
    {
        return "Kha";
    }
    else if (diem >= 5.5)
    {
        return "Trung binh";
    }
    else
    {
        return "Yeu";
    }
}

// TODO 2: Viết hàm TinhTrungBinh
double TinhTrungBinh(double[] diem)
{
    double tong = 0;
    for (int i = 0; i < diem.Length; i++)
    {
        tong += diem[i];
    }
    return tong / diem.Length;
}

// TODO 3: Viết hàm InBangDiem
void InBangDiem(string[] ten, double[] diem)
{
    Console.WriteLine("{0,-20} | {1,-5} | {2,-10}", "Ho ten", "Điem", "Xep loai");
    Console.WriteLine(new string('-', 45));

    for (int i = 0; i < ten.Length; i++)
    {
        string ketQuaXepLoai = XepLoai(diem[i]);

        Console.WriteLine("{0,-20} | {1,-5} | {2,-10}", ten[i], diem[i], ketQuaXepLoai);
    }
}

string[] tenSV = { "Nguyen Van A", "Tran Thi B", "Le Van C" };
double[] diemSV = { 8.5, 7.2, 5.8 };

Console.WriteLine("=== Chuong trinh Quan ly Sinh vien ===\n");

// TODO 4: Gọi hàm InBangDiem để in bảng điểm
InBangDiem(tenSV, diemSV);

// TODO 5: Gọi hàm TinhTrungBinh và in kết quả
double trungBinh = TinhTrungBinh(diemSV);
Console.WriteLine($"\n---------------------------------------------");
Console.WriteLine($"Diem trung binh lop: {trungBinh:F2}");
Console.ReadLine();
