using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Resources;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace LiveRanking
{
   static class ApiCalls
    {
        static ApiCalls()
        {
            Url = "http://oris.orientacnisporty.cz/API/?format=json";
        }
        private static string Url { get; }

        #region notUsed
        /* [DataContract]
       public class Response
       {
           [DataMember(Name = "copyright")]
           public string Copyright { get; set; }

           [DataMember(Name = "brandLogoUri")]
           public string BrandLogoUri { get; set; }

           [DataMember(Name = "statusCode")]
           public int StatusCode { get; set; }

           [DataMember(Name = "statusDescription")]
           public string StatusDescription { get; set; }

           [DataMember(Name = "authenticationResultCode")]
           public string AuthenticationResultCode { get; set; }

           [DataMember(Name = "errorDetails")]
           public string[] ErrorDetails { get; set; }

           [DataMember(Name = "traceId")]
           public string TraceId { get; set; }

       }

       private static Response GetReguest(string requestUrl, string type)
       {
           try
           {
               HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
               using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
               {
                   if (response != null && response.StatusCode != HttpStatusCode.OK)
                       throw new Exception($"Server error (HTTP {response.StatusCode}: {response.StatusDescription}).");
                   DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Response));
                   object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                   Response jsonResponse = objResponse as Response;
                   return jsonResponse;
               }
           }
           catch (Exception e)
           {
               Console.WriteLine(e.Message);
               return null;
           }
       }*/

        #endregion

        private static string GetReguest(string requestUrl)
        {
            using (var w = new WebClient())
            {
                w.Encoding = Encoding.UTF8;
                var jsonData = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    jsonData = w.DownloadString(requestUrl);
                }
                catch (Exception)
                {
                    // ignored
                }
                return Regex.Unescape(jsonData);
            }
        }
        /*private static T _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        */

       public static string GetRankingEvents(string yearMonth)
       {
           string address = "http://oris.orientacnisporty.cz/RankingZavody?sport=1&date=";
           return GetReguest(address+yearMonth);
       }
        public static void GetCsosClubList()
        {
            
        }

        public static void GetClub()
        {

        }

        public static void GetEventList()
        {
            
        }

        public static string GetEvent(int eventId)
        {
            return GetReguest(Url + "&method=getEvent&id=" + eventId);
        }

        public static void GetEventEntries()
        {
            
        }

        public static void GetUserEventEntries()
        {
            
        }

        public static void GetEventServiceEntries()
        {
            
        }

        public static string GetEventResults(int eventId)
        {
            return GetReguest(Url + "&method=getEventResults&eventid=" + eventId);
        }

        public static void GetUser()
        {
            
        }

        public static void GetRegistration()
        {
            
        }

        public static void GetClubUsers()
        {
            
        }

        public static void GetValidClasses()
        {
            
        }

        public static void CreateEntry()
        {
            
        }

        public static void UpdateEntry()
        {
            
        }

        public static void DeleteEntry()
        {
       
        }

        public static void CreateServiceEntry()
        {
            
        }

        public static void UpdateServiceEntry()
        {
            
        }

        public static void DeleteServiceEntry()
        {
            
        }

        public static void GetEventBalance()  
        {
            
        } 
    }
}
