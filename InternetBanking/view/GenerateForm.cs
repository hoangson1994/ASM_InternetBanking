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
        Validate validate = new Validate();
        Controller controller = new Controller();

        // Tạo form Internet Banking.
        public void InternetBanking()
        {
            while (true)
            {
                Console.WriteLine("========Wellcom to InternetBanking========");
                Console.WriteLine("1. Login.");
                Console.WriteLine("2. Signup.");
                Console.WriteLine("3. Exit.");
                Console.WriteLine("Please enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Login();
                        break;
                    case 2:
                        Signup();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter from 1 to 3 !!!");
                        break;
                }
            }
        }

        // Tạo form Login.
        public void Login()
        {
            // cho người dùng nhập username.
            Console.WriteLine("Please enter your username: ");
            String username = Console.ReadLine();

            // cho người dùng nhập password.

            Console.WriteLine("Please enter your password: ");
            String password = Console.ReadLine();



            // gọi hàm HandleLogin(username, password); 
            if (controller.HandleLogin(username, password))
            {
                Console.WriteLine("Login Success.");
                Menu();
            }
            else
            {
                Console.WriteLine("Login error. Please check again username or password. !!!");
            }

            // nếu hàm trả về true .....(các xử lí tiếp theo, như gọi đến hàm Menu());
            // nếu hàm trả về false - thông báo đăng nhập khoog thành công ;

        }


        // Tạo form Signup .
        public void Signup()
        {
            Console.WriteLine("========= Sign Up Form ========");
            while (true)
            {
                Console.WriteLine("Please Enter Username: ");
                string username = Console.ReadLine();
                if (validate.ValidateUsername(username) == null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(validate.ValidateUsername(username));
                }
            }

            while (true)
            {
                Console.WriteLine("Please Enter Password: ");
                string password = Console.ReadLine();
                if (validate.ValidatePassword(password) == null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(validate.ValidatePassword(password));
                }
            }

            while (true)
            {
                Console.WriteLine("Please Enter Fullname: ");
                string fullName = Console.ReadLine();
                if (validate.ValidateFullname(fullName) == null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(validate.ValidateFullname(fullName));
                }
            }

            while (true)
            {
                Console.WriteLine("Please Enter BirthDay(01-01-1990): ");
                string DoB = Console.ReadLine();
                if (validate.ValidateBirthday(DoB) == null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(validate.ValidateBirthday(DoB));
                }
            }

            while (true)
            {
                Console.WriteLine("Please Enter Phone Number: ");
                string phoneNumber = Console.ReadLine();
                if (validate.ValidatePhone(phoneNumber) == null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(validate.ValidatePhone(phoneNumber));
                }
            }

            while (true)
            {
                Console.WriteLine("Please Enter Identity Card: ");
                string userId = Console.ReadLine();
                if (validate.ValidateUserId(userId) == null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(validate.ValidateUserId(userId));
                }
            }

            while (true)
            {
                Console.WriteLine("Please Enter Email: ");
                string email = Console.ReadLine();
                if (validate.ValidateEmail(email) == null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(validate.ValidateEmail(email));
                }
            }

            controller.HandleSignup();
        }

        // Tạo form Menu chính.
        public void Menu()
        {
            int exit = 0;
            while (exit == 0)
            {
                Console.WriteLine("========Generate Menu========");
                //1. thông tin  người dùng
                Console.WriteLine("1. Info");
                //2. truy vấn số dư
                Console.WriteLine("2. Balance inquiry");
                //3. rút tiền
                Console.WriteLine("3. Withdrawal");
                //4. chuyển khoản
                Console.WriteLine("4. Transfer");
                //5. lịch sử giao dịch
                Console.WriteLine("5. Transaction history");
                Console.WriteLine("6. Logout.");
                Console.WriteLine("Please enter your choice: ");
                int choiceMenu = int.Parse(Console.ReadLine());
                switch (choiceMenu)
                {
                    case 1:
                        InfoUser();
                        break;
                    case 2:
                        QueryBalance();
                        break;
                    case 3:
                        Withdrawal();
                        break;
                    case 4:
                        Transfer();
                        break;
                    case 5:
                        TransactionHistory();
                        break;
                    case 6:
                        exit = 1;
                        break;
                    default:
                        Console.WriteLine("Please enter to 1 from 5.");
                        break;
                }
            }
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
            controller.HandleTransactionHistory();
        }
    }
}
