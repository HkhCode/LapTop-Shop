namespace Laptop_shop.Utilities
{
    public class PasswordGenerator
    {
        private static readonly string CapitalLetters = "QWERTYUIOPASDFGHJKLZXCVBNM";
        private static readonly string SmallLetters = "qwertyuiopasdfghjklzxcvbnm";
        private static readonly string Digits = "0123456789";
        public static string Generate(int Length)
        {
            Random random = new Random();
            string Password = string.Empty;
            for(int i =0;i<Length;i++)
            {
                int select = random.Next(1, 4);
                int CharSelect;
                switch(select)
                {
                    case 1:
                        CharSelect = random.Next(0 , CapitalLetters.Length);
                        Password += CapitalLetters[CharSelect];
                        break;
                    case 2:
                        CharSelect = random.Next(0, SmallLetters.Length);
                        Password += SmallLetters[CharSelect];
                        break;
                    case 3:
                        CharSelect = random.Next(0, Digits.Length);
                        Password += Digits[CharSelect];
                        break;
                    default:
                        throw new Exception("Something Went Wrong , Try Again!");
                        break;
                }
            }
            return Password;
        }
    }
}
