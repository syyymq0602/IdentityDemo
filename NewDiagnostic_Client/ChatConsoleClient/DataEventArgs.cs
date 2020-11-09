using System;
using System.Collections.Generic;

namespace ChatConsoleClient
{
    public class DataEventArgs : EventArgs
    {
        public double Pressure1 { get; set; }
        public double Pressure2 { get; set; }
        public double Pressure3 { get; set; }
        public Dictionary<string, double> ParameterMap { get; set; }
        public void Mapping()
        {
            ParameterMap = new Dictionary<string, double> { { "Pressure1", Pressure1 }, { "Pressure2", Pressure2 }, { "Pressure3", Pressure3 } };
        }
    }
}