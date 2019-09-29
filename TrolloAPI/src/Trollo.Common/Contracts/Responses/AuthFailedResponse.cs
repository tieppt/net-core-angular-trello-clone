using System.Collections.Generic;

namespace Trollo.Common.Contracts.Responses
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}