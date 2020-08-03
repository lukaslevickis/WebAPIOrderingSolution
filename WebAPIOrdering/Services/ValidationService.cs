using System.Text.RegularExpressions;
using WebAPIOrdering.Interfaces;

namespace WebAPIOrdering.Services
{
    public class ValidationService: IValidationService
    {
        public bool TryValidateData(int[] intArr)
        {
            foreach (int integer in intArr)
            {
                if ((!Regex.Match(integer.ToString(), "^(?:[1-9]|0[1-9]|10)$").Success))
                {
                    return false;
                }
            }
                
            return true;
        }
    }
}
