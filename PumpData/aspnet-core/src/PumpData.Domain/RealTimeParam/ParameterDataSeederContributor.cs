using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace PumpData.RealTimeParam
{
    public class ParameterDataSeederContributor 
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Parameter, BsonTimestamp> _parameterRepository;

        public ParameterDataSeederContributor(IRepository<Parameter, BsonTimestamp> parameterRepository)
        {
            _parameterRepository = parameterRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            string line;
            // 定义文件绝对路径
            string path = @"C:\\Users\\tpl\\Desktop\\主泵\\RCS-1\\RCS-1.csv";
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            sr.ReadLine();
            sr.ReadLine();
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                // 一行一行读取数据
                line = sr.ReadLine();
                string[] arr = line.Split(",");
                var parameterhas = await _parameterRepository.FindAsync(p => p.Id == arr[0].ConvertToTimeStamp());
                if (parameterhas == null)
                {
                    // 通过异步方法给对象赋值插入到数据库中
                    await _parameterRepository.InsertAsync(
                        new Parameter(arr[0].ConvertToTimeStamp())
                        {
                            P_vibration_X = Convert.ToDouble(arr[1]),
                            P_vibration_Y = Convert.ToDouble(arr[2]),
                            P_Motor_Displacement_X = Convert.ToDouble(arr[3]),
                            P_Motor_Displacement_Y = Convert.ToDouble(arr[4]),
                            P_Pump_Displacement_X = Convert.ToDouble(arr[5]),
                            P_Pump_Displacement_Y = Convert.ToDouble(arr[6]),
                            P_Motor_Speed = Convert.ToDouble(arr[7]),
                            P_Zero_Speed = Convert.ToDouble(arr[8]),
                            P_Pump_Outlet_P1 = Convert.ToDouble(arr[9]),
                            P_Pump_Outlet_P2 = Convert.ToDouble(arr[10]),
                            P_Filter_Pressure_1 = Convert.ToDouble(arr[11]),
                            P_Filter_Pressure_2 = Convert.ToDouble(arr[12]),
                            P_Fir_PreBeforeSeal = Convert.ToDouble(arr[13]),
                            P_Sec_PreBeforeSeal = Convert.ToDouble(arr[14]),
                            P_Thi_PreBeforeSeal = Convert.ToDouble(arr[15]),
                            P_Upper_BearTemperature = Convert.ToDouble(arr[16]),
                            P_Upper_BearBushTemperature = Convert.ToDouble(arr[17]),
                            P_Lower_Thrust_BearBushTemperature = Convert.ToDouble(arr[18]),
                            P_Upper_Thrust_BearBushTemperature = Convert.ToDouble(arr[19]),
                            P_Up_Motor_AirTemperature = Convert.ToDouble(arr[20]),
                            P_StatorTemperature_U = Convert.ToDouble(arr[21]),
                            P_StatorTemperature_V = Convert.ToDouble(arr[22]),
                            P_StatorTemperature_W = Convert.ToDouble(arr[23]),
                            P_Low_Motor_AirTemperature = Convert.ToDouble(arr[24]),
                            P_Lower_oilTemperature = Convert.ToDouble(arr[25]),
                            P_Lower_BearTemperature = Convert.ToDouble(arr[26]),
                            P_Cooler_InletTempeture = Convert.ToDouble(arr[27]),
                            P_Cooler_OutletTempeture = Convert.ToDouble(arr[28]),
                            P_Inject_WaterTempeture = Convert.ToDouble(arr[29]),
                            P_Control_LeakageTemperature = Convert.ToDouble(arr[30]),
                            P_Control_LeakageFlow = Convert.ToDouble(arr[31]),
                            P_LowPressure_LeakageFlow = Convert.ToDouble(arr[32]),
                            P_Inject_WaterFlow = Convert.ToDouble(arr[33]),
                            P_Cooler_SecFlow = Convert.ToDouble(arr[34]),
                            P_Upperbearing_OilLevel = Convert.ToDouble(arr[35]),
                            P_Lowerbearing_OilLevel = Convert.ToDouble(arr[36]),
                            P_Seal_PositionMonitor = Convert.ToDouble(arr[37]),
                            P_Flywheel_PositionMonitor = Convert.ToDouble(arr[38]),
                        },
                        autoSave: true
                    );
                }
            }
            // 关闭数据流
            sr.Close();
        }
    }
}
