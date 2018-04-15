using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking
{
    class Controller
    {
        Model model = new Model();

        User userLogin;

        User userBeneficiaries;

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
                    userLogin = model.SelectByUsernameFromTableUser(username);
                    return true;
                }                
            }

            return false;                     
        }

        // viết các câu lệnh xử lí phần đăng kí
        public bool HandleSignup(Account account, User user)
        {
            if (model.InsertToTableAccount(account) == true && model.InsertToTableUsers(user) == true)
            {                
                return true;
            }
                   
            return false;
        }

        // viết các câu lệnh xử lí phần thông tin người dùng
        public void HandleShowInforUser()
        {
            Console.WriteLine("==========================================================================================================================================");
            Console.WriteLine("Full Name" + "\t|\t" + "Bank Id" + "\t|\t" + "Birthday" + "\t|\t" + "Gender" + "\t|\t" + "Phone" + "\t\t\t|\t\t" + "Email");
            Console.WriteLine("==========================================================================================================================================\n");
            Console.WriteLine(userLogin.Fullname
                              + "\t|\t" + userLogin.BankId
                              + "\t|\t" + userLogin.Birthday
                              + "\t|\t" + (userLogin.Gender == 0 ? "Female" : (userLogin.Gender == 1 ? "Male" : "Other"))
                              + "\t|\t" + userLogin.Phone
                              + "\t\t|\t\t" + userLogin.Email);
            Console.WriteLine("\n==========================================================================================================================================");
        }

        // viết các câu lệnh xử lí phần truy vấn số dư
        public void HandleQueryBalance()
        {
            Console.WriteLine("1. Bank Number: " + userLogin.BankId);
            Console.WriteLine("2. Fullname: " + userLogin.Fullname);
            Console.WriteLine("3. Balance: " + userLogin.Balance.ToString("N1", CultureInfo.InvariantCulture));
            Console.WriteLine("4. Last 5 transactions:");

            List<History> history = model.SelectBankIdByHistory(userLogin.BankId);

            string change;

            Console.WriteLine("Status" + "\t |" + "TradingCode" + "\t |" + "Change" + "\t |" + "Amount (VND)" + "\t\t |" + "Content" + "\t |" + "Date Transaction");
            Console.WriteLine("========================================================================================================");
            for (int i = 0; i < 5; i++)
            {
                if (userLogin.BankId == history[i].SendBankId)
                {

                    history[i].Status = "Send";
                    change = "-";


                }
                else
                {
                    history[i].Status = "Receive";
                    change = "+";
                }
                Console.WriteLine(history[i].Status
                    + "\t |" + history[i].TradingCode
                    + "\t\t |  " + change
                    + "\t\t |" + string.Format("{0:0,0 vnđ}", history[i].Amount)
                    + "\t\t |" + history[i].Content
                    + "\t |" + longTime.ConvertCurrenTime(history[i].DateTransaction));
            }
            Console.WriteLine("========================================================================================================");
        }

        // viết các câu lệnh xử lí phần rút tiền
        public bool HandleWithdrawal(double amount)
        {
            double balanceNew = userLogin.Balance - amount;
            if(model.UpdateBalanceWithdraw(balanceNew, userLogin.BankId))
            {
                History history = new History(StringGenerator.NumberGen(3), userLogin.BankId,"", amount, "Withdraw");
                model.InsertToTableHistory(history);
                userLogin = model.SelectByUsernameFromTableUser(userLogin.Username);
                return true;
            }           
            return false;
        }

        // viết các câu lệnh xử lí phần chuyển khoản
        public bool HandleTransfers(double amount, string content)
        {
            double balanceSource = userLogin.Balance - amount;
            double balanceBeneficiaries = userBeneficiaries.Balance + amount;

            if (model.Transactions(userLogin.BankId, userBeneficiaries.BankId, balanceSource, balanceBeneficiaries)) {
                
                History history = new History(StringGenerator.NumberGen(3), userLogin.BankId, userBeneficiaries.BankId, amount, content);
                model.InsertToTableHistory(history);                               
                return true;
            }

            return false;
        }

        // viết các câu lệnh xử lí phần xem lịch sử giao dịch
        public void HandleTransactionHistory()
        {
            List<History> history = model.SelectBankIdByHistory(userLogin.BankId);
            

            string change;

            Console.WriteLine("Status" + "\t |" + "TradingCode" + "\t |" + "Change" + "\t |" + "Amount (VND)" + "\t\t |" + "Content" + "\t |" + "Date Transaction");
            Console.WriteLine("========================================================================================================");
            for (int i = 0; i < history.Count; i++)
            {
                if (userLogin.BankId == history[i].SendBankId)
                {

                    history[i].Status = "Send";
                    change = "-";


                }
                else
                {
                    history[i].Status = "Receive";
                    change = "+";
                }
                Console.WriteLine(history[i].Status
                    + "\t |" + history[i].TradingCode
                    + "\t\t |  " + change
                    + "\t\t |" + string.Format("{0:0,0 vnđ}", history[i].Amount)
                    + "\t\t |" + history[i].Content
                    + "\t |" + longTime.ConvertCurrenTime(history[i].DateTransaction));
            }
            Console.WriteLine("========================================================================================================");

        }


        // viết các câu lệnh xử lí kiểm tra username tồn tại.
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

        // viết các câu lệnh xử lí kiểm tra bankId tồn tại.
        public bool CheckBankIdExist(string bankId)
        {
            userBeneficiaries = model.SelectByBankIdFromUser(bankId);
            if (userBeneficiaries != null)
            {
                return true;
            }
            
            return false;
        }

        public int  CheckAmountMoney(double amount)
        {
            if(amount < 1000)
            {
                return 0;
            }
            else if(amount >= 1000 && amount <= userLogin.Balance)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public void PrintInfoUserBeneficiaries()
        {
            Console.WriteLine("===========INFO===========");
            Console.WriteLine("{0,-20} {1,5}", "Fullname", "BankId");
            Console.WriteLine("==========================");
            Console.WriteLine("{0,-20} {1,5}", userBeneficiaries.Fullname, userBeneficiaries.BankId);
            Console.WriteLine("==========================");
        }

        public void PrintConfirmTransaction(double amount, string content)
        {           
            Console.WriteLine("{0,-10} {1,25} {2,25} {3,25} {4,25} {5,25}", "Source BankId ", "Beneficiaries BankId", "Beneficiary Name", "Money Amount", "Transaction Date", "Content");
            Console.WriteLine("{0,-10} {1,29} {2,25} {3,25} {4,25} {5,25}", userLogin.BankId, userBeneficiaries.BankId, userBeneficiaries.Fullname, amount.ToString("N1", CultureInfo.InvariantCulture), DateTime.Now.ToString(), content);
        }

        public bool HandleEditInfoUser(string colum, string userEdit)
        {

            if(model.Update(userLogin.Username, colum, userEdit))
            {
                userLogin = model.SelectByUsernameFromTableUser(userLogin.Username);
                return true;
            }
            return false;
        }
       
    }
}
