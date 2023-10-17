namespace Core.Models.MobileModels.Login
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AuthenticationToken { get; set; }
        public string userType { get; set; }
        public int TokenExpInMin { get; set; }

    }
}
