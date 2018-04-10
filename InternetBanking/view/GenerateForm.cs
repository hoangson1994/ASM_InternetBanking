using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking
{
    class GenerateForm
    {

        Model model = new Model();

        // Tạo form Internet Banking.
        public void InternetBanking()
        {
            Transfer();
        }

        // Tạo form Login.
        public void Login()
        {
            // cho người dùng nhập username.
            // cho người dùng nhập password.
            // gọi hàm HandleLogin(username, password); 
            // nếu hàm trả về true .....(các xử lí tiếp theo, như gọi đến hàm Menu());
            // nếu hàm trả về false - thông báo đăng nhập khoog thành công ;

        }


        // Tạo form Signup .
        public void Signup()
        {

        }

        // Tạo form Menu chính.
        public void Menu()
        {
            //1. thông tin  người dùng
            //2. truy vấn số dư
            //3. rút tiền
            //4. chuyển khoản
            //5. lịch sử giao dịch
        }

        // Tạo form thông tin người dùng.
        public void InfoUser()
        {

        }

        // Tạo form truy vấn số dư.
        public void QueryBalance()
        {

        }

        // Tạo form rút tiền.
        public void Withdrawal()
        {

        }

        // Tạo form chuyển khoản.
        public void Transfer()
        {        

        }

        // Tạo form tra cứu lịch sử giao dịch
        public void TransactionHistory()
        {

        }
    }
}
