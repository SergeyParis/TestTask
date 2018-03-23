using System.Web.Http;
using System.Web;
using TestTask.SDK;
using System.Text.RegularExpressions;
using TestTask.WebAPI;

namespace TestTask.WebAPI
{
    public class FeedController : ApiController
    {
        public IFeed<IItem> Get(ProviderType providerType, string encodedUrl)
        {
            if (string.IsNullOrEmpty(encodedUrl) || !encodedUrl.IsvalideUrl())
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
