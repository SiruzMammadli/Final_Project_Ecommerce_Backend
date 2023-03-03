namespace finalProject.Entities.DTOs.Users
{
    public record struct RegisterUser_Dto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
