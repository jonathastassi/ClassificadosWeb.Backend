namespace ClassificadosWeb.Domain.Extensions
{
    public static class HashExtension
    {
        public static string HashString(this string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool CompareHash(this string hash, string text)
        {
            return BCrypt.Net.BCrypt.Verify(text, hash);
        }
    }
}