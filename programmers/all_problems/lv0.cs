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
        public int solution1(int[] array)
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
        public string solution2(int age)
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
        public int[] solution3(int[] emergency)
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

        /// <summary>
        /// 숨어있는 숫자의 덧셈 (1)
        /// 문자열 my_string이 매개변수로 주어집니다. my_string안의 모든 자연수들의 합을 return하도록 solution 함수를 완성해주세요.
        /// </summary>
        /// <param name="my_string"></param>
        /// <returns></returns>
        public int solution4(string my_string)
        {
            int answer = 0;
            foreach (char c in my_string)
            {
                if (int.TryParse(c.ToString(), out int t))
                    answer += t;
            }
            return answer;
        }

        /// <summary>
        /// 모스부호 (1)
        ///  문자열 letter가 매개변수로 주어질 때, letter를 영어 소문자로 바꾼 문자열을 return 하도록 solution 함수를 완성해보세요. 
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        public string solution5(string letter)
        {
            string[] mos = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
            string answer = "";

            foreach (string s in letter.Split(" "))
            {
                answer += Convert.ToChar(Array.IndexOf(mos, s) + 97);
            }

            return answer;
        }

        /// <summary>
        /// 구슬을 나누는 경우의 수
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int solution6(int n, int m)
        {
            long GetFactorial(int n, int m)
            {
                if (n == m)
                    return 1;

                long t = 1;
                long b = 1;
                long b2 = 1;
                for (int i = 2; i <= n; i++)
                {
                    t = t * i;

                    if (i <= (n - m))
                        b = b * i;

                    if (i <= m)
                        b2 = b2 * i;

                    if (t % b == 0 && b > 1)
                    {
                        t = t / b;
                        b = 1;
                    }

                    if (t % b2 == 0 && b2 > 1)
                    {
                        t = t / b2;
                        b2 = 1;
                    }

                    long gcd = 0;

                    if (b > b2)
                    {
                        gcd = Getgcd(t, b);
                        t = t / gcd;
                        b = b / gcd;
                    }
                    else
                    {
                        gcd = Getgcd(t, b2);
                        t = t / gcd;
                        b2 = b2 / gcd;
                    }
                }

                t = t / (b * b2);
                return t;
            }

            if (m >= n / 2)
            {
                m = n - m;
            }
            long answer = GetFactorial(n, m);
            return (Int32)answer;
        }

        long Getgcd(long a, long b)
        {
            if (a % b == 0)
                return b;
            return Getgcd(b, a % b);
        }

        /// <summary>
        /// 한 번만 등장한 문자
        /// 문자열 s가 매개변수로 주어집니다. s에서 한 번만 등장하는 문자를 사전 순으로 정렬한 문자열을 return 하도록 solution 함수를 완성해보세요. 한 번만 등장하는 문자가 없을 경우 빈 문자열을 return 합니다.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string solution7(string s)
        {
            string answer = string.Concat(s.Where(x => s.Count(o => o == x) == 1).OrderBy(x => x));
            return answer;
        }

        /// <summary>
        /// 문자열 계산하기
        /// my_string은 "3 + 5"처럼 문자열로 된 수식입니다. 문자열 my_string이 매개변수로 주어질 때, 수식을 계산한 값을 return 하는 solution 함수를 완성해주세요.
        /// </summary>
        /// <param name="my_string"></param>
        /// <returns></returns>
        public int solution8(string my_string)
        {
            int answer = 0;

            string[] spritstr = my_string.Split(" ");
            string operation = string.Empty;
            foreach (string s in spritstr)
            {
                if (int.TryParse(s, out int temp))
                {
                    if (operation == "-")
                    {
                        answer -= temp;
                    }
                    else
                    {
                        answer += temp;
                    }
                }
                else
                {
                    operation = s;
                }
            }

            return answer;
        }
    }
}
