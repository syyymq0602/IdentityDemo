using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            string path = @"C:\\Users\\tpl\\Desktop\\FFT_64.xlsx";
            using StreamReader sr = new StreamReader(path, Encoding.UTF8);
            /*
            var book = new book
            {
                nameof = ,
                price = 
            }
            bookService.Create(book);
            */
            Book T = new Book();
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                string[] arr=line.Split(" ");
                // Console.WriteLine(arr.Length);
                for (int i=0;i<arr.Length;i++)
                {
                    T.data = Convert.ToDecimal(arr[i]);
                    Console.WriteLine(arr[i]);

                }
            }
            Console.WriteLine(T.data);
            // Console.ReadLine();
            sr.Close();
        }
    }
}
