using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace PumpData.RealTimeParam
{
    public class Parameter : AggregateRoot<string>
    {
        public override string Id { get; protected set; }
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

        public Parameter(string id)
        {
            Id = id;
        }
    }
}
