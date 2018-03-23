using System.Text.RegularExpressions;

namespace TestTask.WebAPI
{
    public static class ExtensionsString
    {
        private const string _valideUrlRegex = @"(http|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";

        public static bool IsvalideUrl(this string url) => Regex.IsMatch(url, _valideUrlRegex);
    }
}