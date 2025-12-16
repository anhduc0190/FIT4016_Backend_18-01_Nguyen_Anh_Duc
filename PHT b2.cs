using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("===Chuong trinh xep loai sinh vien===\n");

        string hovaten = "Nguyen Anh Duc";              
        double diem = 8.5;            

        Console.WriteLine($"Hoten:  : {hovaten}");
        Console.WriteLine($"Diem:  : {diem}");

         string xeploai;
        if (diem >= 8.5)
        {
            xeploai = "Gioi";
        }
        else if (diem >= 7.0)
        {
            xeploai = "Kha";
        }
        else if (diem >= 5.5)
        {
            xeploai = "Trung binh";
        }
        else
        {
            xeploai = "Yeu";
        }

        Console.WriteLine($"Xep loai: {xeploai}");
        string[] tensv =  {"Nguyen Thi A","Tran Duy B","Tran Van C"}; 
        double[] Diem = {9, 4, 7};
        Console.WriteLine("Bang Diem");
        for(int i = 0; i < tensv.Length; i++)
        {
            //todo5:
            Console.WriteLine("Ho va ten: "+tensv[i]);
            Console.WriteLine("Diem: "+Diem[i]);
            if(Diem[i]>= 8.5)
                Console.WriteLine("Gioi");
            else if(Diem[i]>=7)
                Console.WriteLine("Kha");
            else if(Diem[i]>=5.5)
                Console.WriteLine("Trung Binh");
            else 
                Console.WriteLine("Yeu");
        }
        //todo6:
        double tongdiem = 0;
        int j=0;
        while (j < Diem.Length)
        {
            tongdiem+=Diem[j];
            j++;
        }
        Console.WriteLine("Tong diem: "+tongdiem);
        Console.WriteLine("Diem trung binh: "+(tongdiem/Diem.Length));
    }
}

    
    
