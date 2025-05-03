using PooII.Entities;

namespace PooII.Helpers
{
    public static class ApiKeyHelper
    {
        private static readonly Random random = new Random();
        public static string GenerarApiKey()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] apiKeyChars = new char[32];
            for (int i = 0; i < apiKeyChars.Length; i++)
            {
                apiKeyChars[i] = chars[random.Next(chars.Length)];
            }
            return new string(apiKeyChars);
        }

        public static string GenerarLogin(Persona persona)
        {
            string login = $"{persona.PNombre}{persona.PApellido[0]}{persona.Id}";
            return login;
        }
    }
}