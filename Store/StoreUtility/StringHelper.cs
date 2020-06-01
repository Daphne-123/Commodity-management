using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreUtility
{
    public class StringHelper
    {
        public static bool IsNumber(string str)
        {

            bool re = true;
            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsNumber(str[i]))
                {
                    re = false;
                    break;
                }
            }
            return re;
        }
    }
}
