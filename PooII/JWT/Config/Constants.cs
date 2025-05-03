using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PooII.JWT.Config
{
    public static class Constants
    {
        public const string LOGIN_URL = "/authenticate";
        public const string HEADER_AUTHORIZATION_KEY = "Authorization";
        public const string TOKEN_BEARER_PREFIX = "Bearer ";

        public const string SUPER_SECRET_KEY = "ZnJhc2VzbGFyZ2FzcGFyYWNvbG9jYXJjb21vY2xhdmVlbnVucHJvamVjdG9kZWVtZXBsb3BhcmFqd3Rjb25zcHJpbmdzZWN1cml0eQ==bWlwcnVlYmFkZWVqbXBsb3BhcmFiYXNlNjQ=";
        public const long TOKEN_EXPIRATION_TIME = 864_000; 

        public static SymmetricSecurityKey GetSigningKeyB64(string secret)
        {
            var keyBytes = Convert.FromBase64String(secret);
            return new SymmetricSecurityKey(keyBytes);
        }

        public static SymmetricSecurityKey GetSigningKey(string secret)
        {
            var keyBytes = Encoding.UTF8.GetBytes(secret);
            return new SymmetricSecurityKey(keyBytes);
        }
    }

}
