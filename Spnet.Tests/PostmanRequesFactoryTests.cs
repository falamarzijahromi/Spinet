using Spinet.Bootstrapper;
using Spinet.Bootstrapper.Factories;

namespace Spnet.Tests
{
    public class PostmanRequesFactoryTests
    {
        [InlineData("..\\..\\..\\..\\postman-sample.json")]
        [Theory]
        public void PostmanRequestFactory_RequestJsonPost_ShouldBeValid(string fileAddress)
        {
            var rootObject = PostmanDeserializer.Operate(fileAddress);

            var sut = new PostmanRequestFactory(rootObject);

            var httpRequest = sut.CreateClient("post json");

            var client = new HttpClient();

            var response = client.Send(httpRequest);

            var responseText = response.Content.ReadAsStringAsync().Result;
        }
    }
}