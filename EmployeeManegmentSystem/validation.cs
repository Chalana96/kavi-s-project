using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeManegmentSystem
{
    static class validation
    {

        public static bool validateName(String name)
        {
            string NamePattern = "^[a-zA-Z][a-zA-Z\\s]+$";
            return Regex.IsMatch(name, NamePattern);
        }

        public static bool validateNICNo(String nic)
        {

            if (nic.Length == 10 || nic.Length == 12)
            {
                if (nic.Length == 10)
                {
                    String sufix = nic.Substring(9);
                    if (sufix.Equals("V") || sufix.Equals("v") || sufix.Equals("X") || sufix.Equals("x"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }

            //string NicPattern = "[0-9]{12}[Vv]$/";
            //return Regex.IsMatch(nic, NicPattern);
        }

        public static bool validateAddress(String address)
        {
            string AddressPattern = "^[a-zA-Z][a-zA-Z\\s]+$";
            return Regex.IsMatch(address, AddressPattern);
        }

        public static bool validateContactNo(String contact)
        {
            string contactPattern = "[0-9]{10}";
            return Regex.IsMatch(contact, contactPattern);
        }



    }
}
