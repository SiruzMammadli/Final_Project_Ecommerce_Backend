namespace finalProject.Common.Wrappers.Responses.Abstracts
{
    public interface IDataResponse<TResponse> : IResponse
    {
        TResponse Data { get; }
    }
}
