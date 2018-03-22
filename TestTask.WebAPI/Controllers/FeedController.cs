using System.Web.Http;
using System.Web;
using TestTask.SDK;
using System.Text.RegularExpressions;
using TestTask.Data;

namespace TestTask.WebAPI.Controllers
{
    public class FeedController : ApiController
    {
        private const string _valideUrlRegex = @"(http|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";

        public IFeed<IItem> Get(ProviderType providerType, string encodedUrl)
        {
            if (string.IsNullOrEmpty(encodedUrl) || !Regex.IsMatch(encodedUrl, _valideUrlRegex))
                return null;
            
            return ProvidersFactory.GetProvider(providerType).GetFeedCollection(HttpUtility.HtmlDecode(encodedUrl));
        }

        //public string Post(string idCollection, IItem feed)
        //{
        //    if (feed == null || string.IsNullOrEmpty(idCollection))
        //        return null;

        //    return CacheFactory.GetCacher().AddItemIntoFeed(idCollection, feed);
        //}
    }

    
}
