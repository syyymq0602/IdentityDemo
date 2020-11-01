using Grpc.Core;
using GrpcServer.Web.Protos;
using Microsoft.Extensions.Logging;
using PumpData.RealTimeParam;
using System;
using System.Threading.Tasks;

namespace PumpData.ReponseService
{
    public class DataTransService : MyDataTransService.MyDataTransServiceBase
    {
        private readonly ILogger<DataTransService> _logger;
        private readonly IParameterAppService _parameterService;
        public DataTransService(ILogger<DataTransService> logger,
            IParameterAppService parameterService)
        {
            _logger = logger;
            _parameterService = parameterService;
        }

        public override async Task<DataTransResponse>
            GetByNo(GetDataRequest request, ServerCallContext context)
        {
            var md = context.RequestHeaders;
            var parahas = await _parameterService.FindParaAsync(Convert.ToDateTime(md.GetValue("date")).ToUniversalTime());
            if(parahas == null)
            {
                await _parameterService.CreateAsync(new CreateUpdateParameterDto
                {
                    P_date = Convert.ToDateTime(md.GetValue("date")),
                    P_vibration_X = Convert.ToDouble(md.GetValue("vibration_x")),
                    P_vibration_Y = Convert.ToDouble(md.GetValue("vibration_y")),
                    P_Motor_Displacement_X = Convert.ToDouble(md.GetValue("motor_displacement_x")),
                    P_Motor_Displacement_Y = Convert.ToDouble(md.GetValue("motor_displacement_y")),
                    P_Pump_Displacement_X = Convert.ToDouble(md.GetValue("pump_displacement_x")),
                    P_Pump_Displacement_Y = Convert.ToDouble(md.GetValue("pump_displacement_y")),
                    P_Motor_Speed = Convert.ToDouble(md.GetValue("motor_speed")),
                    P_Zero_Speed = Convert.ToDouble(md.GetValue("zero_speed")),
                    P_Pump_Outlet_P1 = Convert.ToDouble(md.GetValue("pump_outlet_p1")),
                    P_Pump_Outlet_P2 = Convert.ToDouble(md.GetValue("pump_outlet_p2")),
                    P_Filter_Pressure_1 = Convert.ToDouble(md.GetValue("filter_pressure_1")),
                    P_Filter_Pressure_2 = Convert.ToDouble(md.GetValue("filter_pressure_2")),
                    P_Fir_PreBeforeSeal = Convert.ToDouble(md.GetValue("fir_prebeforeseal")),
                    P_Sec_PreBeforeSeal = Convert.ToDouble(md.GetValue("sec_prebeforeseal")),
                    P_Thi_PreBeforeSeal = Convert.ToDouble(md.GetValue("thi_prebeforeseal")),
                    P_Upper_BearTemperature = Convert.ToDouble(md.GetValue("upper_beartemperature")),
                    P_Upper_BearBushTemperature = Convert.ToDouble(md.GetValue("upper_bearbushtemperature")),
                    P_Lower_Thrust_BearBushTemperature = Convert.ToDouble(md.GetValue("lower_thrust_bearbushtemperature")),
                    P_Upper_Thrust_BearBushTemperature = Convert.ToDouble(md.GetValue("upper_thrust_bearbushtemperature")),
                    P_Up_Motor_AirTemperature = Convert.ToDouble(md.GetValue("up_motor_sirtemperature")),
                    P_StatorTemperature_U = Convert.ToDouble(md.GetValue("statortemperature_u")),
                    P_StatorTemperature_V = Convert.ToDouble(md.GetValue("statortemperature_v")),
                    P_StatorTemperature_W = Convert.ToDouble(md.GetValue("statortemperature_w")),
                    P_Low_Motor_AirTemperature = Convert.ToDouble(md.GetValue("low_motor_airtemperature")),
                    P_Lower_oilTemperature = Convert.ToDouble(md.GetValue("lower_oiltemperature")),
                    P_Lower_BearTemperature = Convert.ToDouble(md.GetValue("lower_beartemperature")),
                    P_Cooler_InletTempeture = Convert.ToDouble(md.GetValue("cooler_inlettempeture")),
                    P_Cooler_OutletTempeture = Convert.ToDouble(md.GetValue("cooler_outlettempeture")),
                    P_Inject_WaterTempeture = Convert.ToDouble(md.GetValue("inject_watertempeture")),
                    P_Control_LeakageTemperature = Convert.ToDouble(md.GetValue("control_leakagetemperature")),
                    P_Control_LeakageFlow = Convert.ToDouble(md.GetValue("control_leakageflow")),
                    P_LowPressure_LeakageFlow = Convert.ToDouble(md.GetValue("lowpressure_leakageflow")),
                    P_Inject_WaterFlow = Convert.ToDouble(md.GetValue("inject_waterflow")),
                    P_Cooler_SecFlow = Convert.ToDouble(md.GetValue("cooler_secflow")),
                    P_Upperbearing_OilLevel = Convert.ToDouble(md.GetValue("upperbearing_oillevel")),
                    P_Lowerbearing_OilLevel = Convert.ToDouble(md.GetValue("lowerbearing_oillevel")),
                    P_Seal_PositionMonitor = Convert.ToDouble(md.GetValue("seal_positionmonitor")),
                    P_Flywheel_PositionMonitor = Convert.ToDouble(md.GetValue("p_flywheel_positionmonitor"))
                });
                var response = new DataTransResponse
                {
                      Info = "The data is transferring into the MongoDB database.......",
                };
                return await Task.FromResult(response);
            }
            var res = new DataTransResponse
            {
                Info = "The data has existed.",
            };
            return await Task.FromResult(res);
        }
    }
}
