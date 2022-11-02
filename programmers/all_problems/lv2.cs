using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.Programmers.all_problems
{
    class lv2
    {
        /// <summary>
        /// 피보나치 수
        /// 2 이상의 n이 입력되었을 때, n번째 피보나치 수를 1234567으로 나눈 나머지를 리턴하는 함수, solution을 완성해 주세요.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        int solution1(int n)
        {
            int bef = 0;
            int cur = 1;
            int answer = 0;
            for (int i = 2; i <= n; i++)
            {
                answer = cur % 1234567 + bef % 1234567;
                bef = cur;
                cur = answer;
            }
            return answer % 1234567;
        }
    }
}
