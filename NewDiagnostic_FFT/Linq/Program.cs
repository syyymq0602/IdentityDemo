using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HubConnection connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/Chat")
                .Build();

            connection.On<DateTime>("ReceiveTime", data =>
            {
                Console.WriteLine("recived!");
            });
            
            connection.Closed += async exception =>
            {
                Console.WriteLine("Connection is closed.");
                await Task.Delay(new Random().Next(0, 5) * 1000);
                // await connection.StartAsync();
            };
            await connection.StartAsync();
            HttpClient client = new HttpClient();
            var data = await client
                .GetAsync("https://localhost:44345/api/app/parameter?MaxResultCount=10");
            var str = await data.Content.ReadAsStringAsync();
            //var sqr = str.ToDictionary();
            Point m = JsonConvert.DeserializeObject<Point>(str);
            foreach(PointInfo p in m.items){
                await connection.SendAsync("SendMessageTime", 1.2);
                DelayMillionSeconds(500);
                Console.WriteLine(p.Time.TimeOfDay);
            }
        }
        public class Point
        {
            public int totalCount { get; set; }
            public List<PointInfo> items { get; set; }
        }
        public class PointInfo
        {
            public DateTime Time { get; set; }
            public double P_vibration_X { get; set; }
            public double P_vibration_Y { get; set; }
            public double P_Motor_Displacement_X { get; set; }
            public double P_Motor_Displacement_Y { get; set; }
            public double P_Pump_Displacement_X { get; set; }
            public double P_Pump_Displacement_Y { get; set; }
            public double P_Motor_Speed { get; set; }
            public double P_Zero_Speed { get; set; }
            public double P_Pump_Outlet_P1 { get; set; }
            public double P_Pump_Outlet_P2 { get; set; }
            public double P_Filter_Pressure_1 { get; set; }
            public double P_Filter_Pressure_2 { get; set; }
            public double P_Fir_PreBeforeSeal { get; set; }
            public double P_Sec_PreBeforeSeal { get; set; }
            public double P_Thi_PreBeforeSeal { get; set; }
            public double P_Upper_BearTemperature { get; set; }
            public double P_Upper_BearBushTemperature { get; set; }
            public double P_Lower_Thrust_BearBushTemperature { get; set; }
            public double P_Upper_Thrust_BearBushTemperature { get; set; }
            public double P_Up_Motor_AirTemperature { get; set; }
            public double P_StatorTemperature_U { get; set; }
            public double P_StatorTemperature_V { get; set; }
            public double P_StatorTemperature_W { get; set; }
            public double P_Low_Motor_AirTemperature { get; set; }
            public double P_Lower_oilTemperature { get; set; }
            public double P_Lower_BearTemperature { get; set; }
            public double P_Cooler_InletTempeture { get; set; }
            public double P_Cooler_OutletTempeture { get; set; }
            public double P_Inject_WaterTempeture { get; set; }
            public double P_Control_LeakageTemperature { get; set; }
            public double P_Control_LeakageFlow { get; set; }
            public double P_LowPressure_LeakageFlow { get; set; }
            public double P_Inject_WaterFlow { get; set; }
            public double P_Cooler_SecFlow { get; set; }
            public double P_Upperbearing_OilLevel { get; set; }
            public double P_Lowerbearing_OilLevel { get; set; }
            public double P_Seal_PositionMonitor { get; set; }
            public double P_Flywheel_PositionMonitor { get; set; }
        }
        public static bool DelayMillionSeconds(int millionseconds)
        {
            var start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount) - start < millionseconds) ;
            return true;
        }
    }
}
