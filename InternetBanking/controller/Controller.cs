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

        LongTime longTime = new LongTime();

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
    
        // viết các câu lệnh xử lí kiểm trả username tồn tại.
        public bool CheckUsernameExist(string username)
        {
            Account account = model.SelectByUsernameFromTableAccount(username);
            if (account != null)
            {
                Console.WriteLine("Username has Exist. Please Re-Enter username.");
                return true;
            }
            return false;
        }

        // viết các câu lệnh xử lí phần đăng kí
        public bool HandleSignup(Account account, User user)
        {
            if (model.InsertToTableAccount(account) == true && model.InsertToTableUsers(user) == true)
            {
                Console.WriteLine("Sign Up Success");
                return true;
            }
            else
            {
                Console.WriteLine("Sign Up Failed.");
                return false;
            }

        }

        // viết các câu lệnh xử lí phần thông tin người dùng
        public void HandleShowInforUser()
        {
            Console.WriteLine("Full Name" + "\t|\t" + "Bank Id" + "\t|\t" + "Birthday" + "\t|\t" + "Gender" + "\t|\t" + "Phone" + "\t\t\t|\t\t" + "Email");
            Console.WriteLine("==========================================================================================================================================\n");
            Console.WriteLine(user.Fullname 
                                  + "\t|\t" + user.BankId 
                                  + "\t|\t" + user.Birthday 
                                  + "\t|\t" + (user.Gender == 0 ? "Female" : (user.Gender == 1 ? "Male" : "Other")) 
                                  + "\t|\t" + user.Phone 
                                  + "\t\t|\t\t" + user.Email);
            Console.WriteLine("\n==========================================================================================================================================");
        }

        public void HandleEditInfoUser( string colum, string userEdit)
        {

            model.Update(user.Username, colum, userEdit);
            user = model.SelectByUsernameFromTableUser(user.Username);
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
            List<History> history = model.SelectBankIdByHistory(user.BankId);
            
        
            
                Console.WriteLine("Status" + "\t |" + "TradingCode" + "\t |" + "Change" + "\t |" + "Amount (VND)" + "\t\t |" +"Content"+ "\t |" + "Date Transaction");
                Console.WriteLine("========================================================================================================");
                for (int i = 0; i < history.Count; i++)
                {
                    if(user.BankId == history[i].SendBankId)
                    {

                    history[i].Status = "Send";
                    history[i].ReceiveBankId = "-";


                    }
                    else
                    {
                        history[i].Status = "Receive";
                        history[i].ReceiveBankId = "+";
                }
                    Console.WriteLine(history[i].Status
                        + "\t |" + history[i].TradingCode
                        + "\t\t |  " + history[i].ReceiveBankId
                        + "\t\t |" + string.Format("{0:0,0 vnđ}", history[i].Amount)
                        + "\t\t |" + history[i].Content
                        + "\t |" + longTime.ConvertCurrenTime(history[i].DateTransaction));
                }
                Console.WriteLine("========================================================================================================");
        }

    }
}
