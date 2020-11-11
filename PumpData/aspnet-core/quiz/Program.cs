using System;
using System.IO;
using System.Text;

namespace quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var s = Convert.ToInt64(ts.TotalSeconds - 28800).ToString();
            Console.WriteLine(s);
            DateTime dt = DateTime.ParseExact("20200526092015", "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture);
            Console.WriteLine(dt);
            string path = @"C:\\Users\\tpl\\Desktop\\主泵\\RCS-1\\RCS-1.csv";
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            sr.ReadLine();
            sr.ReadLine();
            sr.ReadLine();
            //while (!sr.EndOfStream)
            {
                // 一行一行读取数据
                string line = sr.ReadLine();
                string[] arr = line.Split(",");
                string time = arr[0];
                time = time.Replace(" ", "").Replace("/", "").Replace(":","");
                Console.WriteLine(Order(time));
            }
        }
        internal static string Order(string s)
        {
            char[] cc = s.ToCharArray();
            for(int i=0;i<4;i++)
            {
                Exchange(ref cc[i],ref cc[i+4]);
            }
            string ss = new string(cc);
            return ss;
        }
        internal static void Exchange(ref char a ,ref char b)
        {
            char c = b;
            b = a;
            a = c;
        }
    }
}
