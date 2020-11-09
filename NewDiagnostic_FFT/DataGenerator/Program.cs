using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using Diagnostic.Algrithm.FFT;
using Microsoft.AspNetCore.SignalR.Client;

namespace DataGenerator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Generator generator1 = new Generator();
            //while (true)
            //{
            //    Thread.Sleep(50);
            //    await generator1.Generate();
            //}
            HubConnection connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/Chat")
                .Build();

            connection.Closed += async exception =>
            {
                Console.WriteLine("Connection is closed.");
                await Task.Delay(new Random().Next(0, 5) * 1000);
                // await connection.StartAsync();
            };
            await connection.StartAsync();
            HttpClient client = new HttpClient();
            var data=await client
                .GetAsync("https://localhost:44388/api/app/book?SkipCount=0&MaxResultCount=512");
            var str= await data.Content.ReadAsStringAsync();
            //JObject jo = (JObject)JsonConvert.DeserializeObject(str);
            //var array = jo.Value<JToken>("items");
            //foreach(var e in jo.Value<JToken>("datas"))
            Point m = JsonConvert.DeserializeObject<Point>(str);
            var points= m.items.Select(x => x.datas).ToArray();
            FFT analy = new FFT();
            var sepctrum = analy.PowerSpectrum(ref points, 512);
            await connection.SendAsync("SendMessage", points);
            // await connection.SendAsync("SendMessageBy");
            Console.WriteLine();
        }
        public class Point
        {
            public int totalCount { get; set; }
            public List<PointInfo> items { get; set; }
        }
        public class PointInfo
        {
            public double datas { get; set; }
            public Guid id { get; set; }
        }
    }
}
