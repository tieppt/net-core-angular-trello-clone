using System.Net;

namespace Trollo.Common.Exceptions
{
    public class NotFoundException : ApiException
    {
        public NotFoundException(string type, object key) : base(HttpStatusCode.NotFound,
            $"Could not find {key} for {type}.")
        {
        }

        public override string GetContent()
        {
            return Message;
        }
    }
}