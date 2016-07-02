using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace BL.Import
{
  public static class ApiCalls
    {
        static ApiCalls()
        {
            Url = "http://oris.orientacnisporty.cz/API/?format=json";
        }
        private static string Url { get; }

        private static string GetJsonReguest(string requestUrl)
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
        
       public static string GetRankingEventsPageContent(string yearMonth)
       {
           string address = "http://oris.orientacnisporty.cz/RankingZavody?sport=1&date=";
           return GetJsonReguest(address+yearMonth);
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
            return GetJsonReguest(Url + "&method=getEvent&id=" + eventId);
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
            return GetJsonReguest(Url + "&method=getEventResults&eventid=" + eventId);
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
