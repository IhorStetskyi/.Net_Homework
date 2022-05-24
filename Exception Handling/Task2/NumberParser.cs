using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            CheckForExceptionsAndTrim(ref stringValue);
            // Initialize a variables
            int num = 0;
            int ZeroCode = 48;
            int n = stringValue.Length;
            int startChar = SelectStartChar(stringValue);
            bool negative = IsItNegativeValue(stringValue);

            if (negative)
            {
                for (int i = startChar; i < n; i++)
                {
                    // Subtract ZeroCode from the current digit 
                    int tempnum = num * 10 - ((int)stringValue[i] - ZeroCode);
                    if (num != 0 && Math.Sign(tempnum) != Math.Sign(num))
                    {
                        throw new OverflowException("Value is more than Int32");
                    }
                    num = tempnum;
                }
            }
            else
            {
                for (int i = startChar; i < n; i++)
                {
                    // Subtract ZeroCode from the current digit 
                    int tempnum = num * 10 + ((int)stringValue[i] - ZeroCode);
                    if (num != 0 && Math.Sign(tempnum) != Math.Sign(num))
                    {
                        throw new OverflowException("Value is more than Int32");
                    }
                    num = tempnum;
                }
            }
            // Return the answer 
            return num;
        }

        bool IsItNegativeValue(string checkString)
        {
            if (checkString[0] == '-')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        int SelectStartChar(string s)
        {
            if (s[0] == '-' || s[0] == '+')
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

        void CheckForNull(string InputDataString)
        {
            if (InputDataString == null)
            {
                throw new ArgumentNullException("You should write something");
            }
        }

        void CheckFormat(string InputDataString)
        {
            if (InputDataString.Length == 0)
            {
                throw new FormatException("Wrong format");
            }
            for (int i = 0; i < InputDataString.Length; i++)
            {
                if (!"+-1234567890".Contains(InputDataString[i]))
                {
                    throw new FormatException("Wrong format");
                }
                if (i > 0 && !"1234567890".Contains(InputDataString[i]))
                {
                    throw new FormatException("Wrong format");
                }
            }
        }

        void CheckForExceptionsAndTrim(ref string s)
        {
            CheckForNull(s);
            s = s.Trim();
            CheckFormat(s);
        }
    }
}