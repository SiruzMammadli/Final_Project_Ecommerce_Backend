namespace finalProject.Common.Wrappers.Responses.Abstracts
{
    public interface IResponse
    {
        bool Success { get; }
        string Message { get; }
    }
}
