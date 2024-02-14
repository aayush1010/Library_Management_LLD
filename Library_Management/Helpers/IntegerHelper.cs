using System;

namespace Library_Management.Helpers
{
    public static class IntegerHelper
    {
        public static Tuple<bool, int> CheckAndGetInteger(string numString)
        {
            var isNum = int.TryParse(numString, out int number);
            return new Tuple<bool, int>(isNum, number);
        }
    }
}

