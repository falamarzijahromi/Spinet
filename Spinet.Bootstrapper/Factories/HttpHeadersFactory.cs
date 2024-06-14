using System.Net.Http.Headers;

namespace Spinet.Bootstrapper.Factories
{
    public static class HttpHeadersFactory
    {
        public static void FillHeaders(HttpRequestHeaders requestHeaders, Header[] headers)
        {
            foreach (Header header in headers) 
            {
                requestHeaders.Add(header.key, header.value);
            }
        }
    }
}
