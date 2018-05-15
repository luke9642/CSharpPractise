using System.Linq;

namespace App4_4
{
    public class DiscountFromPeselComputer : IDiscountFromPeselComputer
    {
        private bool ContainsOnlyDigits(string str)
        {
            return str.All(char.IsDigit);
        }

        private bool CheckSum(string str)
        {
            var arr = str.Select(x => (int)char.GetNumericValue(x)).ToArray();
            var sum = 9 * arr[0] + 7 * arr[1] + 3 * arr[2] + arr[3] + 9 * arr[4] + 7 * arr[5] + 3 * arr[6] +
                      arr[7] +
                      9 * arr[8] + 7 * arr[9];
            return (sum % 10) == arr[10];
        }

        private int GetYearOfBirth(string pesel)
        {
            if (pesel.Length != 11) {
                throw new InvalidPeselException();
            }

            var yearOfBirthSubstring = pesel.Substring(0, 2);
            var monthOfBirthSubstring = pesel.Substring(2, 1) == "0" ? pesel.Substring(3, 1) : pesel.Substring(2, 2);

            if (!ContainsOnlyDigits(pesel) || !CheckSum(pesel)) {
                throw new InvalidPeselException();
            }

            var monthOfBirth = int.Parse(monthOfBirthSubstring);
            var yearOfBirth = int.Parse(yearOfBirthSubstring);
            int result;
            

            if (monthOfBirth > 80)
            {
                result = yearOfBirth + 1800;
            }
            else if (monthOfBirth > 20 && monthOfBirth < 40)
            {
                result =  yearOfBirth + 2000;
            }
            else if (monthOfBirth > 40 && monthOfBirth < 60)
            {
                result =  yearOfBirth + 2100;
            }
            else if (monthOfBirth > 60 && monthOfBirth < 80)
            {
                result =  yearOfBirth + 2200;
            }
            else
            {
                result =  1900 + yearOfBirth;
            }
            
            return result;
        }

        public bool HasDiscount(string pesel)
        {
            var yearOfBirth = GetYearOfBirth(pesel);
            var age = 2018 - yearOfBirth;
            
            if (age < 0)
                throw new InvalidPeselException();

            return age < 18 || age > 65;
        }
    }
}