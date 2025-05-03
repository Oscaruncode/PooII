namespace PooII.JWT.Config
{

    [Serializable]
    public class JwtRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public JwtRequest() { }

        public JwtRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
