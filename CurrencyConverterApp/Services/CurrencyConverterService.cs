using CurrencyConverterApp.IServices;

namespace CurrencyConverterApp.Services
{
    public class CurrencyConverterService : ICurrencyConverterService 
    {
        private static string[] units = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        private static string[] teens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private static string[] tens = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        public string ConvertCurrencyToWords(string amount)
        {
            string[] parts = amount.Split('.');
            int dollars = int.Parse(parts[0]);
            int cents = int.Parse(parts[1]);

            string result = "";

            if (dollars == 0 && cents == 0)
            {
                result = "zero dollars";
            }
            else
            {
                result = ConvertToWords(Convert.ToString(dollars)) + " dollars";

                if (cents > 0)
                {
                    result += " and " + ConvertToWords(Convert.ToString(cents)) + " cents";
                }
            }

            return result;
        }

        private static string ConvertToWords(string numberInString)
        {
            int num = Convert.ToInt32(numberInString);
            return num switch
            {
                0 => "",
                < 10 => units[num],
                < 20 => teens[num - 10],
                < 100 => tens[num / 10] + ((num % 10 > 0) ? "-" + units[num % 10] : ""),
                < 1000 => units[num / 100] + " hundred" + ((num % 100 > 0) ? " " + ConvertToWords(Convert.ToString(num % 100)) : ""),
                < 1000000 => ConvertToWords(Convert.ToString(num / 1000)) + " thousand" + ((num % 1000 > 0) ? " " + ConvertToWords(Convert.ToString(num % 1000)) : ""),
                < 1000000000 => ConvertToWords(Convert.ToString(num / 1000000)) + " million" + ((num % 1000000 > 0) ? " " + ConvertToWords(Convert.ToString(num % 1000000)) : ""),
                _ => throw new ArgumentException("Input number is too large.")
            };
        }
    }
}
