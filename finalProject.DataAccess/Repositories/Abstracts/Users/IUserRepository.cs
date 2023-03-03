using finalProject.Common.Repositories.Abstracts;
using finalProject.Common.Wrappers.Responses.Abstracts;
using finalProject.Entities.Concretes.Users;
using finalProject.Entities.DTOs.Users;

namespace finalProject.DataAccess.Repositories.Abstracts.Users
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
