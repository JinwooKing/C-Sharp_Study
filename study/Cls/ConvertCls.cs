using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.Study.Cls
{
    internal class ConvertCls
    {
        //Convert 클래스
        //기본 데이터 형식을 다른 데이터 형식으로 변환합니다.
        //https://learn.microsoft.com/ko-kr/dotnet/api/system.convert

        public ConvertCls()
        {
            //x진수를 10진수로  Convert.ToInt16, 32(Source, x진수)
            //10진수를 x진수 문자열로 Convert.ToString(Source, x진수)

            // 2진수 문자열을 10진수 숫자로
            string strBase2 = "0000011011101010"; // 0x06EA
            int iBase10 = Convert.ToInt32(strBase2, 2);

            // 10진수 숫자를 16진수 문자열 (영문소문자)
            string strHex = Convert.ToString(iBase10, 16);

            // 10진수 숫자를 16진수 문자열 (영문대문자)  
            // (X4: Hexa 4자리, 영문은 대문자로)
            string strHex2 = iBase10.ToString("X4");

            // 위의 ToString과 동일한 표현
            string strHex3 = string.Format("{0:X4}", iBase10);

            // 16진수 문자열을 10진수로
            int iBase10_2 = Convert.ToInt32(strHex3, 16);

            // 10진수를 2진수 문자열로
            string strBase2_2 = Convert.ToString(iBase10, 2);
            
            Console.WriteLine(" 2진수: {0}", strBase2); // 0000011011101010
            Console.WriteLine("10진수: {0}", iBase10);  // 1770
            Console.WriteLine("16진수: {0}", strHex);   // 6ea
            Console.WriteLine("16진수: {0}", strHex2);  // 06EA
            Console.WriteLine("10진수: {0}", iBase10_2);  // 1770

            // Hex 문자열을 바이트로 
            string hexStr = "5A";
            byte b1 = Convert.ToByte(hexStr, 16);
            Console.WriteLine("{0:X}", b1);
            // 또 다른 방법
            string s = "9E";
            byte b2 = byte.Parse(s, NumberStyles.HexNumber);


        }

    }
}
