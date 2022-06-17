using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace ZHANG_Thierry_TP2_ST2API
{
    public class Api
    {
        public String key;
        public Api(string k)
        {
            key = k;
        }
        
        public OpenWeather getWeatherData(string url)
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format(url + key));
            WebReq.Method = "GET";
            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<OpenWeather>(jsonString);
        }
    }
}
