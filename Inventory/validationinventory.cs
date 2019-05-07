using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Inventory
{
    static class validationinventory
    {
        public static bool validateItemName(String itemName)
        {
            string itemNamePattern = " ^[a - zA - Z][a - zA - Z\\s] + $";
            return Regex.IsMatch(itemName, itemNamePattern);

        }
    }
}
