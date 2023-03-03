namespace finalProject.Common.Wrappers.Responses.Concretes.SuccessResponses
{
    public class SuccessResponse : Response
    {
        public SuccessResponse() : base(true)
        {
        }
        public SuccessResponse(string message) : base(true, message)
        {
        }
    }
}
