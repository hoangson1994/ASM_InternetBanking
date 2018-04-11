using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking
{
    class MainThread
    {
        static void Main(string[] args)
        {
            GenerateForm gf = new GenerateForm();
            gf.Signup();
            Console.ReadLine();
        }
    }
}
