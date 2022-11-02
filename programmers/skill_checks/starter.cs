using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.programmers.skill_checks
{
    class starter
    {
        //프로그래머스 스킬체크 "입문자"
        //https://programmers.co.kr/skill_checks
        //1. n의 제곱근이 정수면 n+1^2 정수가 아니면 -1 리턴
        long solution1(long n)
        {
            long answer = 0;
            int.TryParse(Math.Sqrt(n).ToString(), out int x);

            if (x > 0)
            {
                answer = (long)Math.Pow(x + 1, 2);
            }
            else
            {
                answer = -1;
            }


            return answer;
        }

        //2. 주어진 범위 값에 대한 약수의 개수 홀짝에 따른 더하기 빼기
        int solution2(int left, int right)
        {
            int answer = 0;
            int t;
            for (; left <= right; left++)
            {
                t = 0;
                for (int i = 1; i <= left; i++)
                {
                    if (left % i == 0)
                    {
                        t++;
                    }
                }

                if (t % 2 == 0)
                {
                    answer += left;
                }
                else
                {
                    answer -= left;
                }
            }


            return answer;
        }

    }
}
