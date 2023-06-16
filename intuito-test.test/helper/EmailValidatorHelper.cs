using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace intuito.test.helper
{
    public class EmailValidatorHelper
    {

        public bool  EmailValidator(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("No puede ser vacio");
            }

            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            bool isValid = Regex.IsMatch(email, emailPattern);
            return isValid;
        }
    }
}
