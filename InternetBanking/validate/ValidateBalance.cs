using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking
{
    class ValidateBalane
    {
        Model model = new Model();
        public bool CheckBlance(Double amount)
        {
            try
            {
                User user = model.SelectByUsernameFromTableUser("loc");

                if (amount > 0 && user.Balance >= amount)
                {
                    return true;
                }
                Console.WriteLine("Your money is not enough to make a withdrawal");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }
    }
}
