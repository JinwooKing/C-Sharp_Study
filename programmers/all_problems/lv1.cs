using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.Programmers.all_problems
{
    internal class lv1
    {
        /// <summary>
        /// 문자열 다루기 기본
        /// 문자열 s의 길이가 4 혹은 6이고, 숫자로만 구성돼있는지 확인해주는 함수, solution을 완성하세요. 예를 들어 s가 "a234"이면 False를 리턴하고 "1234"라면 True를 리턴하면 됩니다.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool solution1(string s)
        {
            bool answer = false;
            if (s.Length == 4 || s.Length == 6)
                answer = int.TryParse(s, out int num);
            return answer;
        }

        /// <summary>
        /// 체육복
        /// 전체 학생의 수 n, 체육복을 도난당한 학생들의 번호가 담긴 배열 lost, 여벌의 체육복을 가져온 학생들의 번호가 담긴 배열 reserve가 매개변수로 주어질 때, 체육수업을 들을 수 있는 학생의 최댓값을 return 하도록 solution 함수를 작성해주세요.
        /// TIP : 배열이 정리되지 않음, 여벌이 있는 학생도 도난을 맞음.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="lost"></param>
        /// <param name="reserve"></param>
        /// <returns></returns>
        public int solution2(int n, int[] lost, int[] reserve)
        {
            Array.Sort(reserve);
            Array.Sort(lost);

            List<int> t_reserve = reserve.ToList();
            List<int> t_lost = lost.ToList();

            foreach (int t in lost)
            {
                if (t_reserve.IndexOf(t) >= 0)
                {
                    t_lost.Remove(t);
                    t_reserve.Remove(t);
                }
            }

            foreach (int t in lost)
            {
                if (t_reserve.IndexOf(t - 1) >= 0)
                {
                    t_lost.Remove(t);
                    t_reserve.Remove(t - 1);
                }
                else if (t_reserve.IndexOf(t + 1) >= 0)
                {
                    t_lost.Remove(t);
                    t_reserve.Remove(t + 1);
                }
            }

            int answer = n - t_lost.Count(); ;
            return answer; 
        }


        /// <summary>
        /// 이상한 문자 만들기
        /// 문자열 s는 한 개 이상의 단어로 구성되어 있습니다. 각 단어는 하나 이상의 공백문자로 구분되어 있습니다. 각 단어의 짝수번째 알파벳은 대문자로, 홀수번째 알파벳은 소문자로 바꾼 문자열을 리턴하는 함수, solution을 완성하세요.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string solution3(string s)
        {
            string answer = "";
            int num = 0;

            for (int i = 0; i < s.Length; i++)
            {
                answer += num % 2 == 0 ? s[i].ToString().ToUpper() : s[i].ToString().ToLower();

                num = s[i] == ' ' ? 0 : num + 1;

            }


            return answer;
        }
        /// <summary>
        /// 자연수 뒤집어 배열로 만들기
        /// 자연수 n을 뒤집어 각 자리 숫자를 원소로 가지는 배열 형태로 리턴해주세요. 예를들어 n이 12345이면 [5,4,3,2,1]을 리턴합니다.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] solution4(long n)
        {
            int size = n.ToString().Length;
            int[] answer = new int[size];

            for (int i = 0; i < size; i++)
            {
                answer[i] = (int)(n % 10);
                n /= 10;
            }
            return answer;
        }

        /// <summary>
        /// 정수 제곱근 판별
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public long solution5(long n)
        {
            long x = (long)Math.Sqrt(n);
            return (x * x == n) ? (x + 1) * (x + 1) : -1;
        }

        /// <summary>
        /// 정수 제곱근 판별
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public long solution(long n)
        {
            long answer = 0;

            var sqrt = Math.Sqrt(n);
            // 정수인지 확인
            if (sqrt % 1.0 != 0)
                return -1;

            answer = (long)sqrt;

            answer += 1;
            answer *= answer;

            return answer;
        }
    }
}
