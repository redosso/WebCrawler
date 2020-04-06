using System;

namespace WebCrawler
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            await WebPagesScanning.ScanForImages.ScanForImagesAsync("https://docs.docker.com/compose/reference/up/");
        }
    }
}
