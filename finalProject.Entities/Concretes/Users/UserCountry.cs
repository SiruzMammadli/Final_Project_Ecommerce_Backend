using finalProject.Common.Entities.Abstracts;
using finalProject.Common.Entities.Concretes;

namespace finalProject.Entities.Concretes.Users
{
    public class UserCountry : BaseEntity, IEntity
    {
        public string CountryName { get; set; }
    }
}
