using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace InternetBanking
{
    class Controller
    {
        User user;
        public bool HandleLogin(string username, string password)
        {
            // gọi hàm SelectByUsername(username).
            // nếu hàm trả về 1 user: 
            //  - so sánh password nhập vào và pass lưu trong database: == thì return true còn != return false (có muối);
            // nếu hàm trả về null thì return false(đăng nhập không thành công); 

            return true;
        }

        // viết các câu lệnh xử lí phần đăng kí
        public void HandleSignup()
        {

        }

        // viết các câu lệnh xử lí phần thông tin người dùng
        public void HandleInforUser()
        {

        }

        // viết các câu lệnh xử lí phần truy vấn số dư
        public void HandleQueryBalance()
        {
            Console.WriteLine("Số tài khoản: " + user.BankId);
            Console.WriteLine("Tên: " + user.Fullname);
            Console.WriteLine("Số tiền hiện tại: " + user.Balance);
            Console.WriteLine("5 lần giao dịch gần nhất:");
            Model model = new Model();
            List<History> listHistory = model.SelectByUsernameFromTableHistory(user.BankId);
            String s = String.Format("{0,15} {1,15} {2,15} {3,15} {4,50}\n\n\n\n\n", "Mã Giao Dịch", "STK Gửi", "STK Nhận", "Số Tiền", "Nội dung");
            for (int i = 0; i < 5; i++)
                s += String.Format("{0,15} {1,15} {2,15} {3,15} {4,50:N0}\n", listHistory[i].TradingCode, listHistory[i].SendBankId, listHistory[i].ReceiveBankId, listHistory[i].Amount, listHistory[i].Content);
            Console.WriteLine(s);
        }

        // viết các câu lệnh xử lí phần rút tiền
        public void HandleWithdrawal()
        {

        }

        // viết các câu lệnh xử lí phần chuyển khoản
        public void HandleTransfers()
        {

        }

        // viết các câu lệnh xử lí phần xem lịch sử giao dịch
        public void HandleTransactionHistory()
        {

        }
    }
}
