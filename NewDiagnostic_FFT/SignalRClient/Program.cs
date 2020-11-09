using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace SignalRClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Random random = new Random();

            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/Chat")
                .WithAutomaticReconnect()
                .Build();

            connection.On<string, string>("ReceiveMessageBy",(user, message) =>
            {
                Console.WriteLine("recived!");
            });

            connection.Closed += async error => {
                // Do your close logic.
                Console.WriteLine("Connection is closed.");
                await Task.Delay(new Random().Next(0, 5) * 1000);
            };

            await connection.StartAsync();

            await connection.SendAsync("SendMessageBy", "Kity", "bear");

            Data data = new Data();

            for(int i=0;i<200;i++)
            {
                if (DelayMillionSeconds(500))
                {
                    data.num = random.NextDouble();
                    data.size = random.NextDouble()*10;
                    var user = "Kell";
                    var message = "I'm Here.";
                    await connection.SendAsync("SendMessage", data);
                    // await connection.SendAsync("SendMessageBy", user, message);
                }
            }
        }
        // 毫秒级延时程序
        public static bool DelayMillionSeconds(int millionseconds)
        {
            var start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount) - start < millionseconds) ;
            return true;
        }
        // 秒级延时程序
        public static bool DelaySeconds(int second)
        {
            DateTime now = DateTime.Now;
            int s;
            do
            {
                TimeSpan spand = DateTime.Now - now;
                // 可以毫秒可以秒
                // int s = spand.Milliseconds;
                s = spand.Seconds;
            }
            while (s < second);
            return true;
        }

    }
}
