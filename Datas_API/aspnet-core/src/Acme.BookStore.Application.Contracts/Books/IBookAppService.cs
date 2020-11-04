using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Books
{
    public interface IBookAppService :
        ICrudAppService< //Defines CRUD methods
            DatasDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateDataDto> //Used to create/update a book
    {

    }
    /*
     *  public async Task UpLoadDatas()
        {
            string line;
            // 定义文件绝对路径
            string path = @"C:\\Users\\tpl\\Desktop\\主泵\\pump\\csv\\RealTimeParam.csv";
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                // 一行一行读取数据
                line = sr.ReadLine();
                string[] arr = line.Split(",");
                var parameterhas = await Repository.FindAsync(p => p.P_date == Convert.ToDateTime(arr[0]));
                if (parameterhas == null)
                {
                    // 通过异步方法给对象赋值插入到数据库中
                    await Repository.InsertAsync(
                           new Parameter
                           {
                               P_date = Convert.ToDateTime(arr[0]),
                               P_vibration_X = Convert.ToDecimal(arr[1]),
                               P_vibration_Y = Convert.ToDecimal(arr[2]),
                               P_Motor_Displacement_X = Convert.ToDecimal(arr[3]),
                               P_Motor_Displacement_Y = Convert.ToDecimal(arr[4]),
                               P_Pump_Displacement_X = Convert.ToDecimal(arr[5]),
                               P_Pump_Displacement_Y = Convert.ToDecimal(arr[6]),
                               P_Motor_Speed = Convert.ToDecimal(arr[7]),
                               P_Zero_Speed = Convert.ToDecimal(arr[8]),
                               P_Pump_Outlet_P1 = Convert.ToDecimal(arr[9]),
                               P_Pump_Outlet_P2 = Convert.ToDecimal(arr[10]),
                               P_Filter_Pressure_1 = Convert.ToDecimal(arr[11]),
                               P_Filter_Pressure_2 = Convert.ToDecimal(arr[12]),
                               P_Fir_PreBeforeSeal = Convert.ToDecimal(arr[13]),
                               P_Sec_PreBeforeSeal = Convert.ToDecimal(arr[14]),
                               P_Thi_PreBeforeSeal = Convert.ToDecimal(arr[15]),
                               P_Upper_BearTemperature = Convert.ToDecimal(arr[16]),
                               P_Upper_BearBushTemperature = Convert.ToDecimal(arr[17]),
                               P_Lower_Thrust_BearBushTemperature = Convert.ToDecimal(arr[18]),
                               P_Upper_Thrust_BearBushTemperature = Convert.ToDecimal(arr[19]),
                               P_Up_Motor_AirTemperature = Convert.ToDecimal(arr[20]),
                               P_StatorTemperature_U = Convert.ToDecimal(arr[21]),
                               P_StatorTemperature_V = Convert.ToDecimal(arr[22]),
                               P_StatorTemperature_W = Convert.ToDecimal(arr[23]),
                               P_Low_Motor_AirTemperature = Convert.ToDecimal(arr[24]),
                               P_Lower_oilTemperature = Convert.ToDecimal(arr[25]),
                               P_Lower_BearTemperature = Convert.ToDecimal(arr[26]),
                               P_Cooler_InletTempeture = Convert.ToDecimal(arr[27]),
                               P_Cooler_OutletTempeture = Convert.ToDecimal(arr[28]),
                               P_Inject_WaterTempeture = Convert.ToDecimal(arr[29]),
                               P_Control_LeakageTemperature = Convert.ToDecimal(arr[30]),
                               P_Control_LeakageFlow = Convert.ToDecimal(arr[31]),
                               P_LowPressure_LeakageFlow = Convert.ToDecimal(arr[32]),
                               P_Inject_WaterFlow = Convert.ToDecimal(arr[33]),
                               P_Cooler_SecFlow = Convert.ToDecimal(arr[34]),
                               P_Upperbearing_OilLevel = Convert.ToDecimal(arr[35]),
                               P_Lowerbearing_OilLevel = Convert.ToDecimal(arr[36]),
                               P_Seal_PositionMonitor = Convert.ToDecimal(arr[37]),
                               P_Flywheel_PositionMonitor = Convert.ToDecimal(arr[38]),
                           },
                           autoSave: true
                    );
                }
            }
            // 关闭数据流
            sr.Close();
        }
     */
}
