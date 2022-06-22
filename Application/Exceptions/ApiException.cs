using System;
using System.Net;
using System.Globalization;

namespace Application.Exceptions
{
    public class ApiException : Exception
    { 
        private readonly int? _httpStatusCode;

        public ApiException() : base() {  }

        public ApiException(HttpStatusCode httpStatusCode) : base() 
        {
            _httpStatusCode = (int) httpStatusCode;
        }

        public ApiException(string message) : base(message) { }
        
        public ApiException(HttpStatusCode httpStatusCode, string message) : base(message)
        {
            _httpStatusCode = (int) httpStatusCode;
        }

        public ApiException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        { 
        }

        public ApiException(HttpStatusCode httpStatusCode, string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        { 
            _httpStatusCode = (int) httpStatusCode;
        }

        public int? StatusCode { get { return _httpStatusCode; } }
    }
}
