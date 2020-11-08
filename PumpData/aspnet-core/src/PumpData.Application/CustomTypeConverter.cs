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
        [Obsolete]
        public ParameterDto Convert(Parameter source, ParameterDto destination, ResolutionContext context)
        {
            var date = source.Id;
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970,1,1));
            long lTime = long.Parse(date.ToString()+"0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            var des= dtStart.Add(toNow);
            ParameterDto d = new ParameterDto
            {
                Time = des,
            };
            return d;
        }
    }
}
