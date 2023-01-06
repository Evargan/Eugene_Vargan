
using Gherkin;
using Newtonsoft.Json.Linq;
using System.Text;

namespace WebAPI.Support
{
    abstract class BaseMethod
    {
        protected HttpClient _client;
        protected HttpRequestMessage _request;
        protected HttpRequestMessage _response;
    }

    class UploadMethod: BaseMethod
    {
        public UploadMethod(string token, string file, string dropboxpath)
        {
            _client = new HttpClient();
            HttpRequestMessage _request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(Config.UploadPath),
                Headers = { { "Authorization", $"Bearer {token}" }, { "Dropbox-API-Arg", $"{{\"path\":\"{dropboxpath}\"}}" } },
                Content = new StreamContent(new FileStream(file, FileMode.Open)),
            };
            _request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            HttpResponseMessage _response = _client.SendAsync(_request).Result;
        }
    }

    class GetMetaDataMethod : BaseMethod
    {
        public JObject value;
        public GetMetaDataMethod(string token, string dropboxpath)
        {
            _client = new HttpClient();
            HttpRequestMessage _request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(Config.GetMetaDataPath),
                Headers = {{ "Authorization", $"Bearer {token}" }},
                Content = new StringContent($"{{\"path\": \"{dropboxpath}\"}}", Encoding.UTF8, "application/json")
            };

            _request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage _response = _client.SendAsync(_request).Result;
            value = JObject.Parse(_response.Content.ReadAsStringAsync().Result);
        }
    }

    class DeleteMethod : BaseMethod
    { 
        public DeleteMethod(string token, string dropboxpath)
        {
            _client = new HttpClient();
            HttpRequestMessage _request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(Config.DeletePath),
                Headers = { { "Authorization", $"Bearer {token}" } },
                Content = new StringContent($"{{\"path\": \"{dropboxpath}\"}}", Encoding.UTF8, "application/json")
            };

            _request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage _response = _client.SendAsync(_request).Result;
        }
    }

}
