using finalProject.Common.Wrappers.Responses.Abstracts;
using finalProject.Entities.DTOs.Users;

namespace finalProject.Business.Services.Abstracts.Users
{
    public interface IUserService
    {
        Task<IResponse> Register(RegisterUser_Dto data);
        Task<IResponse> Login(LoginUser_Dto data);
        Task<IDataResponse<GetUser_Dto>> GetCurrentUser(string token);
    }
}
