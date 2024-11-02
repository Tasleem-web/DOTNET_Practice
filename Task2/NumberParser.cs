using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue == null) throw new ArgumentNullException("Input string cannot be null");

            stringValue = stringValue.Trim();

            if (string.IsNullOrEmpty(stringValue)) throw new FormatException("Input string cannot be empty.");


            bool isNegative = false;
            int result = 0;
            int startIndex = 0;

            if (stringValue[0] == '-')
            {
                isNegative = true;
                startIndex = 1;
            }
            else if (stringValue[0] == '+')
            {
                startIndex = 1;
            }

            for (int i = startIndex; i < stringValue.Length; i++)
            {
                char c = stringValue[i];
                if (c < '0' || c > '9')
                {
                    throw new FormatException("Input string contains non-numeric characters.");
                }

                try
                {
                    checked
                    {
                        int digit = c - '0';
                        if (isNegative)
                        {
                            if (result < (int.MinValue + digit) / 10)
                            {
                                throw new OverflowException("The number is too large to fit in an Int32.");
                            }
                            result = result * 10 - digit;
                        }
                        else
                        {
                            if (result > (int.MaxValue - digit) / 10)
                            {
                                throw new OverflowException("The number is too large to fit in an Int32.");
                            }
                            result = result * 10 + digit;
                        }
                    }
                }
                catch (OverflowException)
                {
                    throw new OverflowException("The number is too large to fit in an Int32.");
                }
            }

            return result;
        }
    }
}
