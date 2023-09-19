using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Helpers
{
    public static class Request
    {
        public static string Post(string ApiUrl, string objx, string token = "")
        {
            HttpClient httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri(MutualConstants.settings.ApiUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders.Add("AcceptLanguage", System.Threading.Thread.CurrentThread.CurrentCulture.ToString());

            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Add("token", token);

            }
            string obj = "";

            StringContent httpContent = new StringContent(objx, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PostAsync(ApiUrl, httpContent).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                obj = jsonString.Result;
            }
            httpClient.Dispose();
            return obj;
        }

        public static string Get(string ApiUrl, string token = "")
        {
            HttpClient httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri(MutualConstants.settings.ApiUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders.Add("AcceptLanguage", System.Threading.Thread.CurrentThread.CurrentCulture.ToString());

            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Add("token", token);

            }
            string obj = "";

            HttpResponseMessage response = httpClient.GetAsync(ApiUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                obj = jsonString.Result;
            }
            httpClient.Dispose();
            return obj;
        }

        public static string Put(string url, string postData)
        {
            string result = string.Empty;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);

                var data = Encoding.UTF8.GetBytes(postData);

                request.Headers.Add("AcceptLanguage", System.Threading.Thread.CurrentThread.CurrentCulture.ToString());

                request.ContentType = "application/json; charset=utf-8";
                request.Method = "PUT";
                request.Accept = "application/json; charset=utf-8";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                result = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public static string Delete(string url)
        {
            string result = string.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "DELETE";
                request.Headers.Add("AcceptLanguage", System.Threading.Thread.CurrentThread.CurrentCulture.ToString());

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();

                }
            }
            catch
            {
            }
            return result;
        }

    }
}
