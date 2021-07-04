using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OMDBAPIAPI.Models
{
    public class MoviesDAL
    {
        public string CallAPI(string searchType, string title)
        {
            string key = "e02c7987";
            string url = @$"http://www.omdbapi.com/?{searchType}={title}&apikey={key}";
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string JSON = rd.ReadToEnd();
            rd.Close();
            return JSON;

        }

        public Movies GetMovie(string title)
        {
            string json = CallAPI("t", title);
            Movies m = JsonConvert.DeserializeObject<Movies>(json);
            return m;
        }

    }
}
