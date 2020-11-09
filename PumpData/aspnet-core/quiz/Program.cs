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
        }
    }
}
