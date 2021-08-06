using System;
using System.Net;

namespace Common.Exceptions.BadRequest
{
    public class BaseBadRequestException : Exception
    {
        public static int HttpCode { get {
                return Convert.ToInt32(HttpStatusCode.BadRequest);
            } 
        }
        public string CustomMessage { get; set; }
    }
}
