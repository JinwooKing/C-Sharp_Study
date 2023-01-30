namespace ConsoleAppSample.study
{
    public class Algorithm
    {
        //자주 사용하는 알고리즘 정리.
        public Algorithm()
        {
            int n = 10;
            int m = 6;

            int gcd = getgcd(n, m); //2
            int lcm = n * m / gcd; //30  최소 공배수
        }
        /// <summary>
        /// 최대공약수, 유클리드 호제법
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int getgcd(int a, int b)
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


        /// <summary>
        /// 10진수를 k진수로 변환
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
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

        /// <summary>
        /// n이 소수인지 판단
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        bool IsPrime(long n)
        {
            if (n == 1)
                return false;
            int target = (int)Math.Sqrt(n);
            for (int i = 2; i <= target; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
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
