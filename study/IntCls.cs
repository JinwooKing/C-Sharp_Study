using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.Study
{
    public class IntCls
    {
        //Int16, Int32, Int64 클래스
        //부호 있는 16, 32, 64비트 정수를 나타냅니다.
        //https://learn.microsoft.com/ko-kr/dotnet/api/system.int32

        //UInt16, UInt32, UInt64 클래스
        //부호 없는 16, 32, 64비트 정수를 나타냅니다.
        //https://learn.microsoft.com/ko-kr/dotnet/api/system.uint32

        public IntCls()
        { 
            Int16 _Int16 = short.MaxValue; //(-32,768 to +32,767) // short
            Int32 _Int32 = int.MaxValue; //(-2,147,483,648 to +2,147,483,647) // int
            Int64 _Int63 = long.MaxValue; //(-9,223,372,036,854,775,808 to + 9,223,372,036,854,775,807) // long

            UInt16 _UInt16 = ushort.MaxValue; //(0 to +65,535)
            UInt32 _UInt32 = uint.MaxValue; //(0 to +4,294,967,295)
            UInt64 _UInt63 = ulong.MaxValue; //(0 to +18,446,744,073,709,551,615)

            Int16 _int16 = short.Parse("32767");
            Int32 _int32 = int.Parse("2147483647");
            Int64 _int64 = long.Parse("9223372036854775807");

            UInt16 _uint16 = ushort.Parse("65535");
            UInt32 _uint32 = uint.Parse("4294967295");
            UInt64 _uint64 = ulong.Parse("18446744073709551615");
        }
    }
}
