﻿using System;
using System.IO;
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

        private static string GetJsonRequest(string requestUrl)
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
           return GetJsonRequest(address+yearMonth);
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
            return GetJsonRequest(Url + "&method=getEvent&id=" + eventId);
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
            return GetJsonRequest(Url + "&method=getEventResults&eventid=" + eventId);
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

        public static StreamReader GetRankingStandingsCsv(string lastDayOfMonth, string sex)
        {
            string url = "http://oris.orientacnisporty.cz/ranking_export?date="+lastDayOfMonth+"&sport=1&gender="+sex+"&csv=1";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            return new StreamReader(resp.GetResponseStream());
            
        }
    }
}
