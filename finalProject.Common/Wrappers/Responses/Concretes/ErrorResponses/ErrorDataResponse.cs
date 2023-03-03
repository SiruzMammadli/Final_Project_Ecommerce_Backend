namespace finalProject.Common.Wrappers.Responses.Concretes.ErrorResponses
{
    public class ErrorDataResponse<TResponse> : DataResponse<TResponse>
    {
        public ErrorDataResponse() : base(default, false)
        {
        }
        public ErrorDataResponse(TResponse data) : base(data, false)
        {
        }
        public ErrorDataResponse(string message) : base(default, false, message)
        {
        }
        public ErrorDataResponse(TResponse data, string message) : base(data, false, message)
        {

        }
    }
}
