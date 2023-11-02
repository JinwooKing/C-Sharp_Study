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
        /// 피보나치
        /// </summary>
        public void fibonacci()
        {
            var fibonacciNumbers = new List<int> { 1, 1 };

            while (fibonacciNumbers.Count < 20)
            {
                var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
                var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];

                fibonacciNumbers.Add(previous + previous2);
            }
            foreach (var item in fibonacciNumbers)
                Console.WriteLine(item);
        }

        /// <summary>
        /// n이 소수인지 판단
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        bool IsPrime(int n)
        {
            if (n <= 1)
                return false;
            if (n <= 3)
                return true;
            if (n % 2 == 0 || n % 3 == 0)
                return false;

            for (int i = 5; i * i <= n; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;
            }

            return true;
        }

        bool IsPrime2(int num)
        {
            for (int i = 2; i * i <= num; i++)
                if (num % i == 0)
                    return false;
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
