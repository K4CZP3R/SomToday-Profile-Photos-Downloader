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
            string cookie = "enteryourcookiehere"; //cookie from somtoday site
            string afkorting = "enterafkortinghere"; //afkorting from servers.somtoday.nl

            string url = "https://" + afkorting + "-elo.somtoday.nl/pasfoto/pasfoto_leerling.jpg?id=";
            string startid = ""; //?id=x x=starting id
            int startint = int.Parse(startid);
            string endid = ""; //?id=x x=ending id
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
