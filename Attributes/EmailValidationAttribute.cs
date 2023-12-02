using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Net.Mail;

namespace JwtAuthenticationWithMiddlewares.Attributes
{

    [AttributeUsage(AttributeTargets.Property)]
    public class EmailValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            string? email = value as string;

            if (email == null)
            {
                return false;
            }
            else
            {
                try
                {
                    // try to crate mail address
                    MailAddress emailAddress = new MailAddress(email);

                    return true;
                }
                catch (Exception ex) 
                {
                    return false;
                }
            }
        }



        public override string FormatErrorMessage(string name)
        {
            string errorMessage = "Invalid email address";
            return String.Format(CultureInfo.CurrentCulture, errorMessage, name);
        }
    }
}
