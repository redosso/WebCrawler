using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using WebCrawler.Models;

namespace WebCrawler.WebPagesScanning
{
    public class ScanForImages
    {
        public static async Task ScanForImagesAsync(string url)
        {
            var httpClient = new HttpClient();
            var htmlCode = await httpClient.GetStringAsync(url);
            var htmlDoc = new HtmlDocument();
            
            htmlDoc.LoadHtml(htmlCode);
            //List<HtmlNode> list = new List<HtmlNode>(0);

            foreach(HtmlNode node in htmlDoc.DocumentNode              
              .SelectNodes("//img/@src"))
            {
                var myImage = new TaskObjectModel
                {
                    ImgUrl = node.GetAttributeValue("src", "")
                };

                ResourceManagement.DownloadImageResource.DownloadImage(url + myImage.ImgUrl.Substring(2));
            }
        }
    }
}
