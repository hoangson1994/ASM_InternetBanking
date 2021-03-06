﻿using System;
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
        LongTime longTime = new LongTime();

        // Tạo form Internet Banking.
        public void InternetBanking()
        {
            while (true)
            {
                Console.WriteLine("================= Wellcom to InternetBanking ====================");
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
                    catch (FormatException)
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
                Console.WriteLine("==================================================================");
            }
        }

        // Tạo form Login.
        public void Login()
        {
            Console.WriteLine("===================== LOGIN ======================");
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

            Console.WriteLine("==================================================");

        }


        // Tạo form Signup .
        public void Signup()
        {
            Console.WriteLine("====================== SIGN UP =======================");
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
                    string salt = StringGenerator.SaltGen(5);
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
                Console.WriteLine("Please Enter Gender (F(female)/M(male)/O(other)): ");
                string inputGender = Console.ReadLine();
                inputGender = inputGender.ToLower();
                Console.WriteLine("==="+ inputGender);
                string validateGender = validate.ValidateGender(inputGender);
                int gender = 0;
                if (validateGender == null)
                {
                    switch (inputGender)
                    {
                        case "f":
                            gender = 0;
                            break;
                        case "m":
                            gender = 1;
                            break;
                        case "o":
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

            user.BankId = StringGenerator.NumberGen(6);
            user.CreateAt = longTime.CurrentTimeMillis();
            user.Balance = 5000000;

            Console.WriteLine("Processing ......");

            if (controller.HandleSignup(account, user))
            {
                Console.WriteLine("Sign Up Success");
            }
            else
            {
                Console.WriteLine("Sign Up Failed. Please try again.");
            }

            Console.WriteLine("=========================================================");
        }

        // Tạo form Menu chính.
        public void Menu()
        {
            int exit = 0;
            while (exit == 0)
            {
                Console.WriteLine("======================= MENU ========================");
                //1. thông tin  người dùng
                Console.WriteLine("1. User Information");
                //2. truy vấn số dư
                Console.WriteLine("2. Balance Query");
                //3. rút tiền
                Console.WriteLine("3. Withdrawal");
                //4. chuyển khoản
                Console.WriteLine("4. Transfer");
                //5. lịch sử giao dịch
                Console.WriteLine("5. Transaction history");

                Console.WriteLine("6. Logout.");
                int choiceMenu = 0;
                while (true)
                {
                    Console.WriteLine("Please enter your choice: ");
                    try
                    {
                        choiceMenu = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
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
                Console.WriteLine("====================================================");
            }
        }

        // Tạo form thông tin người dùng.
        public void InfoUser()
        {
            int exit = 0;
            while (exit == 0)
            {
                Console.WriteLine("------------------ User Information  -------------------");
                Console.WriteLine("1. Show User Information.");
                Console.WriteLine("2. Edit Information.");
                Console.WriteLine("3. Back to Menu.");
                int choice = 0;
                while (true)
                {
                    Console.WriteLine("Please enter your choice: ");
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Your choice invalid. Please input only number.");
                    }
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("************* Show Info User ***************");
                        controller.HandleShowInforUser();
                        Console.WriteLine("********************************************");
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
                Console.WriteLine("-----------------------------------------------------------");
            }            
        }

        // form update info
        public void UpdateUser()
        {
            User user = new User();
            int exit = 0;
            while (exit == 0)
            {
                Console.WriteLine("************** Update Info User **************");
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
                    catch (FormatException)
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
                Console.WriteLine("****************************************************");
            }           
        }

        // Tạo form truy vấn số dư.
        public void QueryBalance()
        {
            Console.WriteLine("--------------- Balance Query ---------------");
            controller.HandleQueryBalance();
            Console.WriteLine("---------------------------------------------");
        }

        // Tạo form rút tiền.
        public void Withdrawal()
        {
            int exit = 0;
            while (exit == 0)
            {
                Console.WriteLine("---------------------------------- Withdrawal -----------------------------");
                Console.WriteLine("1. 100 000 VND");
                Console.WriteLine("2. 200 000 VND");
                Console.WriteLine("3. 500 000 VND");
                Console.WriteLine("4. 1 000 000 VND");
                Console.WriteLine("5. 2 000 000 VND");
                Console.WriteLine("6. 5 000 000 VND");
                Console.WriteLine("7. Another Choice");
                Console.WriteLine("8. Back to Menu.");

                Console.WriteLine("Please enter you choice: ");
                int choice = 0;
                while (true)
                {
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Only enter number. Please enter again.");
                    }
                }

                switch (choice)
                {
                    case 1:
                        WithdrawDefault(100000);
 
                        break;
                    case 2:
                        WithdrawDefault(200000);

                        break;
                    case 3:
                        WithdrawDefault(500000);

                        break;
                    case 4:
                        WithdrawDefault(1000000);

                        break;
                    case 5:
                        WithdrawDefault(2000000);

                        break;
                    case 6:
                        WithdrawDefault(5000000);

                        break;
                    case 7:
                        WithdrawYourChoice();

                        break;
                    case 8:
                        exit = 1;
                        break;
                    default:
                        Console.WriteLine("Please enter your choice from 1 to 8.");
                        break;
                }
            }           
            
        }
        
        // Tạo form chuyển khoản.
        public void Transfer()
        {
           int exit = 0;
            while(exit == 0)
            {
                Console.WriteLine("---------------- TRANNSFER -----------------");
                
                while (true)
                {
                    Console.WriteLine("1. Please enter BankID Beneficiaries: ");
                    string bankId = Console.ReadLine();
                    if (controller.CheckBankIdExist(bankId))
                    {
                        controller.PrintInfoUserBeneficiaries();
                        break;
                    }
                    Console.WriteLine("BankId does not exist. Please check again BankId.");
                }

                double amount = 0;
                int exit1 = 0;
                while (exit1 == 0)
                {
                    int checkAmountMoney;
                    while (true)
                    {
                        Console.WriteLine("2. Please enter amount money transfer: ");
                        try
                        {
                            amount = double.Parse(Console.ReadLine());
                            checkAmountMoney = controller.CheckAmountMoney(amount);
                            if(checkAmountMoney == 0)
                            {
                                Console.WriteLine("The minimum transfer amount is 1000 VNĐ. Please enter again.");
                                continue;
                            }
                            break;
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Only enter number. Please enter again.");
                        }
                       
                    }

                    
                    if (checkAmountMoney == 1)
                    {                        
                        break;
                    }
                   
                    Console.WriteLine("Your balance not enough. Would you like to continue transfer(Y/N)?");
                    string choice = Console.ReadLine();
                    choice = choice.ToLower();
                    switch (choice)
                    {
                        case "y":                            
                            break;
                        case "n":
                            amount = 0;
                            exit1 = 1; 
                            break;
                        default:
                            Console.WriteLine("Your choice invalid. Please choice Y(Yes)/N(No).");
                            break;
                    }
                }

                if(amount == 0)
                {
                    break;
                }
                
                Console.WriteLine("3. Please enter content transfer: ");
                string content = Console.ReadLine();

                Console.WriteLine("4. Confirm transaction: ");
                controller.PrintConfirmTransaction(amount, content);

                int exit2 = 0;
                while (exit2 == 0)
                {
                    Console.WriteLine("---- Are you want perform transaction(Y/N): ");
                    string choice = Console.ReadLine();
                    choice = choice.ToLower();
                    switch (choice)
                    {
                        case "y":
                            Console.WriteLine("Transaction processing .....");
                            if (controller.HandleTransfers(amount, content))
                            {
                                Console.WriteLine("Transfer Success!");
                            }
                            else
                            {
                                Console.WriteLine("Transfer Fail. Please try again.");
                            }
                            exit2 = 1;
                            break;
                        case "n":
                            exit2 = 1;
                            break;
                        default:
                            Console.WriteLine("Your choice invalid. Please choice Y(Yes)/N(No).");
                            break;
                    }
                }

                int exit3 = 0;
                while (exit3 == 0)
                {
                    Console.WriteLine("----- Are you want perform transfer other(Y/N):");
                    string choice = Console.ReadLine();
                    choice = choice.ToLower();
                    switch (choice)
                    {
                        case "y":                           
                            exit3 = 1;
                            break;
                        case "n":
                            exit = 1;
                            exit3 = 1;
                            break;
                        default:
                            Console.WriteLine("Your choice invvalid. Please enter choice Y(Yes)/N(No).");
                            break;
                    }
                }

                Console.WriteLine("----------------------------------------------");
            }
            
        }

        // Tạo form tra cứu lịch sử giao dịch
        public void TransactionHistory()
        {
            Console.WriteLine("-------------- Transaction History ---------------");
            controller.HandleTransactionHistory();
            Console.WriteLine("--------------------------------------------------");            
        }

        public void WithdrawDefault(double amount)
        {
            int checkMoney = controller.CheckAmountMoney(amount);
            if (checkMoney == 1)
            {
                Console.WriteLine("Transaction processing ....");
                if (controller.HandleWithdrawal(amount))
                {
                    Console.WriteLine("Withdraw Success !!!");
                }
                else
                {
                    Console.WriteLine("Withdraw Fail. Please try again later. !!!");
                }     
                               
            }
            else
            {
                Console.WriteLine("Your balance not enough. Please enter check again balance.");
                
            }
            
        }
        public void WithdrawYourChoice()
        {
            double amount;
            int checkAmount;
            while (true)
            {
                Console.WriteLine("Please enter money amount you want withdraw:");
                try
                {
                    amount = double.Parse(Console.ReadLine());
                    checkAmount = controller.CheckAmountMoney(amount);
                    if(checkAmount == 0)
                    {
                        Console.WriteLine("The minimum transfer amount is 1000 VNĐ. Please enter again.");
                        continue;
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Only enter number. Please enter again.");
                }
            }

            if(checkAmount == 1)
            {
                Console.WriteLine("Transaction processing ....");
                if (controller.HandleWithdrawal(amount))
                {
                    Console.WriteLine("Withdraw Success !!!");
                }
                else
                {
                    Console.WriteLine("Withdraw Fail !!!");
                }
            }
            else
            {
                Console.WriteLine("Your balance not enough. Please check again.");
            }
            
        }

    }
}
