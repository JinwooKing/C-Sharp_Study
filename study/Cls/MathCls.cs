namespace ConsoleAppSample.Study.Cls
{
    public class MathCls
    {
        //Math 클래스
        //삼각, 로그 및 기타 일반 수학 함수에 대한 상수 및 정적 메서드를 제공합니다.
        //https://learn.microsoft.com/ko-kr/dotnet/api/system.math
        public MathCls()
        {
            ///속성///
            //상수, e로 지정된 자연 로그의 밑을 나타냅니다.
            double e = Math.E; // 2.7182818284590451

            //상수(π)로 지정된 원주율을 나타냅니다. 
            double pi = Math.PI; //3.1415926535897931

            ///메서드///
            //숫자의 절대값을 반환합니다.
            Math.Abs(-100);

            //지정된 숫자의 제곱근을 반환합니다.
            Math.Sqrt(100); // 10

            //지정된 숫자의 지정된 거듭제곱을 반환합니다.
            Math.Pow(2, 10); // 1024

            //지정된 수보다 크거나 같은 최소 정수 값을 반환합니다.
            Math.Ceiling(4.2);  // 5   double
            Math.Ceiling(4.7);  // 5   double
            Math.Ceiling(-4.2); // -4  double
            Math.Ceiling(-4.7); // -4  double

            //지정된 수보다 작거나 같은 최대 정수 값을 반환합니다.
            Math.Floor(4.2);    // 4   double
            Math.Floor(4.7);    // 4   double
            Math.Floor(-4.2);   // -5  double
            Math.Floor(-4.7);   // -5  double

            //가장 가까운 정수로 반올림하고 중간점 값을 가장 가까운 짝수로 반올림합니다.
            Math.Round(-4.7);   // -5  double
            Math.Round(-4.2);   // -4  double
            Math.Round(4.7);    // 5   double
            Math.Round(4.2);    // 4   double
            Math.Round(4.22);   // 4   double

            //지정된 수의 소수 자릿수를 소수점 값으로 반올림하고 중간점 값을 가장 가까운 짝수로 반올림합니다.
            Math.Round(4.27, 1);// 4.2 double
            Math.Round(4.27, 1);// 4.3 double

            //지정된 반올림 규칙을 사용하여 반올림합니다.
            //MidpointRounding 열거형
            //https://learn.microsoft.com/ko-kr/dotnet/api/system.midpointrounding

            //ToEven 가장 가까운 숫자로 반올림하는 전략이며, 숫자가 다른 두 개 사이의 중간에 있을 때 가장 가까운 짝수로 반올림됩니다.
            Math.Round(2.5, MidpointRounding.ToEven); // 2
            Math.Round(3.5, MidpointRounding.ToEven); // 4
            Math.Round(-2.5, MidpointRounding.ToEven); // -2
            Math.Round(-3.5, MidpointRounding.ToEven); // -4

            //AwayFromZero 가장 가까운 숫자로 반올림하는 전략이며, 다른 두 숫자 사이에 숫자가 중간이면 0에서 멀리 떨어진 가장 가까운 숫자로 반올림됩니다.
            Math.Round(2.5, MidpointRounding.AwayFromZero); // 3
            Math.Round(3.5, MidpointRounding.AwayFromZero); // 4
            Math.Round(-2.5, MidpointRounding.AwayFromZero); // -3
            Math.Round(-3.5, MidpointRounding.AwayFromZero); // -4

            //ToZero 가장 가깝고 크기가 크지 않은 0으로 반올림하는 전략입니다.
            Math.Round(2.5, MidpointRounding.ToZero); // 2
            Math.Round(3.5, MidpointRounding.ToZero); // 3
            Math.Round(-2.5, MidpointRounding.ToZero); // -2
            Math.Round(-3.5, MidpointRounding.ToZero); // -3

            //ToNegativeInfinity 결과가 무한정 정확한 결과에 가장 가깝고 그보다 크지 않은 하향 방향 반올림 전략입니다.
            Math.Round(2.5, MidpointRounding.ToNegativeInfinity); // 2
            Math.Round(3.5, MidpointRounding.ToNegativeInfinity); // 3
            Math.Round(-2.5, MidpointRounding.ToNegativeInfinity); // -3
            Math.Round(-3.5, MidpointRounding.ToNegativeInfinity); // -4

            //ToPositiveInfinity 결과가 무한정 정확한 결과에 가장 가깝고 그보다 작지 않은 상향 방향 반올림 전략입니다.
            Math.Round(2.5, MidpointRounding.ToPositiveInfinity); // 3
            Math.Round(3.5, MidpointRounding.ToPositiveInfinity); // 4
            Math.Round(-2.5, MidpointRounding.ToPositiveInfinity); // -2
            Math.Round(-3.5, MidpointRounding.ToPositiveInfinity); // -3
        }
    }
}
