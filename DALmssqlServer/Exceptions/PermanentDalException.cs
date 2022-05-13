using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALmssqlServer
{
    public class PermanentDalException : Exception
    {
        public readonly string? ExceptionMessage;
        public readonly string Message;
        public PermanentDalException(string message, string? exceptionmessage = null) : base(message)
        {
            Message = message;
            ExceptionMessage = exceptionmessage;
        }

        public string GetFullError()
        {
            return $"{Message} {ExceptionMessage}";
        }

    }
}
