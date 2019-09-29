using System;
using System.Net;
using Newtonsoft.Json;

namespace Trollo.Common.Exceptions
{
    public interface IApiException<TContent>
    {
        HttpStatusCode StatusCode { get; set; }
        TContent Content { get; set; }
    }

    public abstract class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        protected object InternalContent { get; set; }

        protected ApiException(string message, object content = null) : this(HttpStatusCode.BadRequest, message, null,
            content)
        {
        }

        protected ApiException(HttpStatusCode statusCode, string message, object content = null) : this(statusCode,
            message, null, content)
        {
        }

        protected ApiException(HttpStatusCode statusCode, string message, Exception innerException,
            object content = null) : base(message, innerException)
        {
            StatusCode = statusCode;
            InternalContent = content;
        }

        public abstract string GetContent();

        public virtual object GetRawContent()
        {
            return InternalContent;
        }
    }

    public class ApiException<TContent> : ApiException, IApiException<TContent>
    {
        public ApiException(string message, object content = null) : base(message, content)
        {
        }

        public ApiException(HttpStatusCode statusCode, string message, object content = null) : base(statusCode,
            message, content)
        {
        }

        public ApiException(HttpStatusCode statusCode, string message, Exception innerException, object content = null)
            : base(statusCode, message, innerException, content)
        {
        }

        public ApiException(HttpStatusCode statusCode, TContent content = default, string message = "") : base(statusCode, message, content)
        {
        }

        public override string GetContent()
        {
            if (Content != null)
            {
                var body = JsonConvert.SerializeObject(Content);
                return body;
            }

            return string.Empty;
        }

        public TContent Content
        {
            get => (TContent) InternalContent;
            set => InternalContent = value;
        }
    }
}