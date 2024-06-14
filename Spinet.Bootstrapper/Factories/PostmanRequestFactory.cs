using System;
using System.Linq;
using System.Net.Http;

namespace Spinet.Bootstrapper.Factories
{
    public class PostmanRequestFactory
    {
        private readonly RootObject rootObject;

        public PostmanRequestFactory(RootObject rootObject)
        {
            this.rootObject = rootObject ?? throw new ArgumentNullException("postman configuration object is null!");
        }

        public HttpRequestMessage CreateClient(string name)
        {
            var relatedItem = FindItem(name);

            var requestUri = relatedItem.request.url.raw;

            var method = HttpMethodFactory.Create(relatedItem.request.method);

            var request = new HttpRequestMessage(method, requestUri);

            HttpHeadersFactory.FillHeaders(request.Headers, relatedItem.request.header);

            request.Content = HttpContentFactory.Create(relatedItem.request.body);

            return request;
        }

        public Item FindItem(string name)
        {
            var result = rootObject.item.SingleOrDefault(i => i.name == name);

            return result ?? throw new MissingMemberException($"item {name} does not exist in postman configuraiton file!");    
        }
    }
}
