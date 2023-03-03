using finalProject.Common.Repositories.EntityFramework;
using finalProject.DataAccess.Contexts;
using finalProject.DataAccess.Repositories.Abstracts.Users;
using finalProject.Entities.Concretes.Users;

namespace finalProject.DataAccess.Repositories.Concretes.Users
{
    public class UserRepository : EfRepository<User, ApplicationDbContext>, IUserRepository
    {
    }
}
