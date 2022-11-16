using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.Study
{
    public class StringCls
    {
        //String 클래스
        //텍스트를 UTF-16 코드 단위의 시퀀스로 나타냅니다.
        //https://learn.microsoft.com/ko-kr/dotnet/api/system.string
        public StringCls()
        {
            //변수
            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', };

            //String 초기화
            string st = string.Empty;
            string st2 = new string(chars);
            string st3 = string.Concat(chars);


            string.Join("", chars).Count(x => x == 5);

            char c1 = 'a'; // 'a' = 97 'A' = '65'
            char c2 = 'b'; // 'b' = 98 'B' = '66'
            char c3 = '0'; // '0' = 48 '1' = 49

            

            
            //입력된 숫자를 문자로 변환
            Convert.ToInt32('0'); // 48
            Convert.ToInt32('1'); // 49
            Convert.ToInt32('0'.ToString()); // 0
            Convert.ToInt32('1'.ToString()); // 1

            Convert.ToChar('0' + 49); // 'a'
            Convert.ToChar(int.Parse("0") + 'a'); // a
            Convert.ToChar(int.Parse("1") + 'a'); // b

            string name = "jinwoo park";
            string t = string.Empty;
            name.ToUpper();
            name.ToLower();
           
            char[] tt = "123".ToCharArray();
            Array.IndexOf(tt, '1');

            foreach (char c in name)
            {
                t.ToString();
            }
        }

        //문자열에서 숫자만 분리
        public List<int> getInt()
        {

            List<int> li = new List<int>();
            string t = "a1a2a3a4a5";
            foreach (char c in t)
            {
                if (int.TryParse(c.ToString(), out int value))
                {
                    li.Add(value);
                }
            }
            return li;
        }
    }
}
