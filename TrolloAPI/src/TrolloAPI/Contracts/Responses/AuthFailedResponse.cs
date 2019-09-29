using System.Collections.Generic;

namespace TrolloAPI.Contracts.Responses
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}