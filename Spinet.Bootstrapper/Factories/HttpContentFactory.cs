using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Text;

namespace Spinet.Bootstrapper.Factories
{
    public static class HttpContentFactory
    {
        private const string Raw = "raw";
        private const string Form = "formdata";
        private const string Data = "urlencoded";

        private const string Json = "json";
        private const string Text = "text";

        public static HttpContent Create(Body body)
        {
            return body.mode switch
            {
                Raw => CreateRawContent(body),
                Form => CreateFormContent(body),
                Data => CreateDataContent(body),
                _ => throw new NotImplementedException($"Body type {body.mode} does not supported!"),
            };
        }

        private static HttpContent CreateDataContent(Body body)
        {
            var content = new MultipartFormDataContent();

            foreach (var item in body.formdata)
            {
                var innerContent = CreateRawContent(item.type, item.value);

                content.Add(innerContent, item.key);
            }

            return content;
        }

        private static HttpContent CreateFormContent(Body body)
        {
            var contents = new Dictionary<string, string>();

            foreach (var item in body.urlencoded)
                contents.Add(item.key, item.value);

            return new FormUrlEncodedContent(contents);
        }

        private static HttpContent CreateRawContent(Body body)
        {
            return CreateRawContent(body.options.raw.language, body.raw);
        }

        private static HttpContent CreateRawContent(string language, string content)
        {
            var mediaType = language switch
            {
                Json => MediaTypeNames.Application.Json,
                Text => MediaTypeNames.Text.Plain,
                _ => throw new NotImplementedException($"Raw body type {language} does not supported!"),
            };

            return new StringContent(content, Encoding.UTF8, mediaType);
        }
    }
}
