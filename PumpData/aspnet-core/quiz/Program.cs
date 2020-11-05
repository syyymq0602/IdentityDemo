using System;
using System.IO;
using System.Text;

namespace quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            string path = @"C:\\Users\\tpl\\Desktop\\主泵\\pump\\csv\\FaultKnowledge.csv";
            using StreamReader sr = new StreamReader(path, Encoding.UTF8);
            /*
            var book = new book
            {
                nameof = ,
                price = 
            }
            bookService.Create(book);
            */
            sr.ReadLine();
            Fault e = new Fault();
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                string[] arr = line.Split(",");
                // Console.WriteLine(arr.Length);
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine(arr[i]);
                    e.F_id = Convert.ToDouble(arr[0]);
                    e.F_feature = arr[2];
                    e.F_type = arr[1];
                    e.DecisionSupport = arr[3];
                    Console.WriteLine("    "+e.F_id+"   "+e.F_type+"   "+e.F_feature+"   "+e.DecisionSupport);

                }

            }
            // Console.ReadLine();
            sr.Close();
        }
    }
}
