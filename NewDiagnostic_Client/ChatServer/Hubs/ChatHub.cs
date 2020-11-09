using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ChatServer.Hubs
{
    public class ChatHub : Hub
    {
        //public async Task SendMessage(DataEventArgs e)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", e);
        //}
        public async Task SendMessage(Data datas)
        {
            await Clients.All.SendAsync("ReceiveMessage", datas);
            Console.WriteLine(datas.num+"  "+datas.size);
        }
        public async Task SendMessageBy(string user,string message)
        {
            await Clients.All.SendAsync("ReceiveMessageBy", user,message);
            Console.WriteLine(user + "    " + message);
        }
        public async Task SendMessageTime(DateTime time)
        {
            await Clients.All.SendAsync("ReceiveTime", time);
            Console.WriteLine(time);
        }
        public class Data
        {
            public double num { get; set; }
            public double size { get; set; }
        }
    }
}