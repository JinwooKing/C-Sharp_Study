using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.study
{
    class EnumerableCls
    {
        //Enumerable 클래스
        //IEnumerable<T> 을 구현하는 개체를 쿼리하기 위한 정적 (Visual Basic의 경우 Shared) 메서드 집합을 제공합니다.

        //int[] 변수 초기화
        int[] ints = Enumerable.Range(1, 10).Select(x => x * x).ToArray();
        int[] ints2 = Enumerable.Repeat(1, 10).ToArray();
    }
}
