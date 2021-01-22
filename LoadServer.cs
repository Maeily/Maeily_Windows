using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Maeily_Windows
{
    internal class LoadServer
    {
        public static LoadServer loadServer = null;
        private string targetURL;

        public LoadServer(string URL)
        {
            if(loadServer == null)
            {
                loadServer = this;
            }
            targetURL = URL;
        }

        public string CallWebClient()
        {
            string result = string.Empty;

            try
            {
                WebClient webClient = new WebClient();

                webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                using (Stream data = webClient.OpenRead(targetURL))
                {
                    using (StreamReader reader = new StreamReader(data))
                    {
                        result = reader.ReadToEnd();

                        reader.Close();
                        data.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "메일리", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return result;
        }

        public string ConnectDB()
        {
            string str = CallWebClient();
            JObject jObject;

            if (str.Contains("!DOCTYPE"))
            {
                return "점검 중";
            }
            else
            {
                jObject = JObject.Parse(str);
            }

            var a = jObject["mealServiceDietInfo"][1];
            var b = a["row"].SelectToken("DDISH_NM");
            return b.ToString().Replace("<br/>", Environment.NewLine);
        }
    }
}
