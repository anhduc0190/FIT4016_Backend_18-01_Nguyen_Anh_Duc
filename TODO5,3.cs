using System;
using System.Text;

namespace Encapsulation
{
        public class BankAccount
    {
        private double _balance = 0;

        public double Balance
        {
            get { return _balance; }
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                _balance += amount; 
                Console.WriteLine($"[Giao dịch] Nạp vào: {amount:N0} đ. (Thành công)");
            }
            else
            {
                Console.WriteLine("[Lỗi] Số tiền nạp phải lớn hơn 0.");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > _balance)
            {
                Console.WriteLine($"[Lỗi] Rút {amount:N0} đ thất bại. Số dư hiện tại chỉ có {_balance:N0} đ.");
            }
            else if (amount <= 0)
            {
                 Console.WriteLine("[Lỗi] Số tiền rút không hợp lệ.");
            }
            else
            {
                _balance -= amount; 
                Console.WriteLine($"[Giao dịch] Rút ra: {amount:N0} đ. (Thành công)");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            BankAccount myAcc = new BankAccount();

            Console.WriteLine($"Số dư ban đầu: {myAcc.Balance:N0} đ");

            myAcc.Deposit(5000000); 

            myAcc.Withdraw(200000);

            myAcc.Withdraw(10000000);

            Console.WriteLine($"\n--- TỔNG KẾT SỐ DƯ: {myAcc.Balance:N0} đ ---");
            Console.ReadLine();

            Console.WriteLine("--- Test bảo mật ---");
            myAcc.Withdraw(-500000);
        }
    }
    
}