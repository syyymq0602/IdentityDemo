using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diagnostic
{
    public class Monitor
    {
        //public DataManager manager = new DataManager();
        //public TimeSeries t1 = new TimeSeries("Pressure1",20,1000,50,0.5,-0.5);
        public TimeSeries t2 = new TimeSeries("Pressure2", 20, 1000, 25, 1, -1);
        public HubConnection connection { get; set; }
        public Monitor()
        {
            //manager.DataUpDate += t1.Monitoring;
            //manager.DataUpDate += t2.Monitoring;
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
                t2.Monitoring(data.Pressure2);
                //Console.WriteLine(data.Pressure2);
            });
            connection.StartAsync();
        }
        public async System.Threading.Tasks.Task MonitingAsync()
        {
            //await manager.DistributeDataAsync();

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
