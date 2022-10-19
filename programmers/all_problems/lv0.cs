using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.programmers.all_problems
{
    internal class lv0
    {
        //최빈값 구하기
        //최빈값은 주어진 값 중에서 가장 자주 나오는 값을 의미합니다. 정수 배열 array가 매개변수로 주어질 때, 최빈값을 return 하도록 solution 함수를 완성해보세요. 최빈값이 여러 개면 -1을 return 합니다.
        int solution1(int[] array)
        {
            int answer = 0;
            int[] t = Enumerable.Repeat(0, 1000).ToArray();

            foreach (int i in array)
            {
                t[i] = t[i] + 1;
            }

            int max = t.Max();
            if (t.Where(i => i.Equals(max)).ToArray().Count() > 1)
                answer = -1;
            else
                answer = t.ToList().IndexOf(max);
            return answer;
        }
    }
}
