using System.Net;

namespace app_api
{
    public class User
    {
        public int Id { get; set; }
        //SA FAC ASTA SA FIE UNIC
        public string UserName { get; set; } = String.Empty;
        public string EMail { get; set; } = String.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
