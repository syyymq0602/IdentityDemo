using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diagnostic
{
    public delegate void DataEventHandler(DataManager c, DataEventArgs e);
    public class DataManager
    {
        private DataEventHandler dataEventHandler;
        public event DataEventHandler DataUpDate
        {
            add { this.dataEventHandler += value; }
            remove { this.dataEventHandler -= value; }
        }
        public Generator DataGenerator
        {
            get; set;
        }
        public DataManager()
        {
            DataGenerator = new Generator();
        }
        //对于不同的数据源，只需要修改dataEventHandler.Invoke(this, DataGenerator.Generate())
        //DataGenerator.Generate()返回一个DataEventArgs类型数据，整个委托传递的都是这个数据，每次传递，就调用订阅的函数
        public async Task DistributeDataAsync()
        {
            //if (this.dataEventHandler == null)
            //{
            //    Console.WriteLine("Empty Event!");
            //}
            //else
            //{
            //    //DataEventArgs e = new DataEventArgs()
            //    //{
            //    //    Pressure1 = 0.2,
            //    //    Pressure2 = 2.1,
            //    //    Pressure3 = 3
            //    //};e.Mapping();
            //    //dataEventHandler.Invoke(this, DataGenerator.Generate());
            //    await DataGenerator.Generate();
            //}
            await DataGenerator.Generate();
        }
    }
    public class Generator
    {
        public Random random = new Random();
        private int count = 30;
        public HubConnection connection { get; set; }
        public Generator()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/Chat")
                .Build();

            connection.Closed += async exception =>
            {
                Console.WriteLine("Connection is closed.");
                await Task.Delay(new Random().Next(0, 5) * 1000);
                // await connection.StartAsync();
            };

            connection.On<DataEventArgs>("ReceiveMessage", (data) =>
            {
                Console.WriteLine(data.Pressure1);
            });

            connection.StartAsync();

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
        }
        public async Task Generate()
        {

            DataEventArgs e = new DataEventArgs()
            {
                Pressure1 = random.NextDouble() - 0.5,
                //Pressure2 = random.NextDouble()*2 - 1,
                //Pressure2=2,
                Pressure3 = random.NextDouble() * 0.5 - 0.5,
            };
            if ((count -= 1) > 0)
            {
                e.Pressure2 = 2;
            }
            else
                e.Pressure2 = 0; e.Mapping();
            //return e;
            await connection.SendAsync("SendMessage", e);

        }
    }
    public class DataEventArgs : EventArgs
    {
        public double Pressure1 { get; set; }
        public double Pressure2 { get; set; }
        public double Pressure3 { get; set; }
        public Dictionary<string, double> ParameterMap { get; set; }
        public void Mapping()
        {
            ParameterMap = new Dictionary<string, double> { { "Pressure1", Pressure1 }, { "Pressure2", Pressure2 }, { "Pressure3", Pressure3 } };
        }
    }
}
