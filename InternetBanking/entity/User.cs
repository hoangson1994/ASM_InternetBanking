using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetBanking.generatelongtime;

namespace InternetBanking
{
    class User
    {
        // khai báo các trường của user , contructor, getter, setter.

        private int id;
        private string username;
        private string bankId;
        private double balance;
        private string fullname;
        private long birthday;
        private string phone;
        private int gender;
        private string userId;
        private string email;
        private int status;
        private long createAt;
        private long updateAt;

        public User()
        {

        }
        public User(string username, string bankId, double balance, string fullname, long birthday, string phone, int gender, string userId, string email, int status, long createAt, long updateAt)
        {
            this.Username = username;
            this.BankId = bankId;
            this.Balance = balance;
            this.Fullname = fullname;
            this.Birthday = birthday;
            this.Phone = phone;
            this.Gender = gender;
            this.UserId = userId;
            this.Email = email;
            this.Status = status;
            this.CreateAt = createAt;
            this.UpdateAt = updateAt;
        }

        public User(string username, string bankId, double balance, string fullname, long birthday, string phone, int gender, string userId, string email, int status)
        {
            this.Username = username;
            this.BankId = bankId;
            this.Balance = balance;
            this.Fullname = fullname;
            this.Birthday = birthday;
            this.Phone = phone;
            this.Gender = gender;
            this.UserId = userId;
            this.Email = email;
            this.Status = status;
            LongTime longtime = new LongTime();
            this.CreateAt = longtime.CurrentTimeMillis();
            this.UpdateAt = longtime.CurrentTimeMillis();
        }

        public string Username { get => username; set => username = value; }
        public string BankId { get => bankId; set => bankId = value; }
        public double Balance { get => balance; set => balance = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public long Birthday { get => birthday; set => birthday = value; }
        public string Phone { get => phone; set => phone = value; }
        public int Gender { get => gender; set => gender = value; }
        public string UserId { get => userId; set => userId = value; }
        public string Email { get => email; set => email = value; }
        public int Status { get => status; set => status = value; }
        public long CreateAt { get => createAt; set => createAt = value; }
        public long UpdateAt { get => updateAt; set => updateAt = value; }
    }
}
