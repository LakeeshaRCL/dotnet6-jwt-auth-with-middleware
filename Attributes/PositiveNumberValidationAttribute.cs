using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net.Mail;

namespace JwtAuthenticationWithMiddlewares.Attributes
{
    public class PositiveNumberValidationAttribute: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            int? number = (int)value;

            if (number == null)
            {
                return false;
            }
            else if(number <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        public override string FormatErrorMessage(string name)
        {
            string errorMessage = "Number should be greater than zero";
            return String.Format(CultureInfo.CurrentCulture, errorMessage, name);
        }

    }
}
