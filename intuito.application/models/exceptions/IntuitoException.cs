using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace intuito.application.models.exceptions
{
    public class IntuitoException : BaseCustomException
    {
        public IntuitoException(string message = "Exception", string desciption = "", int statuscode = 500) : base(message, desciption, statuscode)
        {

        }
    }
}
