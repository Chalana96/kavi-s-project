using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomRservation
{
    static class ValidationRoomRes
    {
        public static bool validateDiscountText(String discount)
        {
            double d;
            if (!Double.TryParse(discount,out d))
            {
                return false;
            }

            if(d > 100 || d < 0)
            {
                return false;
            }

            return true;
        }
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
       public static bool validateNIC(String NIC)
        {
            string NICPattern = "[0-9]{9}[vVxX]{1}$";
            return Regex.IsMatch(NIC , NICPattern);
        }
        public static bool validateNumbers(String numbers)
        {
            string NumberPattern = "^([1-9]|1[012])$";
            return Regex.IsMatch(numbers, NumberPattern);
        }
        public static bool validateChildren(String children)
        {
            string ChildrenPattern = "^([0-9]|1[012])$";
            return Regex.IsMatch(children, ChildrenPattern);
        }
    }


}
