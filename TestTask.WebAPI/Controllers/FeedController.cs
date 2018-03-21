using System.Web.Http;

using TestTask.SDK.Providers;
using TestTask.SDK.Models;
using System.Text.RegularExpressions;
using System.Web;

namespace TestTask.WebAPI.Controllers
{
    public class FeedController : ApiController
    {
        private const string _valideUrlRegex = @"(http|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";
        
        public IFeed<IItem> Get(ProviderType providerType, string encodedUrl)
        {
            //extract regex check into an extension method -> IsUrlValid()
            if (string.IsNullOrEmpty(encodedUrl) || !Regex.IsMatch(encodedUrl, _valideUrlRegex))
                return null; //it should return BadRequest, or at least throw an exception

            return ProvidersFactory.GetProvider(providerType).GetFeedCollection(HttpUtility.HtmlDecode(encodedUrl));
        }

        public string Post(string idCollection, IItem feed)
        {
            if (feed == null || string.IsNullOrEmpty(idCollection))
                return null;//it should return BadRequest, or at least throw an exception

            return CacheFactory.GetCacher().AddFeedIntoCollection(idCollection, feed);
        }
    }
}
