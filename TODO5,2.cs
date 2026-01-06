using System;
using System.Text;

namespace Constructor
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }

        public Product(string productId, string productName, double price)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
        }

        public void Display()
        {
            Console.WriteLine($"Mã: {ProductId} | Tên: {ProductName} | Giá: {Price:N0} VNĐ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            //Product p1 = new Product("P01", "Laptop Dell", 15000000);
            Product p2 = new Product("P02", "Chuột không dây", 250000);
            // Sửa dòng tạo p1 thành xe hơi
            Product p1 = new Product("CAR01", "VinFast Lux A", 1200000000);

            Console.WriteLine("--- DANH SÁCH SẢN PHẨM ---");
            p1.Display();
            p2.Display();
            
            Console.ReadLine();
        }
    }
}