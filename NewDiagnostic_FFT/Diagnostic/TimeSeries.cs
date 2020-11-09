using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;

namespace Diagnostic
{
    public class TimeSeries
    {
        //采样周期，单位ms
        public int SamplePeriod
        {
            get;
            set;
        }
        //对于参数的描述信息
        public string Description
        {
            get;
            set;
        }
        //数据缓存区
        public List<double> Data
        {
            get;
            set;
        }
        //数据缓存区容量
        public int Capacity
        {
            get;
            set;
        }
        //要显示到前端UI的当前值，暂定1s更新一次
        public double CurrentValue
        {
            get;
            set;
        }
        //低阈值
        public double LowThreshold
        {
            get;
            set;
        }
        //高阈值
        public double HighThreshold
        {
            get;
            set;
        }
        //低低阈值
        public double VeryLowThreshold
        {
            get;
            set;
        }
        //高高阈值
        public double VeryHighThreshold
        {
            get;
            set;
        }
        //第一级黄报
        public bool FirstLevelAlarm
        {
            get;
            set;
        }
        //第二级红报
        public bool SecondLevelAlarm
        {
            get;
            set;
        }
        public bool IsAbnormal
        {
            get; set;
        }
        //当前值更新时间，单位ms
        public int UpdateTime
        {
            get;
            set;
        }
        private int interval = 0;
        public TimeSeries(string description, int n, int updatetime, int sampleperiod, double high, double low)
        {
            Capacity = n;
            UpdateTime = updatetime;
            SamplePeriod = sampleperiod;
            Description = description;
            HighThreshold = high;
            LowThreshold = low;
            Data = new List<double>();
            for (int i = 0; i < n; i++)
            {
                Data.Add(0);
            }
            interval = Convert.ToInt32(UpdateTime / SamplePeriod);
        }
        public TimeSeries(int n)
        {
            Capacity = n;
            UpdateTime = 1000;
            SamplePeriod = 50;
            Description = "Pressure1";
            HighThreshold = 0.5;
            LowThreshold = -0.5;
            Data = new List<double>();
            for (int i = 0; i < n; i++)
            {
                Data.Add(0);
            }
            interval = Convert.ToInt32(UpdateTime / SamplePeriod);
        }
        private void Push(double data)
        {
            Data.Add(data);
            Data.RemoveAt(0);
        }
        private int counter = 0;
        private bool AbnormalMonitoringFlag = false;
        private int monitorcounter = 0;
        public void Monitoring(double data)
        {
            //var data = e.ParameterMap[Description];
            Push(data);
            if (data < HighThreshold && data > LowThreshold)
            {
                //Console.WriteLine("T1的当前值为：" + this.CurrentValue);
                FirstLevelAlarm = false;
                SecondLevelAlarm = false;
                if ((counter += 1) == interval)
                {
                    counter = 0;
                    CurrentValue = Data.TakeLast(interval).Average();
                    Console.WriteLine(Description + "的当前值为：" + this.CurrentValue);
                    Console.WriteLine(Description + "运行是否异常：" + this.IsAbnormal);
                }
            }
            //异常有待测试
            else
            {
                //更新是否过快
                CurrentValue = data;
                if ((data >= HighThreshold && data < VeryHighThreshold) || (data > VeryLowThreshold && data <= LowThreshold))
                {
                    FirstLevelAlarm = true;
                    SecondLevelAlarm = false;
                }
                else if (data > VeryHighThreshold || data < VeryLowThreshold)
                {
                    FirstLevelAlarm = false;
                    SecondLevelAlarm = true;
                }
                else
                {
                    FirstLevelAlarm = false;
                    SecondLevelAlarm = false;
                }
                AbnormalMonitoringFlag = true;
                Console.WriteLine(Description + "的当前值为：" + this.CurrentValue);
                Console.WriteLine(Description + "运行是否异常：" + this.IsAbnormal);
            }
            if (AbnormalMonitoringFlag)
            {
                if (monitorcounter < Capacity)
                {
                    Abnormal(0.5);
                }
                else
                {
                    if (IsAbnormal == false)
                    {
                        AbnormalMonitoringFlag = false;
                    }
                }
            }
        }
        private int abnormalcounter = 0;
        public void Abnormal(double rate)
        {
            abnormalcounter = 0;
            var data = Data[Capacity - 1];
            foreach (var e in Data)
            {
                if (e >= HighThreshold || e <= LowThreshold)
                {
                    abnormalcounter += 1;
                }
                else if (e < HighThreshold && e > LowThreshold)
                {
                    IsAbnormal = false;
                    AbnormalMonitoringFlag = false;
                }
            }
            if (abnormalcounter / Data.Count >= rate)
            {
                IsAbnormal = true;
            }
        }
    }
}
