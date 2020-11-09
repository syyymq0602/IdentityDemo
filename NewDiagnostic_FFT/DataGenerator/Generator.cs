using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator
{
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

            connection.On<OperatingData>("ReceiveMessage", (data) =>
            {
                Console.WriteLine("recived!");
            });

            connection.StartAsync();
        }
        public async Task Generate()
        {
            OperatingData e = new OperatingData()
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
                e.Pressure2 = 0; 
            e.Mapping();
            //return e;
            await connection.SendAsync("SendMessage", e);
        }
    }
    public class OperatingData
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
