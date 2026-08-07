using System.Linq;

namespace NUnitPrograms
{
    public class PasswordValidator
    {
        public bool IsValid(string password)
        {
            if (password.Length < 8)
                return false;

            bool hasUpper = password.Any(char.IsUpper);
            bool hasDigit = password.Any(char.IsDigit);

            return hasUpper && hasDigit;
        }
    }
}