using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAddressBook
{
    public static class Utility
    {
        static Utility() { }
        public static string FixText1(string firstname) { if (firstname == null) { return (string.Empty); } return (firstname); }
        public static string FixText2(string lastname) { if (lastname == null) { return (string.Empty); } return (lastname); }
        public static string FixText3(string address) { if (address == null) { return (string.Empty); } return (address); }
        public static string FixText4(string email) { if (email == null) { return (string.Empty); } return (email); }
        public static string FixText5(string telephone) { if (telephone == null) { return (string.Empty); } return (telephone); }
        

}
}
