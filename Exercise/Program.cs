using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using HtmlAgilityPack;

namespace Exercise
{
    public enum CarType
    {
        Toyota = 1,
        Honda = 2,
        Ford = 3,
    }

    public class Program
    {

        public static void GetFilesFromDirectory(string dir)
        {
            if (!dir.EndsWith(@"\"))
                dir = dir + @"\";
            try
            {
                string[] files = Directory.GetFiles(dir, "*.png");

            for (int i = 0; i < files.Length; i++)
            {
                int lastSlash = files[i].LastIndexOf(@"\");
                files[i] = files[i].Substring(lastSlash + 1, files[i].Length - lastSlash - 1);
                files[i] = files[i].Replace(".png", "");
            }

            List <string> fileToWrite = new List<string>();
            fileToWrite.AddRange(files);

            fileToWrite.Sort();

            File.WriteAllLines(@"C:\Users\gastanica\Desktop\querydir.txt", fileToWrite);

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Folder doesn't exists {0} and the exception is {1}", dir, ex));
            }

        }

        public void EnumExercise()
        {
            CarType myCarType = CarType.Toyota;
            Console.WriteLine(myCarType + " " + myCarType.ToString());
            Console.ReadLine();
        }

        public void DictionaryExercise()
        {
            Dictionary<string, string> help = new Dictionary<string, string>();
            help.Add("Hel", "Hele");
            if (help.ContainsValue("Hele"))
                Console.WriteLine(help["Hel"]);
            Console.ReadKey();
        }

        public void StringExercise()
        {
            string fullString = "full string";
            string partOfString = fullString.Substring(1);
            string partOfString2 = fullString.Substring(5);
            string shorterPart = fullString.Substring(5, 3);
            Console.WriteLine(partOfString);
            Console.WriteLine(partOfString2);
            Console.WriteLine(shorterPart);
            Console.ReadLine();
        }

        public void StringFormatExercise()
        {
            int x = 1, y = 2;
            int sum = x + y;
            string sumCalculation = String.Format("{0} + {1} = {2}", x, y, sum);
            Console.WriteLine(sumCalculation);
            Console.ReadLine();
        }

        public void IndexExercise()
        {
            string fruit = "apple,orange,banana";
            Console.WriteLine("Found orange in position: " + fruit.IndexOf("orange")); //exists
            Console.WriteLine("Found lemon in position: " + fruit.IndexOf("lemon")); //doesn't exist
            Console.ReadLine();
        }

        public void BreakContinueExercise()
        {
            for (int i = 0; i < 16; i++)
            {

                if (i % 2 == 1)
                {
                    continue;
                }

                Console.WriteLine(i);

            }

            for (int i = 0; i < 16; i++)
            {

                if (i == 12)
                {
                    break;
                }
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }

        public static string ExtractFromLink(string url)
        {
            string data = url;
            string urlAddress = url;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
            }
            return data;
        }

        public static void DeviceInfo()
        {
            string sURL;
			sURL = "http://www.microsoft.com";

			WebRequest wrGETURL;
			wrGETURL = WebRequest.Create(sURL);
			
			WebProxy myProxy = new WebProxy("myproxy",80);
			myProxy.BypassProxyOnLocal = true;

	        wrGETURL.Proxy = WebProxy.GetDefaultProxy();

			Stream objStream;
			objStream = wrGETURL.GetResponse().GetResponseStream();

			StreamReader objReader = new StreamReader(objStream);

			string sLine = "";
			int i = 0;

			while (sLine!=null)
			{
				i++;
				sLine = objReader.ReadLine();
				if (sLine!=null)
					Console.WriteLine("{0}:{1}",i,sLine);
			}
			Console.ReadLine();
		}

        public static void HtmlAgility()
        {
            var xml = new HtmlDocument();
            xml.LoadHtml("http://stackoverflow.com/questions/846994/how-to-use-html-agility-pack");
            Console.WriteLine(xml.ToString());
        }

        public static void Main()
        {
            //string dir = @"C:\Users\gastanica\Perforce\EAMOBILE\gastanica_RO-3050829_8127\EAOS\QECS\TOOLS\GatorScripts\FifaWorld\Query\1080x1920";
            //GetFilesFromDirectory(dir);
            //var data = ExtractFromLink("http://www.gsmarena.com/apple_iphone_6-6378.php");
            //File.WriteAllText(@"D:\scripts\coding staff\Exercise\a.txt", data);
            //Console.WriteLine(data);
            HtmlAgility();
            Console.Read();
        }
    }
}
