using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace PumpData.RealTimeParam
{
    public class Parameter :AggregateRoot<Guid>
    {
        public DateTime P_date { get; set; }
        public decimal P_vibration_X { get; set; }
        public decimal P_vibration_Y { get; set; }
        public decimal P_Motor_Displacement_X { get; set; }
        public decimal P_Motor_Displacement_Y { get; set; }
        public decimal P_Pump_Displacement_X { get; set; }
        public decimal P_Pump_Displacement_Y { get; set; }
        public decimal P_Motor_Speed { get; set; }
        public decimal P_Zero_Speed { get; set; }
        public decimal P_Pump_Outlet_P1 { get; set; }
        public decimal P_Pump_Outlet_P2 { get; set; }
        public decimal P_Filter_Pressure_1 { get; set; }
        public decimal P_Filter_Pressure_2 { get; set; }
        public decimal P_Fir_PreBeforeSeal { get; set; }
        public decimal P_Sec_PreBeforeSeal { get; set; }
        public decimal P_Thi_PreBeforeSeal { get; set; }
        public decimal P_Upper_BearTemperature { get; set; }
        public decimal P_Upper_BearBushTemperature { get; set; }
        public decimal P_Lower_Thrust_BearBushTemperature { get; set; }
        public decimal P_Upper_Thrust_BearBushTemperature { get; set; }
        public decimal P_Up_Motor_AirTemperature { get; set; }
        public decimal P_StatorTemperature_U { get; set; }
        public decimal P_StatorTemperature_V { get; set; }
        public decimal P_StatorTemperature_W { get; set; }
        public decimal P_Low_Motor_AirTemperature { get; set; }
        public decimal P_Lower_oilTemperature { get; set; }
        public decimal P_Lower_BearTemperature { get; set; }
        public decimal P_Cooler_InletTempeture { get; set; }
        public decimal P_Cooler_OutletTempeture { get; set; }
        public decimal P_Inject_WaterTempeture { get; set; }
        public decimal P_Control_LeakageTemperature { get; set; }
        public decimal P_Control_LeakageFlow { get; set; }
        public decimal P_LowPressure_LeakageFlow { get; set; }
        public decimal P_Inject_WaterFlow { get; set; }
        public decimal P_Cooler_SecFlow { get; set; }
        public decimal P_Upperbearing_OilLevel { get; set; }
        public decimal P_Lowerbearing_OilLevel { get; set; }
        public decimal P_Seal_PositionMonitor { get; set; }
        public decimal P_Flywheel_PositionMonitor { get; set; }
    }
}
