using Microsoft.AspNetCore.SignalR.Client;
using PumpData.PumpApp;
using PumpData.RealTimeParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace PumpData
{
    public class PumpDataClient : ITransientDependency
    {
        private readonly IParameterAppService _appService;
        public PumpDataClient(IParameterAppService appService)
        {
            _appService = appService;

            var connection = new HubConnectionBuilder()
                    .WithUrl("https://localhost:5001/Chat")
                    .Build();

            connection.On<double>("ReceiveTime", async(data) =>
            {
                //Console.WriteLine(data.Pressure1);
                var s = await _appService.CreateAsync(new CreateUpdateParameterDto
                {
                    P_vibration_X = data
                });
                Console.WriteLine("SAS");
            });

            connection.StartAsync();
        }
    }
}
