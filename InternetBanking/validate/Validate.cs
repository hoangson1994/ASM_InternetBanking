using System;
using System.Collections.Generic;
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
            Regex regex = new Regex("[a-zA-Z0-9]");
            if (txt == null)
            {
                return MapEntity.mapError["username"].ErrorEmpty;
            }
            else if (regex.IsMatch(txt))
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
            Regex regex = new Regex("[a-zA-Z0-9]");
            if (txt == null)
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
            Regex regex = new Regex("[a-zA-z\\s][a-zA-z\\s][a-zA-z]");
            if (txt == null)
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
            Regex regex = new Regex("[0-9/][0-9/][0-9]");
            if (txt == null)
            {
              return MapEntity.mapError["birthday"].ErrorEmpty;
            }
            else if (regex.IsMatch(txt))
            {
                DateTime birthdayDateTime = DateTime.Parse(txt);
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
            Regex regex = new Regex("[0-9]");
            if (txt == null)
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
            Regex regex = new Regex("[0-9]");
            if (txt == null)
            {
                return MapEntity.mapError["userId"].ErrorEmpty;
            }
            else if (regex.IsMatch(txt))
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
            Regex regex = new Regex("[A-Za-z0-9_]@[a-zA-Z].[a-zA-Z]");
            if (txt == null)
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
      
    }
}
