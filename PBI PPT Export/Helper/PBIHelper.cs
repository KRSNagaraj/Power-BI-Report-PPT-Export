using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;

namespace PBI_PPT_Export.Helper
{
    public class PBIHelper
    {
        private static string _bearerToken = "";
        public static IList<Report> getPBIObjects()
        {
            _bearerToken = getPBIBearerToken();
            return getPBIObjects(_bearerToken);
        }
     
        public static string getPBIBearerToken()
        {
            string _bearer = "",  url = "https://app.powerbi.com/";
            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";

            (request as HttpWebRequest).Host = "app.powerbi.com";

            request.Headers.Add(ConfigurationManager.AppSettings["PBICookie02"].ToString());
            var response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            var _responseStream = response.GetResponseStream();

            using (var reader = new StreamReader(_responseStream))
            {
                while (!reader.EndOfStream)
                {
                    var s = reader.ReadLine();
                    if (s.Contains("powerBIAccessToken"))
                    {
                        var d = s.Split('\'');
                        _bearer = d[1];
                        break;
                    }
                }
            }

            var _http = response as HttpWebResponse;

            return _bearer;
        }

        internal static string ExportToPPT(Report report)
        {
            
            string url = string.Concat("https://wabi-north-europe-redirect.analysis.windows.net/export/reports/", report.id, "/pptx");
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";

            (request as HttpWebRequest).Host = "wabi-north-europe-redirect.analysis.windows.net";
            (request as HttpWebRequest).Accept = "application/json, text/plain, */*";
            (request as HttpWebRequest).ContentType = "application/json;charset=utf-8";
            request.Headers.Add("X-PowerBI-User-GroupId: 06fbba57-d637-4eed-8a6e-4723752d4990");

            request.Headers.Add("ActivityId: 2a7c1655-f1e4-40e5-9673-93de6e192760");
            request.Headers.Add("RequestId: 99dd0508-89a4-2fa4-143f-f4269cb9a966");
            request.Headers.Add("Authorization: Bearer " + _bearerToken);
            (request as HttpWebRequest).Referer = "https://app.powerbi.com/groups/06fbba57-d637-4eed-8a6e-4723752d4990/reports/ebfb67f1-6a67-4dd3-ab98-affa58dba2be/ReportSection1";
            request.Headers.Add("Origin: https://app.powerbi.com");
            request.Headers.Add("DNT: 1");
            //(request as HttpWebRequest).Connection = "Keep-Alive";
            request.Headers.Add("Pragma: no-cache");
            request.Headers.Add("Cache-Control: no-cache");

            string postData = "{\"approvedResources\":[]}";

            var _postLength = postData.Length;
            var _postBytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = _postLength;

            var stream = request.GetRequestStream();
            stream.Write(_postBytes, 0, _postLength);
            stream.Close();

            var response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            string _objects;
            //string _fileLocation = HttpContext.Current.Server.MapPath("~/ppt");
            string _fileLocation = Path.GetTempPath();
            string _file = _fileLocation + "/" + Guid.NewGuid().ToString() + ".pptx";

            using (Stream output = File.OpenWrite(_file))
            using (var _responseStream = response.GetResponseStream())
            {
                _responseStream.CopyTo(output);
            }

            return _file;
        }

        public static IList<Report> getPBIObjects(string bearerToken)
        {
            string  url = "https://wabi-north-europe-redirect.analysis.windows.net/powerbi/metadata/groupmetadata/";
            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";

            (request as HttpWebRequest).Host = "wabi-north-europe-redirect.analysis.windows.net";
            (request as HttpWebRequest).Accept = "application/json, text/plain, */*";
            request.Headers.Add("X-PowerBI-User-GroupId: 06fbba57-d637-4eed-8a6e-4723752d4990");
            request.Headers.Add("ActivityId: 2a7c1655-f1e4-40e5-9673-93de6e192760");
            request.Headers.Add("RequestId: 99dd0508-89a4-2fa4-143f-f4269cb9a966");
            request.Headers.Add("Authorization: Bearer " + bearerToken);
            (request as HttpWebRequest).Referer = "https://app.powerbi.com/recentlyviewed";
            request.Headers.Add("Origin: https://app.powerbi.com");
            request.Headers.Add("DNT: 1");
            //(request as HttpWebRequest).Connection = "Keep-Alive";
            request.Headers.Add("Pragma: no-cache");
            request.Headers.Add("Cache-Control: no-cache");

            var response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            var _responseStream = response.GetResponseStream();

            string _objects;
            using (var reader = new StreamReader(_responseStream))
            {
                _objects = reader.ReadToEnd();
            }
            string[] _split = new string[] { "\"reports\":" };
            
            var s = _objects.Split(_split, StringSplitOptions.RemoveEmptyEntries);
            string[] _split2 = new string[] { "}]" };
            var s2 = s[1].Split(_split2, StringSplitOptions.RemoveEmptyEntries);
            var s3 = s2[0].Split('{');
            IList<Report> _result = new List<Report>();
            Parallel.For(1, s3.Length - 1, count =>
            {
                _result.Add(Json.Decode<Report>("{ " + (s3[count].Contains("},") ? s3[count].Replace("},", "}") : s3[count - 1] + "}")));
            });
        
            return _result;
        }



    }

    public class Report
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public int packageId { get; set; }
        public string packageVersion { get; set; }
        public int layoutOptimization { get; set; }
        public int id { get; set; }
        public int modelId { get; set; }
        public string objectId { get; set; }
        public int permissions { get; set; }
        public bool hasExploration { get; set; }
        public List<int> featuresV2 { get; set; }
        public bool? isFromPbix { get; set; }
        public int? linguisticSchemaId { get; set; }
    }
}