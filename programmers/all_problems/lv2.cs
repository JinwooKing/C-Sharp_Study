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

        /// <summary>
        /// k진수에서 소수 개수 구하기
        /// 정수 n과 k가 매개변수로 주어집니다. n을 k진수로 바꿨을 때, 변환된 수 안에서 찾을 수 있는 위 조건에 맞는 소수의 개수를 return 하도록 solution 함수를 완성해 주세요.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        int solution2(int n, int k)
        {
            int answer = 0;
            string num = Getradix(n, k);
            string[] numArray = num.Split("0", StringSplitOptions.RemoveEmptyEntries);

            foreach (string target in numArray)
            {
                if (IsDecimal(long.Parse(target)))
                {
                    answer++;
                }
            }

            return answer;
        }

        string Getradix(int n, int k)
        {
            string rtnVal = "";
            while (n > 0)
            {
                rtnVal = string.Concat(n % k, rtnVal);
                n = n / k;
            }
            return rtnVal;
        }

        bool IsDecimal(long n)
        {
            if (n == 1)
                return false;

            for (int i = 2; i <= (long)Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }


    }
}
