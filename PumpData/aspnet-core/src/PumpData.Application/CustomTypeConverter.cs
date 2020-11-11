using AutoMapper;
using MongoDB.Bson;
using PumpData.RealTimeParam;
using System;
using System.Collections.Generic;
using System.Text;

namespace PumpData
{
    public class CustomTypeConverter  : ITypeConverter<Parameter, ParameterDto>
    {
        public ParameterDto Convert(Parameter source, ParameterDto destination, ResolutionContext context)
        {
            var date = source.Id;
            DateTime dtStart = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
            long lTime = long.Parse(date.ToString()+"0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            var des= dtStart.Add(toNow);
            ParameterDto d = new ParameterDto
            {
                Time = des.ToString(),
            };
            return d;
        }
    }
}
