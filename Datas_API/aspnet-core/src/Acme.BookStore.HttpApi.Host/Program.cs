using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Acme.BookStore.Books;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace Acme.BookStore
{
    public class Program 
    {
        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
#if DEBUG
                .MinimumLevel.Debug()
#else
                .MinimumLevel.Information()
#endif
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                //.WriteTo.Async(c => c.File("Logs/logs.txt"))
                .WriteTo.Async(c => c.Console())
                .CreateLogger();

            try
            {
                Log.Information("Starting Acme.BookStore.HttpApi.Host.");
                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly!");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }
        /*
        public async void AutoDataUpload(BookAppService Repository)
        {
            // 定义文件绝对路径
            string path = @"C:\\Users\\tpl\\Desktop\\主泵\\q.txt";
            StreamReader sr = new StreamReader(path, Encoding.UTF8); 
            while (!sr.EndOfStream)
            {
                // 一行一行读取数据
                string line = sr.ReadLine();
                string[] arr = line.Split(" ");
                // BookAppService bookservice = new BookAppService();
                // 通过异步方法给对象赋值插入到数据库中
                await Repository.CreateAsync(
                       new CreateUpdateBookDto
                       {
                           Name = arr[0],
                           Type = (BookType)Convert.ToInt32(arr[1]),
                           PublishDate = Convert.ToDateTime(arr[2]),
                           Price = Convert.ToSingle(arr[3])
                       }
                       // autoSave: true
                ) ;
            }
            // 关闭数据流
            sr.Close();
        }
        */

        internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseAutofac()
                .UseSerilog();
    }
}
