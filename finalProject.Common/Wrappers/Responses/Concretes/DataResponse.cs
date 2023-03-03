using finalProject.Common.Wrappers.Responses.Abstracts;

namespace finalProject.Common.Wrappers.Responses.Concretes
{
    public class DataResponse<TResponse> : Response, IDataResponse<TResponse>
    {
        public DataResponse(TResponse data, bool success) : base(success)
        {
            Data = data;
        }
        public DataResponse(TResponse data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public TResponse Data { get; }
    }
}
