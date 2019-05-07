using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EventManagement
{
    class ValidationEvent
    {

        public static bool validateName(String name)
        {
            string firstNamePattern = "^[a-zA-Z][a-zA-Z\\s]+$";
            return Regex.IsMatch(name, firstNamePattern);
        }
        public static bool validatePhoneNo(String phoneNo)
        {
            string phonePattern = "[0-9]{10}";
            return Regex.IsMatch(phoneNo, phonePattern);
        }
        public static bool validateNic(String nic)
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

        }

        public static bool validateDiscountText(String discount)
        {
            double d;
            if (!Double.TryParse(discount, out d))
            {
                return false;
            }

            if (d > 100 || d < 0)
            {
                return false;
            }

            return true;
        }

    }
}
