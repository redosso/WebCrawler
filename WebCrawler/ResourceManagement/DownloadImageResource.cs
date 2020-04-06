using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace WebCrawler.ResourceManagement
{
    public class DownloadImageResource
    {
        public static async void DownloadImage(string resourceUri)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(resourceUri);
                response.EnsureSuccessStatusCode();

                using (FileStream fileStream = new FileStream(resourceUri.Substring(resourceUri.LastIndexOf('/') + 1), FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    await response.Content.CopyToAsync(fileStream);
                }
            }
            catch (HttpRequestException rex)
            {
                Console.WriteLine(rex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
