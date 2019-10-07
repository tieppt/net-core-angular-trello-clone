using System.Net;

namespace Trollo.Common.Exceptions
{
    public class UnauthorizedException: ApiException
    {
        public UnauthorizedException(string message = "Unauthorized") : base(HttpStatusCode.NotFound, message)
        {
        }

        public override string GetContent()
        {
            return Message;
        }
    }
}