using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace InternetBanking
{
    class Model
    {
        // lấy ra thông tin user theo username 
        public User SelectByUsernameFromTableUser(string username)
        {
            DbConnection dbConnection = new DbConnection();
            // viết các câu lệnh get user theo username;
            User user = null;
            string query = "SELECT * FROM user where username ='" + username + "'";
            //Open connection
            if (dbConnection.OpenConnection() == true)
            {
                try
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.Connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        string usernameDb = dataReader.GetString("username");
                        string fullName = dataReader.GetString("fullName");
                        string bankId = dataReader.GetString("bankId");
                        double balance = dataReader.GetDouble("balance");
                        string birthday = dataReader.GetString("birthday");
                        string phone = dataReader.GetString("phone");
                        int gender = dataReader.GetInt32("gender");
                        string userId = dataReader.GetString("userId");
                        string email = dataReader.GetString("email");
                        int status = dataReader.GetInt32("status");
                        long createAt = dataReader.GetInt64("createAt");
                        long updateAt = dataReader.GetInt64("updateAt");
                        user = new User(usernameDb,bankId, balance, fullName, birthday, phone, gender, userId, email, status, createAt, updateAt);
                    }
                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    dbConnection.CloseConnection();
                    return user;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return user;
        }

        public Account SelectByUsernameFromTableAccount(string username)
        {
            DbConnection dbConnection = new DbConnection();
            // viết các câu lệnh get user theo username;
            Account account = null;
            string query = "SELECT * FROM account where username ='" + username + "'";
            //Open connection
            if (dbConnection.OpenConnection() == true)
            {
                try
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.Connection);
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        string usernameDb = dataReader.GetString("username");
                        string password = dataReader.GetString("password");
                        string salt = dataReader.GetString("salt");
                        account = new Account(usernameDb, password, salt);
                    }
                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    dbConnection.CloseConnection();
                    return account;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return account;
        }



        // lấy ra thông tin user theo tài khoản ngân hàng 
        public void SelectByBankId()
        {
            
        }

        public List<History> SelectBankIdByHistory(string bankId)
        {
            List<History> listHistory = new List<History>();
            // viết các câu lệnh get user theo username;
            DbConnection dbConnection = new DbConnection();
            string query = "SELECT * FROM history WHERE sendBankId=?val1 OR receiveBankId=?val2 ";

            //Create a list to store the result
           

            //Open connection
            if (dbConnection.OpenConnection() == true)
            {
                try
                {
                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.Connection);

                    cmd.Parameters.AddWithValue("?val1", bankId);
                    cmd.Parameters.AddWithValue("?val2", bankId);

                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {

                        string getTradingCode = dataReader.GetString("tradingCode");
                        string getSendBankId = dataReader.GetString("sendBankId");
                        string getReceiveBankId = dataReader.GetString("receiveBankId");
                        double getBalance = dataReader.GetDouble("amount");
                        string getContent = dataReader.GetString("content");

                        long getCreateAt = dataReader.GetInt32("dateTransaction");
                        History history = new History(getTradingCode, getSendBankId, getReceiveBankId, getBalance, getContent, getCreateAt);
                        listHistory.Add(history);
                    }

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    dbConnection.CloseConnection();

                    //return list to be displayed
                    return listHistory;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                
            }
            
            
                return listHistory;
            
        }

        // thêm vào bảng users khi đăng kí thành công
        public bool InsertToTableUsers(User user)
        {
            DbConnection dbConnection = new DbConnection();
            string query = "INSERT INTO user (username, bankId, balance, fullname, birthday, phone, gender, userId, email, status, createAt) VALUES('"+ user.Username +"','"+ user.BankId +"', "+ user.Balance+", " +
                           "'"+ user.Fullname+"', '"+user.Birthday+"', '"+user.Phone+"',"+user.Gender+",'"+user.UserId+"','"+user.Email+"',"+user.Status+","+user.CreateAt+")";

            //open connection
            if (dbConnection.OpenConnection() == true)
            {
                try
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.Connection);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    dbConnection.CloseConnection();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                
            }

            return false;
        }

        // thêm vào bảng account khi đăng ký thành công
        public bool InsertToTableAccount(Account account)
        {
            DbConnection dbConnection = new DbConnection();
            string query = "INSERT INTO account (username, password, salt) VALUES('"+account.Username+"','"+account.Password+"','"+account.Salt+"')";

            //open connection
            if (dbConnection.OpenConnection() == true)
            {
                try
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, dbConnection.Connection);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    dbConnection.CloseConnection();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return false;
        }

        // thêm vào bảng history khi chuyển khoản thành công
            public void InsertToTableHistory()
        {
      

        }

        // update số dư tài khoản của người nhận và người chuyển khi thực hiện chuyển khoản.
        public bool Update(Account account)
        {
            return false;
        }

        // transaction mysql
        public void Transactions()
        {
    
        }
    }
}
