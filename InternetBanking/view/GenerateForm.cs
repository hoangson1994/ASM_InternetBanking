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
        int gender = 0;

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
                while (true)
                {
                    Console.WriteLine("Please enter your choice: ");
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Your choice invalid. Please input only number.");
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

            while (true)
            {
                Console.WriteLine("Please Enter Gender: ");
                string inputGender = Console.ReadLine();
                string validateGender = validate.ValidateGender(inputGender);
                if (validateGender == null)
                {
                    switch (inputGender)
                    {
                        case "female":
                            gender = 0;
                            break;
                        case "male":
                            gender = 1;
                            break;
                        case "other":
                            gender = 2;
                            break;
                        default:
                            Console.WriteLine("Gender incorrect. Please re-enter gender.");
                            break;
                    }

                    user.Gender = gender;
                    break;
                }
                else
                {
                    Console.WriteLine(validateGender);
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
                        Console.WriteLine("Your choice invalid. Please input only number.");
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
            int exit = 0;
            while (exit == 0)
            {
                Console.WriteLine("====== Menu Info User =======");
                Console.WriteLine("1. Show User Information.");
                Console.WriteLine("2. Edit Information.");
                Console.WriteLine("3. Back to Menu.");
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
                        Console.WriteLine("Your choice invalid. Please input only number.");
                    }
                }

                switch (choice)
                {
                    case 1:
                        controller.HandleShowInforUser();
                        break;
                    case 2:
                        UpdateUser();
                        break;
                    case 3:
                        exit = 1;
                        break;
                    default:
                        Console.WriteLine("Your choice invalid. Please re-enter your choice.");
                        break;
                }
            }


        }

        public void UpdateUser()
        {
            User user = new User();
            int exit = 0;
            while (exit == 0)
            {
                Console.WriteLine("====== Update Info User =======");
                Console.WriteLine("1. Edit Phone Number.");
                Console.WriteLine("2. Edit Email.");
                Console.WriteLine("3. Edit Birthday.");
                Console.WriteLine("4. Edit Identity Card.");
                Console.WriteLine("5. Back to the Menu.");
                int choice = 0;
                while (true)
                {
                    Console.WriteLine("Please enter your choice: ");
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Your choice invalid. Please input only number.");
                    }
                }

                switch (choice)
                {
                    case 1:
                        int exitPhone = 0;
                        while (exitPhone == 0)
                        {
                            Console.WriteLine("Please Enter Phone Number Update: ");
                            string updatePhone = Console.ReadLine();
                            string validatePhone = validate.ValidatePhone(updatePhone);
                            if (validatePhone == null)
                            {
                                while (exitPhone == 0)
                                {
                                    Console.WriteLine("Do you want to update Phone Number? (Y/n)");
                                    string choiceyn = Console.ReadLine();
                                    choiceyn = choiceyn.ToLower();
                                    switch (choiceyn)
                                    {
                                        case "y":
                                            user.Phone = updatePhone;
                                            controller.HandleEditInfoUser("phone", updatePhone);
                                            exitPhone = 1;
                                            break;
                                        case "n":
                                            exitPhone = 1;
                                            break;
                                        default:
                                            Console.WriteLine("Only input Y or N");
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine(validatePhone);
                            }
                        }
                
                        break;
                    case 2:
                        int exitUpdateEmail = 0;
                        while (exitUpdateEmail == 0)
                        {
                            Console.WriteLine("Please Enter Email Update: ");
                            string updateEmail = Console.ReadLine();
                            string validatedEmail = validate.ValidateEmail(updateEmail);
                            if (validatedEmail == null)
                            {
                                while (exitUpdateEmail == 0)
                                {
                                    Console.WriteLine("Do you want to update Email? (Y/n)");
                                    string choiceyn = Console.ReadLine();
                                    choiceyn = choiceyn.ToLower();
                                    switch (choiceyn)
                                    {
                                        case "y":
                                            user.Email = updateEmail;
                                            controller.HandleEditInfoUser("email", updateEmail);
                                            exitUpdateEmail = 1;
                                            break;
                                        case "n":
                                            exitUpdateEmail = 1;
                                            break;
                                        default:
                                            Console.WriteLine("Only input Y or N");
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine(validatedEmail);
                            }
                        }
                        break;
                    case 3:
                        int exitBirthday = 0;
                        while (exitBirthday == 0)
                        {
                            Console.WriteLine("Please Enter Birthday Update: ");
                            string updateDob = Console.ReadLine();
                            string validatedBirthday = validate.ValidateBirthday(updateDob);
                            if (validatedBirthday == null)
                            {
                                while (exitBirthday == 0)
                                {
                                    Console.WriteLine("Do you want to update Birthday? (Y/n)");
                                    string choiceyn = Console.ReadLine();
                                    choiceyn = choiceyn.ToLower();
                                    switch (choiceyn)
                                    {
                                        case "y":
                                            user.Birthday = updateDob;
                                            controller.HandleEditInfoUser("birthday", updateDob);
                                            exitBirthday = 1;
                                            break;
                                        case "n":
                                            exitBirthday = 1;
                                            break;
                                        default:
                                            Console.WriteLine("Only input Y or N");
                                            break;
                                    }
                                }
                               
                            }
                            else
                            {
                                Console.WriteLine(validatedBirthday);
                            }
                        }
                        break;
                    case 4:
                        int exitIdentityCard = 0;
                        while (exitIdentityCard == 0)
                        {
                            Console.WriteLine("Please Enter Identity Card Update: ");
                            string updateIdentityCard = Console.ReadLine();
                            string validateIdentityCard = validate.ValidateUserId(updateIdentityCard);
                            if (validateIdentityCard == null)
                            {
                                while (exitIdentityCard == 0)
                                {
                                    Console.WriteLine("Do you want to update Identity Card? (Y/n)");
                                    string choiceyn = Console.ReadLine();
                                    choiceyn = choiceyn.ToLower();
                                    switch (choiceyn)
                                    {
                                        case "y":
                                            user.UserId = updateIdentityCard;
                                            controller.HandleEditInfoUser("userId", updateIdentityCard);
                                            exitIdentityCard = 1;
                                            break;
                                        case "n":
                                            exitIdentityCard = 1;
                                            break;
                                        default:
                                            Console.WriteLine("Only input Y or N");
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine(validateIdentityCard);
                            }
                        }
                        break;
                    case 5:
                        exit = 1;
                        break;
                    default:
                        Console.WriteLine("Your choice invalid. Please enter 1- 5.");
                        break;
                }
            }

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
