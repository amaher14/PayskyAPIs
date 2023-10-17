namespace Core.Models.MobileModels.Login
{

    public class MobileLoginResponseDto
    {
    
        public UserDTO User { get; set; }
        public int OTP { get; set; }

        public MobileLoginResponseDto()
        { }
            public MobileLoginResponseDto(UserDTO user, int oTP)
        {
            User = user;
            OTP = oTP;
        }

    }

}
