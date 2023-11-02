using DocumentFormat.OpenXml.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Math;

namespace ConsoleAppSample.Study.Cls
{
    public class EnumerableCls
    {
        //Enumerable 클래스
        //IEnumerable<T> 을 구현하는 개체를 쿼리하기 위한 정적 (Visual Basic의 경우 Shared) 메서드 집합을 제공합니다.
        //https://learn.microsoft.com/ko-kr/dotnet/api/system.linq.enumerable

        //int[] 변수 초기화
        int[] ints = Enumerable.Range(1, 10).Select(x => x * x).ToArray();
        int[] ints2 = Enumerable.Repeat(1, 10).ToArray();

        EnumerableCls()
        {
            int[] ints3 = Enumerable.Range(1, 10).Select(x => x * x).ToArray();
            var t = from x in ints3 where x == 1 select x;
            //배열 시퀀스 비교
            Enumerable.SequenceEqual(ints, t);
            
        }

        /// <summary>
        /// n 값을 기준으로 가장 가까운 순서대로 정렬
        /// </summary>
        /// <param name="numlist"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        int[] ThenByDescending(int[] numlist, int n)
        {
            int[] answer = numlist.OrderBy(x => Math.Abs(x - n)).ThenByDescending(x => x).ToArray();
            return answer;
        }

    }
}
