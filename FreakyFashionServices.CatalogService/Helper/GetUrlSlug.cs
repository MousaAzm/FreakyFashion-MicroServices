using System.Text;
using System.Text.RegularExpressions;

namespace FreakyFashionServices.CatalogService.Helper
{
    public static class GetUrlSlug
    {
        public static string ToUrlSlug(string? value)
        {
        
            value = value?.ToLowerInvariant();

            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value!);

            value = Encoding.ASCII.GetString(bytes);

            value = Regex.Replace(value, @"\-", "" , RegexOptions.Compiled);

            value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);

            value = Regex.Replace(value, @"[^\w\s\p{Pd}]", "", RegexOptions.Compiled);

            value = value.Trim('-');

            value = Regex.Replace(value, @"([-]){2,}", "$1", RegexOptions.Compiled);

            return value;
        }
    }
}
