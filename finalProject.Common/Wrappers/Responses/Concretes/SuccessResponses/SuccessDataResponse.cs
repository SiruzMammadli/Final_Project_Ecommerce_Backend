namespace finalProject.Common.Wrappers.Responses.Concretes.SuccessResponses
{
    public class SuccessDataResponse<TResponse> : DataResponse<TResponse>
    {
        public SuccessDataResponse() : base(default, true)
        {
        }
        public SuccessDataResponse(TResponse data) : base(data, true)
        {
        }
        public SuccessDataResponse(string message) : base(default, true, message)
        {
        }
        public SuccessDataResponse(TResponse data, string message) : base(data, true, message)
        {
        }
    }
}
