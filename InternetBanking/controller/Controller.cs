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
            ValidateBalane validateBlane = new ValidateBalane();
            Model model = new Model();

            //tạo biến cho người dùng nhập vào
            int choise;
            Double WithdrawalAmount = 0;

            // cho người dùng nhập vào lựa chọn
            choise = int.Parse(Console.ReadLine());

            User user = model.SelectByUsernameFromTableUser("loc");

            Boolean checkBlance = false;

            switch (choise)
            {
                case 1:
                    WithdrawalAmount = 100000;
                    checkBlance = validateBlane.CheckBlance(WithdrawalAmount);
                    if (checkBlance)
                    {
                        user.Balance -= WithdrawalAmount;
                    }
                    break;
                case 2:
                    WithdrawalAmount = 200000;
                    checkBlance = validateBlane.CheckBlance(WithdrawalAmount);
                    if (checkBlance)
                    {
                        user.Balance -= WithdrawalAmount;
                    }
                    break;
                case 3:
                    WithdrawalAmount = 500000;
                    checkBlance = validateBlane.CheckBlance(WithdrawalAmount);
                    if (checkBlance)
                    {
                        user.Balance -= WithdrawalAmount;
                    }
                    break;
                case 4:
                    WithdrawalAmount = 1000000;
                    checkBlance = validateBlane.CheckBlance(WithdrawalAmount);
                    if (checkBlance)
                    {
                        user.Balance -= WithdrawalAmount;
                    }
                    break;
                case 5:
                    WithdrawalAmount = 2000000;
                    checkBlance = validateBlane.CheckBlance(WithdrawalAmount);
                    if (checkBlance)
                    {
                        user.Balance -= WithdrawalAmount;
                    }
                    break;
                case 6:
                    WithdrawalAmount = 5000000;
                    checkBlance = validateBlane.CheckBlance(WithdrawalAmount);
                    if (checkBlance)
                    {
                        user.Balance -= WithdrawalAmount;
                    }
                    break;
                case 7:
                    // cho người dùng nhập số tiền muốn rút ra 
                    WithdrawalAmount = double.Parse(Console.ReadLine());
                    checkBlance = validateBlane.CheckBlance(WithdrawalAmount);
                    if (checkBlance)
                    {
                        user.Balance -= WithdrawalAmount;
                    }
                    break;
                default:
                    Console.WriteLine("Ban chon chua dung");
                    break;
            }
            if (checkBlance)
            {
                //trừ đi số tiền trong tài khoản trên dâtbase
                model.Update(user.Balance, user.Username);
                //lưu lịch sử rút tiền
                model.InsertToTableHistory(user.Username, WithdrawalAmount);
                Console.WriteLine("withdraw money successfully");
            }

        }

        // viết các câu lệnh xử lí phần chuyển khoản
        public void HandleTransfers()
        {

        }

        // viết các câu lệnh xử lí phần xem lịch sử giao dịch
        public void HandleTransactionHistory()
        {
            List<History> history = model.SelectBankIdByHistory(user.BankId);



            Console.WriteLine("Status" + "\t |" + "TradingCode" + "\t |" + "Change" + "\t |" + "Amount (VND)" + "\t\t |" + "Content" + "\t |" + "Date Transaction");
            Console.WriteLine("========================================================================================================");
            for (int i = 0; i < history.Count; i++)
            {
                if (user.BankId == history[i].SendBankId)
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
