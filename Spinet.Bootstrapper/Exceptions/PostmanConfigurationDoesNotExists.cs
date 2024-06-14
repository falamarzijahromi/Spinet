using System;

namespace Spinet.Bootstrapper.Exceptions
{
    public class PostmanConfigurationDoesNotExists : Exception
    {
        private PostmanConfigurationDoesNotExists(string message) : base(message) { }

        public static void Check(bool fileExists, string fileAddress)
        {
            if (fileExists)
                return;

            var message = $"Postman json file configuration on address: {fileAddress} does not exists!";
            var exception = new PostmanConfigurationDoesNotExists(message);
            throw exception;
        }
    }
}
