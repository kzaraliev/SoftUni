using System;

namespace _04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            if (!IfContainRecomendedChars(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!IfContainLetterDigits(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!IfContainRecomendedDigits(password))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            
            ValidPassword(password);

        }

        static void ValidPassword(string password)
        {
            if (IfContainRecomendedChars(password)
                && IfContainLetterDigits(password)
                && IfContainRecomendedDigits(password))
            {
                Console.WriteLine("Password is valid");
            }

        }

        static bool IfContainRecomendedDigits(string password)
        {
            bool isValid = true;
            int count = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 48 && password[i] <= 57)
                {
                    count++;
                }
            }
            if (count < 2)
            {
                isValid = false;
            }
            return isValid;
        }

        static bool IfContainLetterDigits(string password)
        {
            bool isValid = true;
            for (int i = 0; i < password.Length; i++)
            {
                if (!(password[i] >= 48 && password[i] <= 57 ||
                    password[i] >= 65 && password[i] <= 90 ||
                    password[i] >= 97 && password[i] <= 122))
                {
                    isValid = false;
                    return isValid; ;
                }
            }
            return isValid;
        }

        static bool IfContainRecomendedChars(string password)
        {
            bool isValid = true;
            if (password.Length < 6 || password.Length > 10)
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
