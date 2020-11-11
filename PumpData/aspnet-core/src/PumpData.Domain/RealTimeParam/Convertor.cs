using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace PumpData.RealTimeParam
{
    public static class Convertor
    {
        public static BsonTimestamp ConvertToTimeStamp(this string strTime)
        {
            TimeSpan ts = Convert.ToDateTime(strTime) - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var s = Convert.ToInt64(ts.TotalSeconds-28800).ToString();
            return BsonTimestamp.Create(s);
        }
        public static DateTime ConvertToDateTime(this BsonTimestamp Id)
        {
            DateTime dtStart = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1,8,0,0,0), TimeZoneInfo.Local);
            long lTime = long.Parse(Id.ToString() + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }
        public static BsonTimestamp DateTimeToStamp(this DateTime time)
        {
            TimeSpan ts = time - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var s = Convert.ToInt64(ts.TotalSeconds - 28800).ToString();
            return BsonTimestamp.Create(s);
            
        }
    }
}
