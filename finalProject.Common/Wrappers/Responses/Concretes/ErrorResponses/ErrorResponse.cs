namespace finalProject.Common.Wrappers.Responses.Concretes.ErrorResponses
{
    public class ErrorResponse : Response
    {
        public ErrorResponse() : base(false)
        {
        }
        public ErrorResponse(string message) : base(false, message)
        {
        }
    }
}
