using System;
using System.Numerics;
using System.Text;

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
                t[i]++;
            }

            int max = t.Max();
            if (t.Where(i => i.Equals(max)).Count() > 1)
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

        /// <summary>
        /// 옹알이
        /// </summary>
        /// <param name="babblings"></param>
        /// <returns></returns>
        public int solution9(string[] babblings)
        {
            int answer = 0;
            foreach (string babbling in babblings)
            {
                if (string.IsNullOrWhiteSpace(babbling.Replace("aya", " ")
                                                        .Replace("ye", " ")
                                                        .Replace("woo", " ")
                                                        .Replace("ma", " ")))
                    answer++;
            }

            return answer;
        }

        /// <summary>
        /// 길이에 따른 연산
        /// 정수가 담긴 리스트 num_list가 주어질 때, 리스트의 길이가 11 이상이면 리스트에 있는 모든 원소의 합을 10 이하이면 모든 원소의 곱을 return하도록 solution 함수를 완성해주세요.
        /// </summary>
        /// <param name="num_list"></param>
        /// <returns></returns>
        public int solution10(int[] num_list)
        {
            int answer = num_list.Length <= 10 ? num_list.Aggregate((a, b) => a * b) : num_list.Sum();
            return answer;
        }

        /// <summary>
        /// 첫 번째로 나오는 음수
        /// 정수 리스트 num_list가 주어질 때, 첫 번째로 나오는 음수의 인덱스를 return하도록 solution 함수를 완성해주세요. 음수가 없다면 -1을 return합니다.
        /// </summary>
        /// <param name="num_list"></param>
        /// <returns></returns>
        public int solution11(int[] num_list)
        {
            return Array.FindIndex(num_list, f => f < 0);
        }

        /// <summary>
        /// 마지막 두 원소
        /// 정수 리스트 num_list가 주어질 때, 마지막 원소가 그전 원소보다 크면 마지막 원소에서 그전 원소를 뺀 값을 마지막 원소가 그전 원소보다 크지 않다면 마지막 원소를 두 배한 값을 추가하여 return하도록 solution 함수를 완성해주세요.
        /// </summary>
        /// <param name="num_list"></param>
        /// <returns></returns>
        public int[] solution12(int[] num_list)
        {
            int[] answer = new int[num_list.Length + 1];
            Array.Copy(num_list, answer, num_list.Length);
            int a = num_list[num_list.Length - 2];
            int b = num_list[num_list.Length - 1];
            answer[answer.Length - 1] = b > a ? b - a : b * 2;
            return answer;
        }

        /// <summary>
        /// 배열의 원소만큼 추가하기
        /// 아무 원소도 들어있지 않은 빈 배열 X가 있습니다. 양의 정수 배열 arr가 매개변수로 주어질 때, arr의 앞에서부터 차례대로 원소를 보면서 원소가 a라면 X의 맨 뒤에 a를 a번 추가하는 일을 반복한 뒤의 배열 X를 return 하는 solution 함수를 작성해 주세요.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] solution13(int[] arr)
        {
            List<int> answer = new List<int>();
            foreach (int n in arr)
                answer.AddRange(Enumerable.Repeat(n, n));
            return answer.ToArray();
        }

        /// <summary>
        /// 순서 바꾸기
        /// 정수 리스트 num_list와 정수 n이 주어질 때, num_list를 n 번째 원소 이후의 원소들과 n 번째까지의 원소들로 나눠 n 번째 원소 이후의 원소들을 n 번째까지의 원소들 앞에 붙인 리스트를 return하도록 solution 함수를 완성해주세요.
        /// </summary>
        /// <param name="num_list"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] solution14(int[] num_list, int n) // n이 1번부터 시작하는 인덱스임에 주의
        {
            int[] answer = new int[num_list.Length];

            Array.Copy(num_list, n, answer, 0, num_list.Length - n); // n 번째이후 원소 -> 앞으로 
            Array.Copy(num_list, 0, answer, num_list.Length - n, n); // n 번째까지의 원소 -> 뒤로

            return answer;
        }

        /// <summary>
        /// 가까운 1 찾기
        /// 정수 배열 arr가 주어집니다. 이때 arr의 원소는 1 또는 0입니다. 정수 idx가 주어졌을 때, idx보다 크면서 배열의 값이 1인 가장 작은 인덱스를 찾아서 반환하는 solution 함수를 완성해 주세요. 단, 만약 그러한 인덱스가 없다면 -1을 반환합니다.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public int solution15(int[] arr, int idx)
        {
            int index = 0;
            return Array.FindIndex(arr, x => index++ >= idx && x == 1);
        }

        /// <summary>
        /// 문자열 잘라서 정렬하기

        /// 문자열 myString이 주어집니다. "x"를 기준으로 해당 문자열을 잘라내 배열을 만든 후 사전순으로 정렬한 배열을 return 하는 solution 함수를 완성해 주세요. 단, 빈 문자열은 반환할 배열에 넣지 않습니다.
        /// </summary>
        /// <param name="myString"></param>
        /// <returns></returns>
        public string[] solution16(string myString)
        {
            return myString.Split('x', StringSplitOptions.RemoveEmptyEntries)
                           .OrderBy(o => o)
                           .ToArray();
        }

        /// <summary>
        /// 등차수열의 특정한 항만 더하기
        /// 두 정수 a, d와 길이가 n인 boolean 배열 included가 주어집니다. 첫째항이 a, 공차가 d인 등차수열에서 included[i]가 i + 1항을 의미할 때, 이 등차수열의 1항부터 n항까지 included가 true인 항들만 더한 값을 return 하는 solution 함수를 작성해 주세요.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="d"></param>
        /// <param name="included"></param>
        /// <returns></returns>
        public int solution17(int a, int d, bool[] included)
        {
            return Enumerable.Range(0, included.Length).Sum(s => included[s] ? a + (d * s) : 0);
        }

        /// <summary>
        /// 날짜 비교하기
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public int solution18(int[] date1, int[] date2)
        {
            
            int d1 = int.Parse($"{date1[0]}{date1[1]}{date1[2]}");
            int d2 = int.Parse($"{date2[0]}{date2[1]}{date2[2]}");
            return d1 < d2 ? 1 : 0;
        }

        /// <summary>
        /// 문자열 뒤집기
        /// 문자열 my_string과 정수 s, e가 매개변수로 주어질 때, my_string에서 인덱스 s부터 인덱스 e까지를 뒤집은 문자열을 return 하는 solution 함수를 작성해 주세요.
        /// </summary>
        /// <param name="my_string"></param>
        /// <param name="s"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public string solution19(string my_string, int s, int e)
        {
            return new string(my_string.Select((c, index) =>
            {
                if (s <= index && index <= e)
                    return my_string[s + e - index];
                else
                    return c;
            }).ToArray());
            
        }
         
        /// <summary>
        /// 문자열 뒤집기
        /// 문자열 my_string과 정수 s, e가 매개변수로 주어질 때, my_string에서 인덱스 s부터 인덱스 e까지를 뒤집은 문자열을 return 하는 solution 함수를 작성해 주세요.
        /// </summary>
        /// <param name="my_string"></param>
        /// <param name="s"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public string solution20(string my_string, int s, int e)
        {
            char[] chr = my_string.ToCharArray();
            Array.Reverse(chr, s, e - s + 1);
            return new string(chr);
        }

        /// <summary>
        /// 세 개의 구분자
        /// 임의의 문자열이 주어졌을 때 문자 "a", "b", "c"를 구분자로 사용해 문자열을 나누고자 합니다.
        /// 예를 들어 주어진 문자열이 "baconlettucetomato"라면 나눠진 문자열 목록은["onlettu", "etom", "to"] 가 됩니다.
        /// 문자열 myStr이 주어졌을 때 위 예시와 같이 "a", "b", "c"를 사용해 나눠진 문자열을 순서대로 저장한 배열을 return 하는 solution 함수를 완성해 주세요.
        /// 단, 두 구분자 사이에 다른 문자가 없을 경우에는 아무것도 저장하지 않으며, return할 배열이 빈 배열이라면 ["EMPTY"] 를 return 합니다.
        /// </summary>
        /// <param name="myStr"></param>
        /// <returns></returns>
        public string[] solution21(string myStr)
        {
            char[] separators = new char[3] { 'a', 'b', 'c' };
            string[] answer = myStr.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            return answer.Length == 0 ? new string[1] { "EMPTY" } : answer;
        }

        /// <summary>
        /// 리스트 자르기
        /// 정수 n과 정수 3개가 담긴 리스트 slicer 그리고 정수 여러 개가 담긴 리스트 num_list가 주어집니다. slicer에 담긴 정수를 차례대로 a, b, c라고 할 때, n에 따라 다음과 같이 num_list를 슬라이싱 하려고 합니다.
        ///n = 1 : num_list의 0번 인덱스부터 b번 인덱스까지
        ///n = 2 : num_list의 a번 인덱스부터 마지막 인덱스까지
        ///n = 3 : num_list의 a번 인덱스부터 b번 인덱스까지
        ///n = 4 : num_list의 a번 인덱스부터 b번 인덱스까지 c 간격으로
        ///올바르게 슬라이싱한 리스트를 return하도록 solution 함수를 완성해주세요.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="slicer"></param>
        /// <param name="num_list"></param>
        /// <returns></returns>
        int[] solution22(int n, int[] slicer, int[] num_list)
        {
            int[] answer;
            switch (n)
            {
                case 1:
                    answer = new int[slicer[1] + 1];
                    Array.Copy(num_list, 0, answer, 0, answer.Length);
                    break;
                case 2:
                    answer = new int[num_list.Length - slicer[0]];
                    Array.Copy(num_list, slicer[0], answer, 0, answer.Length);
                    break;
                case 3:
                    answer = new int[slicer[1] - slicer[0] + 1];
                    Array.Copy(num_list, slicer[0], answer, 0, answer.Length);
                    break;
                default:
                    answer = num_list.Where((x, i) => i >= slicer[0] && i <= slicer[1] && (i - slicer[0]) % slicer[2] == 0).ToArray();
                    break;
            }

            return answer;
        }

        /// <summary>
        /// 두 개의 큰 숫자 더하기
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        string solution23(string a, string b)
        {
            int maxLength = Math.Max(a.Length, b.Length);
            StringBuilder result = new StringBuilder(maxLength + 1);

            // 두 문자열을 뒤에서부터 한 자리씩 더하고 올림 값을 처리합니다.
            int carry = 0;
            for (int i = 1; i <= maxLength; i++)
            {
                int digitA = i <= a.Length ? a[a.Length - i] - '0' : 0;
                int digitB = i <= b.Length ? b[b.Length - i] - '0' : 0;

                int sum = digitA + digitB + carry;
                carry = sum / 10;
                sum %= 10;

                result.Insert(0, sum);
            }

            // 마지막 올림 값을 처리합니다.
            if (carry > 0)
            {
                result.Insert(0, carry);
            }
            
            return result.ToString();
        }

        /// <summary>
        /// 그림 확대
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        string[] solution24(string[] arr, int num)
        {
            string[] answer = new string[arr.Length * num];
            int j = 0;
            foreach (string s in arr)
            {
                string t = string.Join("", s.Select(x => new string(Enumerable.Repeat(x, num).ToArray())));
                for (int i = 0; i < num; i++, j++)
                {
                    answer[j] = t;
                }
            }

            return answer;
        }

        /// <summary>
        /// 전국 대회 선발 고사
        ///0번부터 n - 1번까지 n명의 학생 중 3명을 선발하는 전국 대회 선발 고사를 보았습니다. 등수가 높은 3명을 선발해야 하지만, 개인 사정으로 전국 대회에 참여하지 못하는 학생들이 있어 참여가 가능한 학생 중 등수가 높은 3명을 선발하기로 했습니다. 각 학생들의 선발 고사 등수를 담은 정수 배열 rank와 전국 대회 참여 가능 여부가 담긴 boolean 배열 attendance가 매개변수로 주어집니다.전국 대회에 선발된 학생 번호들을 등수가 높은 순서대로 각각 a, b, c번이라고 할 때 10000 × a + 100 × b + c를 return 하는 solution 함수를 작성해 주세요.
        /// </summary>
        /// <param name="rank"></param>
        /// <param name="attendance"></param>
        /// <returns></returns>
                int solution25(int[] rank, bool[] attendance)
        {
            var list = rank.Where((x, i) => attendance[i]).OrderBy(x => x).Take(3).ToArray();
            int answer = Array.IndexOf(rank, list[0]) * 10000 + Array.IndexOf(rank, list[1]) * 100 + Array.IndexOf(rank, list[2]);
            return answer;
        }

        /// <summary>
        /// l과 r 사이에 0과 5만 포함된 숫자 리턴
        /// </summary>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        int[] solution26(int l, int r)
        {
            List<int> answer = new List<int>();

            for (int i = l; i <= r; i++)
            {
                if (ContainsOnly05(i))
                {
                    answer.Add(i);
                }
            }

            bool ContainsOnly05(int i)
            {
                while (i > 0)
                {
                    int digite = i % 10;
                    if (digite != 0 && digite != 5)
                        return false;
                    i /= 10;
                }

                return true;
            }
            return answer.Count > 0 ? answer.ToArray() : new int[] { -1 };
        }

        /// <summary>
        /// 주사위 같은 개수에 따른 리턴값 다르게 하기
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        int solution27(int a, int b, int c, int d)
        {
            var list = new int[4] { a, b, c, d };

            var arr = list.GroupBy(g => g)
                          .OrderByDescending(g => g.Count())
                          .Select(s => (s.Key, s.Count()))
                          .ToArray();

            if (arr[0].Item2 == 4) // 4
            {
                return 1111 * arr[0].Item1;
            }
            else if (arr[0].Item2 == 3) // 3, 1
            {
                return (int)Math.Pow(10 * arr[0].Item1 + arr[1].Item1, 2);
            }
            else if (arr[0].Item2 == 2)
            {
                if (arr[1].Item2 == 2) // 2, 2
                {
                    return (arr[0].Item1 + arr[1].Item1) * Math.Abs(arr[0].Item1 - arr[1].Item1);
                }
                else // 2, 1, 1
                {
                    return arr[1].Item1 * arr[2].Item1;
                }
            }
            else // 1, 1, 1, 1
            {
                return list.Min();
            }

            int answer = 0;
            return answer;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="rank"></param>
        /// <param name="attendance"></param>
        /// <returns></returns>
        public int solution28(int[] rank, bool[] attendance)
        {
            var list = new List<(int rank, int index)>();
            for (int i = 0; i < rank.Length; ++i)
            {
                if (attendance[i]) 
                    list.Add((rank[i], i));
            }

            var arr = list.OrderBy(o => o.Item1).Take(3).ToArray();
            return 10000 * arr[0].Item2 + 100 * arr[1].Item2 + arr[2].Item2;
        }

        /// <summary>
        /// 정수를 나선형으로 배치하기
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[,] Solution29(int n)
        {
            int[,] answer = new int[n, n];
            int[] dx = { 1, 0, -1, 0 };  // x 좌표 이동 패턴
            int[] dy = { 0, 1, 0, -1 };  // y 좌표 이동 패턴

            int direction = 0;  // 현재 이동 방향 (0: 오른쪽, 1: 아래, 2: 왼쪽, 3: 위)
            int x = 0, y = 0;   // 현재 위치
            int maxValue = n * n;  // 최대 값

            for (int i = 1; i <= maxValue; i++)
            {
                answer[y, x] = i;

                int nextX = x + dx[direction];
                int nextY = y + dy[direction];

                // 다음 위치가 배열 범위를 벗어나거나 이미 값이 할당된 경우 방향 전환
                if (nextX < 0 || nextX >= n || nextY < 0 || nextY >= n || answer[nextY, nextX] != 0)
                {
                    direction = (direction + 1) % 4;  // 방향 전환 (0 -> 1 -> 2 -> 3 -> 0)
                    nextX = x + dx[direction];
                    nextY = y + dy[direction];
                }

                x = nextX;
                y = nextY;
            }

            return answer;
        }
    }
}
