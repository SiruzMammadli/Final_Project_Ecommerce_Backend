using finalProject.Common.Wrappers.Responses.Abstracts;

namespace finalProject.Common.Wrappers.Responses.Concretes
{
    public class Response : IResponse
    {
        public Response(bool success)
        {
            Success = success;
        }
        public Response(bool success, string message) : this(success)
        {
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
