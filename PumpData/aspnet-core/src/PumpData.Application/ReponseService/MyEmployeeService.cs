using Grpc.Core;
using GrpcServer.Web.Protos;
using Microsoft.Extensions.Logging;
using PumpData.DiagnosticMessage;
using PumpData.EquipmentInformations;
using PumpData.FaultKnowledge;
using PumpData.RealTimeParam;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PumpData.ReponseService
{
    public class MyEmployeeService : EmployeeService.EmployeeServiceBase
    {
        private readonly ILogger<MyEmployeeService> _logger;
        private readonly IDiagnoseAppService _diagnoseService;
        private readonly IEquipmentAppService _equipmentService;
        private readonly IFaultAppService _faultService;
        private readonly IParameterAppService _parameterService;
        public MyEmployeeService(ILogger<MyEmployeeService> logger,
            IDiagnoseAppService diagnoseService,
            IEquipmentAppService equipmentService,
            IFaultAppService faultService,
            IParameterAppService parameterService)
        {
            _logger = logger;
            _diagnoseService = diagnoseService;
            _equipmentService = equipmentService;
            _faultService = faultService;
            _parameterService = parameterService;
        }

        public override async Task<EmployeeResponse>
            GetByNo(GetByNoRequest request, ServerCallContext context)
        {
            var md = context.RequestHeaders;
            var parahas = await _parameterService.FindParaAsync(Convert.ToDateTime(md.GetValue("date")));
            if(parahas == null)
            {
                await _parameterService.CreateAsync(new CreateUpdateParameterDto {
                    P_date = Convert.ToDateTime(md.GetValue("date")),
                    P_vibration_X = Convert.ToDecimal(md.GetValue("vibration_X")),
                    P_vibration_Y = Convert.ToDecimal(md.GetValue("vibration_Y")),
                    P_Motor_Displacement_X = Convert.ToDecimal(md.GetValue("Motor_Displacement_X")),
                    P_Motor_Displacement_Y = Convert.ToDecimal(md.GetValue("Motor_Displacement_Y")),
                    P_Pump_Displacement_X = Convert.ToDecimal(md.GetValue("Pump_Displacement_X")),
                    P_Pump_Displacement_Y = Convert.ToDecimal(md.GetValue("Pump_Displacement_Y")),
                    P_Motor_Speed = Convert.ToDecimal(md.GetValue("Motor_Speed")),
                    P_Zero_Speed = Convert.ToDecimal(md.GetValue("Zero_Speed")),
                    P_Pump_Outlet_P1 = Convert.ToDecimal(md.GetValue("Pump_Outlet_P1")),
                    P_Pump_Outlet_P2 = Convert.ToDecimal(md.GetValue("Pump_Outlet_P2")),
                    P_Filter_Pressure_1 = Convert.ToDecimal(md.GetValue("Filter_Pressure_1")),
                    P_Filter_Pressure_2 = Convert.ToDecimal(md.GetValue("Filter_Pressure_2")),
                    P_Fir_PreBeforeSeal = Convert.ToDecimal(md.GetValue("Fir_PreBeforeSeal")),
                    P_Sec_PreBeforeSeal = Convert.ToDecimal(md.GetValue("Sec_PreBeforeSeal")),
                    P_Thi_PreBeforeSeal = Convert.ToDecimal(md.GetValue("Thi_PreBeforeSeal")),
                    P_Upper_BearTemperature = Convert.ToDecimal(md.GetValue("Upper_BearTemperature")),
                    P_Upper_BearBushTemperature = Convert.ToDecimal(md.GetValue("Upper_BearBushTemperature")),
                    P_Lower_Thrust_BearBushTemperature = Convert.ToDecimal(md.GetValue("Lower_Thrust_BearBushTemperature")),
                    P_Upper_Thrust_BearBushTemperature = Convert.ToDecimal(md.GetValue("Upper_Thrust_BearBushTemperature")),
                    P_Up_Motor_AirTemperature = Convert.ToDecimal(md.GetValue("Up_Motor_AirTemperature")),
                    P_StatorTemperature_U = Convert.ToDecimal(md.GetValue("StatorTemperature_U")),
                    P_StatorTemperature_V = Convert.ToDecimal(md.GetValue("StatorTemperature_V")),
                    P_StatorTemperature_W = Convert.ToDecimal(md.GetValue("StatorTemperature_W")),
                    P_Low_Motor_AirTemperature = Convert.ToDecimal(md.GetValue("Low_Motor_AirTemperature")),
                    P_Lower_oilTemperature = Convert.ToDecimal(md.GetValue("Lower_oilTemperature")),
                    P_Lower_BearTemperature = Convert.ToDecimal(md.GetValue("Lower_BearTemperature")),
                    P_Cooler_InletTempeture = Convert.ToDecimal(md.GetValue("Cooler_InletTempeture")),
                    P_Cooler_OutletTempeture = Convert.ToDecimal(md.GetValue("Cooler_OutletTempeture")),
                    P_Inject_WaterTempeture = Convert.ToDecimal(md.GetValue("Inject_WaterTempeture")),
                    P_Control_LeakageTemperature = Convert.ToDecimal(md.GetValue("Control_LeakageTemperature")),
                    P_Control_LeakageFlow = Convert.ToDecimal(md.GetValue("Control_LeakageFlow")),
                    P_LowPressure_LeakageFlow = Convert.ToDecimal(md.GetValue("LowPressure_LeakageFlow")),
                    P_Inject_WaterFlow = Convert.ToDecimal(md.GetValue("Inject_WaterFlow")),
                    P_Cooler_SecFlow = Convert.ToDecimal(md.GetValue("Cooler_SecFlow")),
                    P_Upperbearing_OilLevel = Convert.ToDecimal(md.GetValue("Upperbearing_OilLevel")),
                    P_Lowerbearing_OilLevel = Convert.ToDecimal(md.GetValue("Lowerbearing_OilLevel")),
                    P_Seal_PositionMonitor = Convert.ToDecimal(md.GetValue("Seal_PositionMonitor")),
                    P_Flywheel_PositionMonitor = Convert.ToDecimal(md.GetValue("P_Flywheel_PositionMonitor"))
                }); 
            }
            throw new Exception($"Employee not found with no : {request.No}");
        }
    }
}
