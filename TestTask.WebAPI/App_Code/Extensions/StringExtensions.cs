using System.Text.RegularExpressions;

namespace TestTask.WebAPI
{
    public static class StringExtensions
    {
        private const string _valideUrlRegex = @"(http|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";

        public static bool IsUrlValid(this string url) => Regex.IsMatch(url, _valideUrlRegex);
    }
}