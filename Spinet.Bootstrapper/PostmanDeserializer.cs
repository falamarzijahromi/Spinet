using Spinet.Bootstrapper.Exceptions;
using System;
using System.IO;
using System.Text.Json;

namespace Spinet.Bootstrapper
{
    public static class PostmanDeserializer
    {
        public static RootObject Operate(string fileAddress)
        {
            var fullFileAddress = EvaluateFileAddress(fileAddress);

            var postmanJsonFileInfo = new FileInfo(fullFileAddress);

            PostmanConfigurationDoesNotExists.Check(postmanJsonFileInfo.Exists, fileAddress);

            var postmanJson = File.ReadAllText(fullFileAddress);

            var result = JsonSerializer.Deserialize<RootObject>(postmanJson);

            return result;
        }

        private static string EvaluateFileAddress(string fileAddress)
        {
            var currentDir = Environment.CurrentDirectory;

            var fullAddress = Path.Combine(currentDir, fileAddress);

            return fullAddress;
        }
    }
}
