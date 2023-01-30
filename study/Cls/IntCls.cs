namespace ConsoleAppSample.Study.Cls
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
            short _Int16 = short.MaxValue; //(-32,768 to +32,767) // short
            int _Int32 = int.MaxValue; //(-2,147,483,648 to +2,147,483,647) // int
            long _Int63 = long.MaxValue; //(-9,223,372,036,854,775,808 to + 9,223,372,036,854,775,807) // long

            ushort _UInt16 = ushort.MaxValue; //(0 to +65,535)
            uint _UInt32 = uint.MaxValue; //(0 to +4,294,967,295)
            ulong _UInt63 = ulong.MaxValue; //(0 to +18,446,744,073,709,551,615)

            short _int16 = short.Parse("32767");
            int _int32 = int.Parse("2147483647");
            long _int64 = long.Parse("9223372036854775807");

            ushort _uint16 = ushort.Parse("65535");
            uint _uint32 = uint.Parse("4294967295");
            ulong _uint64 = ulong.Parse("18446744073709551615");
        }
    }
}
