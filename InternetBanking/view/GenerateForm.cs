using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetBanking.generatebankid;
using InternetBanking.MD5Encrypt;

namespace InternetBanking
{
    class GenerateForm
    {

        Model model = new Model();
        Validate validate = new Validate();
        Controller controller = new Controller();
        LongTime longTime = new LongTime();

        // Tạo form Internet Banking.
        public void InternetBanking()
        {
            while (true)
            {
                Console.WriteLine("========Wellcom to InternetBanking========");
                Console.WriteLine("1. Login.");
                Console.WriteLine("2. Signup.");
                Console.WriteLine("3. Exit.");
                int choice = 0;
                while (choice == 0 || choice > 3)
                {
                    Console.WriteLine("Please enter your choice: ");
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("");
                    }
                }

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
            Account account = new Account();
            User user = new User();
            while (true)
            {
                Console.WriteLine("Please Enter Username: ");
                string username = Console.ReadLine();
                string validatedUsername = validate.ValidateUsername(username);
                if (validatedUsername == null)
                {
                    if (controller.CheckUsernameExist(username) == false)
                    {
                        account.Username = username;
                        user.Username = username;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine(validatedUsername);
                }
            }

            while (true)
            {
                Console.WriteLine("Please Enter Password: ");
                string password = Console.ReadLine();
                string validatedPassword = validate.ValidatePassword(password);
                if (validatedPassword == null)
                {
                    string salt = SaltGenerator.SaltGen(5);
                    account.Salt = salt;
                    string passwordwithsalt = password + salt;
                    string passEncrypt = MD5.CreateMD5(passwordwithsalt);
                    account.Password = passEncrypt;
                    break;
                }
                else
                {
                    Console.WriteLine(validatedPassword);
                }
            }

            while (true)
            {
                Console.WriteLine("Please Enter Fullname: ");
                string fullName = Console.ReadLine();
                string validatedFullName = validate.ValidateFullname(fullName);
                if (validatedFullName == null)
                {
                    user.Fullname = fullName;
                    break;
                }
                else
                {
                    Console.WriteLine(validatedFullName);
                }
            }

            while (true)
            {
                Console.WriteLine("Please Enter BirthDay(dd/mm/yyyy): ");
                string DoB = Console.ReadLine();
                string validatedBirthday = validate.ValidateBirthday(DoB);
                if (validatedBirthday == null)
                {
                    user.Birthday = DoB;
                    break;
                }
                else
                {
                    Console.WriteLine(validatedBirthday);
                }
            }

            while (true)
            {
                Console.WriteLine("Please Enter Phone Number: ");
                string phoneNumber = Console.ReadLine();
                string validatedPhone = validate.ValidatePhone(phoneNumber);
                if (validatedPhone == null)
                {
                    user.Phone = phoneNumber;
                    break;
                }
                else
                {
                    Console.WriteLine(validatedPhone);
                }
            }

            while (true)
            {
                Console.WriteLine("Please Enter Identity Card: ");
                string userId = Console.ReadLine();
                string validatedUserId = validate.ValidateUserId(userId);
                if (validatedUserId == null)
                {
                    user.UserId = userId;
                    break;
                }
                else
                {
                    Console.WriteLine(validatedUserId);
                }
            }

            while (true)
            {
                Console.WriteLine("Please Enter Email: ");
                string email = Console.ReadLine();
                string validatedEmail = validate.ValidateEmail(email);
                if (validatedEmail == null)
                {
                    user.Email = email;
                    break;
                }
                else
                {
                    Console.WriteLine(validatedEmail);
                }
            }

            user.BankId = BankIdGenerator.BankIdGen(6);
            user.CreateAt = longTime.CurrentTimeMillis();
            controller.HandleSignup(account, user);
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
                int choiceMenu = 0;
                while (choiceMenu == 0 || choiceMenu > 6)
                {
                    Console.WriteLine("Please enter your choice: ");
                    try
                    {
                        choiceMenu = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("");
                    }
                }

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
