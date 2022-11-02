using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.programmers.all_problems
{
    class lv0
    {
        /// <summary>
        /// 최빈값 구하기
        /// 최빈값은 주어진 값 중에서 가장 자주 나오는 값을 의미합니다. 정수 배열 array가 매개변수로 주어질 때, 최빈값을 return 하도록 solution 함수를 완성해보세요. 최빈값이 여러 개면 -1을 return 합니다.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 외계행성의 나이
        /// a는 0, b는 1, c는 2, ..., j는 9입니다. 예를 들어 23살은 cd, 51살은 fb로 표현합니다. 
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        string solution2(int age)
        {
            string answer = "";
            foreach (char c in age.ToString())
            {
                answer = string.Concat(answer, Convert.ToChar(c + 49));
                //answer = string.Concat(answer, Convert.ToChar(int.Parse(c.ToString()) + 'a'));
            }

            return answer;
        }
        /// <summary>
        /// 진료 순서 정하기
        /// emergency가 매개변수로 주어질 때 응급도가 높은 순서대로 진료 순서를 정한 배열을 return하도록 solution 함수를 완성해주세요.
        /// </summary>
        /// <param name="emergency"></param>
        /// <returns></returns>
        int[] solution3(int[] emergency)
        {
            int[] answer = new int[emergency.Length];
            int[] sort_emergency = new int[emergency.Length];
            Array.Copy(emergency, sort_emergency, emergency.Length);
            Array.Sort(sort_emergency);
            Array.Reverse(sort_emergency);

            int i = 0;
            foreach (int s in emergency)
            {
                answer[i++] = sort_emergency.ToList().IndexOf(s) + 1;
            }
            return answer;
        }
    }
}
