using finalProject.Business.Services.Abstracts.Users;
using finalProject.Common.Secure.Hashing;
using finalProject.Common.Secure.Jwt;
using finalProject.Common.Wrappers.Responses.Abstracts;
using finalProject.Common.Wrappers.Responses.Concretes.ErrorResponses;
using finalProject.Common.Wrappers.Responses.Concretes.SuccessResponses;
using finalProject.DataAccess.Repositories.Abstracts.Users;
using finalProject.Entities.Concretes.Users;
using finalProject.Entities.DTOs.Users;
using System.IdentityModel.Tokens.Jwt;

namespace finalProject.Business.Services.Concretes.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IDataResponse<GetUser_Dto>> GetCurrentUser(string token)
        {
            JwtSecurityTokenHandler handler = new();
            JwtSecurityToken security_token = handler.ReadJwtToken(token);
            string user_id = security_token.Claims.FirstOrDefault(c => c.Type == "_id")?.Value;

            if (user_id is not null)
            {
                try
                {
                    User current_user = await _userRepository.GetByIdAsync(Guid.Parse(user_id));
                    return new SuccessDataResponse<GetUser_Dto>(new GetUser_Dto()
                    {
                        Id = current_user.Id.ToString(),
                        FirstName = current_user.FirstName,
                        LastName = current_user.LastName,
                        Email = current_user.Email,
                        Role = current_user.Role,
                    });
                }
                catch (Exception ex)
                {
                    return new ErrorDataResponse<GetUser_Dto>(ex.Message);
                }
            }
            return new ErrorDataResponse<GetUser_Dto>("İstifadəçi tapılmadı");
        }

        public async Task<IResponse> Login(LoginUser_Dto data)
        {
            try
            {
                User checked_user = await _userRepository.GetSingleAsync(u => u.Email.Equals(data.Email));
                if (checked_user is null) return new ErrorResponse("Email və ya şifrə səhvdir!");

                bool verified_password = HashGenerator.VerifyPassword(data.Password, checked_user.PasswordHash, checked_user.PasswordSalt);
                if (verified_password is false) return new ErrorResponse("Email və ya şifrə səhvdir!");

                string new_token = TokenGenerator.GenerateToken(checked_user);
                return new SuccessResponse(new_token);
            }
            catch (Exception)
            {
                return new ErrorResponse("Sayta daxil olarkən gözlənilməz xəta baş verdi!");
            }
        }

        public async Task<IResponse> Register(RegisterUser_Dto data)
        {
            byte[] passwordHash, passwordSalt;
            HashGenerator.GeneratePasswordHash(data.Password, out passwordHash, out passwordSalt);
            try
            {
                User check_user_mail = await _userRepository.GetSingleAsync(u => u.Email.Equals(data.Email));

                if (check_user_mail is null)
                {
                    await _userRepository.InsertAsync(new User()
                    {
                        FirstName = data.FirstName,
                        LastName = data.LastName,
                        Email = data.Email,
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt
                    });
                    return new SuccessResponse("Qeydiyyat uğurla nəticələndi!");
                }
                return new ErrorResponse("Belə bir istifadəçi artıq mövcuddur!");
            }
            catch (Exception)
            {
                return new ErrorResponse("Qeydiyyat zamanı gözlənilməz xəta baş verdi!");
            }
        }
    }
}
