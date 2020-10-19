using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Windows;

namespace Maeily_Windows
{
    internal class LoadMeal
    {
        public static LoadMeal loadMeal;
        private string targetURL = string.Empty;

        public LoadMeal(string targetURL)
        {
            loadMeal = this;
            this.targetURL = targetURL;
        }

        public string callWebClient()
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

        public string getMeal(int time)
        {
            string str = callWebClient();
            JObject jObject = JObject.Parse(str);

            var a = jObject["mealServiceDietInfo"][1];
            var b = a["row"][time].SelectToken("DDISH_NM");
            return b.ToString().Replace("<br/>", Environment.NewLine);
        }
    }
}