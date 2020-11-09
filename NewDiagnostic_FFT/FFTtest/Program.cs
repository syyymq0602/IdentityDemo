using System;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using Diagnostic.Algrithm.FFT;
using Diagnostic;
using System.Threading;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;

namespace FFTtest
{
    class Program
    {
        static double[] data = new double[8192];
        static async Task Main(string[] args)
        {
            //var connection = new HubConnectionBuilder()
            //    .WithUrl("https://localhost:5001/Chat")
            //    .Build();

            //connection.Closed += async exception =>
            //{
            //    Console.WriteLine("Connection is closed.");
            //    await Task.Delay(new Random().Next(0, 5) * 1000);
            //    // await connection.StartAsync();
            //};

            //await connection.StartAsync();

            //connection.On<DataEventArgs>("ReceiveMessage", (data) =>
            //{
            //    Console.WriteLine(data.Pressure1);
            //});

            //while (true)
            //{
            //    var key = Console.ReadKey();
            //    if (key.Key == ConsoleKey.S)
            //    {
            //        await connection.SendAsync("SendMessage", "send method", "hello from send");
            //    }
            //    else if (key.Key == ConsoleKey.I)
            //    {
            //        await connection.InvokeAsync("SendMessage", "invoke method", "hello from invoke");
            //    }
            //    else
            //    {
            //        await connection.StopAsync();
            //    }
            //}

            //ReadFromExcelFile(@"D:\FFT_64.xlsx");
            //FFT analy = new FFT();
            //var result = analy.Execute(ref data);
            //var sepctrum = analy.PowerSpectrum(ref data, 1024);
            //Console.WriteLine("Hello");
            Diagnostic.Monitor monitor = new Diagnostic.Monitor();
            while (true)
            {
                //Thread.Sleep(50);
                //await monitor.MonitingAsync();
            }
        }
        static void ReadFromExcelFile(string filePath)
        {
            IWorkbook wk = null;
            string extension = System.IO.Path.GetExtension(filePath);
            try
            {
                FileStream fs = File.OpenRead(filePath);
                if (extension.Equals(".xls"))
                {
                    //把xls文件中的数据写入wk中
                    wk = new HSSFWorkbook(fs);
                }
                else
                {
                    //把xlsx文件中的数据写入wk中
                    wk = new XSSFWorkbook(fs);
                }

                fs.Close();
                //读取当前表数据
                ISheet sheet = wk.GetSheetAt(0);

                IRow row = sheet.GetRow(0);  //读取当前行数据
                                             //LastRowNum 是当前表的总行数-1（注意）
                //int offset = 0;
                //for (int i = 0; i <= sheet.LastRowNum; i++)
                //{
                row = sheet.GetRow(0);  //读取当前行数据
                if (row != null)
                {
                    //LastCellNum 是当前行的总列数
                    for (int j = 0; j < row.LastCellNum; j++)
                    {
                        //读取该行的第j列数据
                        string value = row.GetCell(j).ToString();
                        data[j] = Convert.ToDouble(value);
                    }
                }
                //}
            }

            catch (Exception e)
            {
                //只在Debug模式下才输出
                Console.WriteLine(e.Message);
            }
        }
    }
}
