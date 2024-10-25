namespace AuDote.API.Extensions
{
    public static class StringExtensions
    {
        public static string ToAuDoteEmail(this string str)
        {
            return $"{str}@audote.com.br";
        }
    }
}
