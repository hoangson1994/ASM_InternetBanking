using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking
{
    class Controller
    {
        Model model = new Model();
        User user;
        public bool HandleLogin(string username, string password)
        {
            // gọi hàm SelectByUsername(username).

            Account account = model.SelectByUsernameFromTableAccount(username);
            if (account != null)
            {
                string passwordDB = account.Password;
                string passwordLogin = MD5.CreateMD5(password + account.Salt);
                if (passwordDB.Equals(passwordLogin))
                {
                    user = model.SelectByUsernameFromTableUser(username);
                    return true;
                    
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            // nếu hàm trả về 1 user: 
            //  - so sánh password nhập vào và pass lưu trong database: == thì return true còn != return false (có muối);
            // nếu hàm trả về null thì return false(đăng nhập không thành công); 


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
