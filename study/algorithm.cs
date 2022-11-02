using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.study
{
    class Algorithm
    {
        //자주 사용하는 알고리즘을 정리해놓았습니다.

        public Algorithm()
        {
            int n = 10;
            int m = 6;

            int gcd = getgcd(n, m); //2
            int lcm = n * m / gcd; //30

            char c1 = 'a'; // 97
            char c2 = '0'; // 48
            //입력된 숫자를 문자로 변환
            Convert.ToChar('0' + 49); // 'a'
            Convert.ToChar(int.Parse("0") + 'a');
        }
        /// <summary>
        /// 최소공배수, 유클리드 호제법
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        int getgcd(int a, int b)
        {
            if (a % b == 0)
            {
                return b;
            }
            else
            {
                return getgcd(b, a % b);
            }
        }
    }
}
