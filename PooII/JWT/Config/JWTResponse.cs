namespace PooII.JWT.Config
{

    [Serializable]
    public class JwtResponse
    {
        public string Token { get; }

        public JwtResponse(string token )
        {
            Token = token;
        }
    }
}
