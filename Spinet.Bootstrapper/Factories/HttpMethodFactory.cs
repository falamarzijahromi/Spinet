using System.Net.Http;

namespace Spinet.Bootstrapper.Factories
{
    public static class HttpMethodFactory
    {
        public static HttpMethod Create(string method)
        {
            var normalizedMethod = method.ToUpper();

            return new HttpMethod(normalizedMethod);
        }
    }
}
