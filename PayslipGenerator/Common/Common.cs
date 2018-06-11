using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayslipGenerator.Common
{
    class common
    {
        private static common instance;

        private common() { }

        public static common Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new common();
                }
                return instance;
            }
        }
        public int RoundoffValue(double val)
        {
            int result = Convert.ToInt32(Math.Ceiling(val));
            return result;
        }

        public bool IsInteger(string userInput)
        {
            int value;
            return int.TryParse(userInput, out value);
        }

        public bool CheckSuperRateRange(int value)
        {
            if (value >= 0 && value <= 12)
                return true;
            else
                return false;
        }
    }
}
