namespace Core.Settings
{
    public class TokenSetting
    {
        public int TokenExpiredInMin { set; get; }
        public int RefreshTokenExpiredInMin { set; get; }
        public string Key { set; get; }
        public string Issuer { set; get; }
        public string Audience { set; get; }
        public string Subject { set; get; }
    }
}
