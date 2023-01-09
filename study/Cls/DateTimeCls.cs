using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.Study.Cls
{
    public class DateTimeCls
    {
        //DateTime 구조체
        //일반적으로 날짜와 시간으로 표시된 시간을 나타냅니다.
        //https://learn.microsoft.com/ko-kr/dotnet/api/system.datetime

        DateTimeCls()
        {
            ConvertFromUnixTimestamp(1666974296421); //2022-10-29 01:24:56
        }


        DateTime ConvertFromUnixTimestamp(double timestamp)

        {

            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);

            return origin.AddMilliseconds(timestamp).AddHours(9);  //TimeZone 고려 GMT+09:00 더해줌

        }
    }
}
