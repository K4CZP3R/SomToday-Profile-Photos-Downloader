using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SomToday_Profile_Photos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your cookie");
            string cookie = Console.ReadLine();
            cookie = "enteryourcookiehere";

            Console.WriteLine("Enter your school 'afkorting' [servers.somtoday.nl]");
            string afkorting = Console.ReadLine();
            string url = "https://" + afkorting + "-elo.somtoday.nl/pasfoto/pasfoto_leerling.jpg?id=";
            Console.WriteLine("Enter start id");
            string startid = Console.ReadLine();
            int startint = int.Parse(startid);
            Console.WriteLine("Enter end id");
            string endid = Console.ReadLine();
            int endint = int.Parse(endid);

            WebClient wc = new WebClient();
            wc.Headers.Add(HttpRequestHeader.Cookie, cookie);
            int leftpp = 0;
            for (int x = startint; x <= endint; x++)
            {
                leftpp = endint - x;
                wc.DownloadFile(new Uri(url + x.ToString()), @"pp/pp_" + x.ToString() + ".jpg");
                Console.WriteLine(String.Format("[{0}] - Downloading {1} of {2} (Left:{3})", afkorting, x.ToString(), endint.ToString(),leftpp.ToString()));
            }
            Console.WriteLine("Done, press any key to exit");
            Console.ReadKey();
            
            
        }
    }
}
