using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InternetBanking
{
    class Validate
    {
        // các hàm validate các trường người dùng nhập vào để signup.
        public string ValidateUsername(string txt)
        {
            Regex regex = new Regex(@"^(?=[a-zA-Z0-9])[-\w.]{0,23}([a-zA-Z0-9]|(?<![-.])_)$");

            if (string.IsNullOrWhiteSpace(txt))
            {
                return MapEntity.mapError["username"].ErrorEmpty;
            }
            if (regex.IsMatch(txt))
            {
                if (txt.Length < 7)
                {
                    return MapEntity.mapError["username"].ErrorLength;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return MapEntity.mapError["username"].ErrorCharacter;
            }
        }

        public string ValidatePassword(string txt)
        {
            Regex regex = new Regex(@"^(?=[a-zA-Z0-9])[-\w.]{0,23}([a-zA-Z0-9\d]|(?<![-.])_)$");

            if (string.IsNullOrWhiteSpace(txt))
            {
                return MapEntity.mapError["password"].ErrorEmpty;
            }
            else if (regex.IsMatch(txt))
            {
                if (txt.Length < 7)
                {
                    return MapEntity.mapError["password"].ErrorLength;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return MapEntity.mapError["password"].ErrorCharacter;
            }
        }

        public string ValidateFullname(string txt)
        {
            Regex regex = new Regex("[a-zA-Z\\s][a-zA-Z\\s][a-zA-Z]");
            
            if (string.IsNullOrWhiteSpace(txt))
            {
                return MapEntity.mapError["fullName"].ErrorEmpty;
            }
            else if (regex.IsMatch(txt))
            {
                if (txt.Length < 10)
                {
                    return MapEntity.mapError["fullName"].ErrorLength;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return MapEntity.mapError["fullName"].ErrorCharacter;
            }
        }

        public string ValidateBirthday(string txt)
        {
            Regex regex = new Regex(@"^(0[1-9]|[12][0-9]|3[01])[/](0[1-9]|1[012])[/](19|20)\d\d$");

            if (string.IsNullOrWhiteSpace(txt))
            {
                return MapEntity.mapError["birthday"].ErrorEmpty;
            }         
            else if (regex.IsMatch(txt))
            {
                DateTime birthdayDateTime = DateTime.ParseExact(txt, "dd/mm/yyyy", CultureInfo.InvariantCulture);
                if ((DateTime.Now.Year - birthdayDateTime.Year) < 18)
                {
                    return MapEntity.mapError["birthday"].ErrorLength;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return MapEntity.mapError["birthday"].ErrorCharacter;
            }
        }

        public string ValidatePhone(string txt)
        {
            Regex regex = new Regex(@"^(?=[0-9])[-\w.]{0,23}([0-9\d]|(?<![-.])_)$");

            if (string.IsNullOrWhiteSpace(txt))
            {
                return MapEntity.mapError["phone"].ErrorEmpty;
            }
            else if (regex.IsMatch(txt))
            {
                if (txt.Length < 10)
                {
                    return MapEntity.mapError["phone"].ErrorLength;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return MapEntity.mapError["phone"].ErrorCharacter;
            }
        }

        public string ValidateUserId(string txt)
        {
            Regex regex = new Regex(@"^(?=[0-9])[-\w.]{0,23}([0-9\d]|(?<![-.])_)$");

            if (string.IsNullOrWhiteSpace(txt))
            {
                return MapEntity.mapError["userId"].ErrorEmpty;
            }
            if (regex.IsMatch(txt))
            {
                if (txt.Length < 10)
                {
                    return MapEntity.mapError["userId"].ErrorLength;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return MapEntity.mapError["userId"].ErrorCharacter;
            }
        }

        public string ValidateEmail(string txt)
        {
            Regex regex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
           
            if (string.IsNullOrWhiteSpace(txt))
            {
                return MapEntity.mapError["email"].ErrorEmpty;
            }

            else if (regex.IsMatch(txt))
            {
                if (txt.Length < 10)
                {
                    return MapEntity.mapError["email"].ErrorLength;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return MapEntity.mapError["email"].ErrorCharacter;
            }
        }

        public string ValidateGender(string txt)
        {
            Regex regex = new Regex("[a-z]");
            
            if (string.IsNullOrWhiteSpace(txt))
            {
                return MapEntity.mapError["gender"].ErrorEmpty;
            }
            else if (regex.IsMatch(txt))
            {
                if (txt.Equals("f") || txt.Equals("m") || txt.Equals("o"))
                {
                    return null;
                }
                else
                {
                    return MapEntity.mapError["gender"].ErrorCharacter;
                    
                }
            }
            else
            {
                return MapEntity.mapError["gender"].ErrorCharacter;
            }
        }
    }
}
