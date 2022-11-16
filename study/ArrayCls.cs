using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.study
{
    public class ArrayCls
    {
        //Array 클래스
        //배열을 만들고, 조작하고, 검색 및 정렬하여 공용 언어 런타임에서 모든 배열의 기본 클래스 역할을 수행하도록 하는 메서드를 제공합니다.
        //https://learn.microsoft.com/ko-kr/dotnet/api/system.array

        ArrayCls(){

            long t = 12345;
            Array.Sort(t.ToString().ToArray());
            t.ToString().AsEnumerable().Reverse();
            var temp = from num in t.ToString() select Convert.ToInt16(t.ToString());
            int[] ints = new int[] { 8, 2, 6, 3, 1, 5, 9, 7, 4 };
            int[] ints2 = new int[] { };
            int[] ints3 = new int[3];

            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', };
            chars.Reverse();
            ints.Max(); // 최대값
            ints.Sum(); // 모든합
            ints.Average(); // 평균
            ints.Reverse(); // 뒤집기
            
            Array.IndexOf(ints, ints.Max()); // Array의 인덱스 찾기

            char[] tt = "123".ToCharArray();
            Array.IndexOf(tt, '1'); // 0
            Array.IndexOf(tt, "1"); // -1
            Array.IndexOf(tt, 1); // -1
            Array.IndexOf(tt, Convert.ToChar(1)); // -1
            Array.IndexOf(tt, Convert.ToChar(1.ToString())); // 0

            //Array의 최대값과 Index 구하기
            int[] answer = new int[2] { ints.Max(), Array.IndexOf(ints, ints.Max()) };

            
            List<int> intList = ints.ToList();
            intList.Remove(1);
            intList.IndexOf(1); // index 찾기, 값이 없을 시 -1
            intList.Count(); // 배열 크기
            intList.Distinct(); // 중복 제거
            intList.Reverse(); // 뒤집기

            string before = "apple";
            List<char> beflist = new List<char>(before.ToArray());
            beflist.Remove('p');
        }
        /// <summary>
        /// 더하기
        /// </summary>
        public void Sum()
        {
            int[] ints = new int[] { 8, 2, 6, 3, 1, 5, 9, 7, 4 };
            int sum = ints.Sum();
        }

        /// <summary>
        /// 정렬
        /// </summary>
        public void Sort()
        {
            int[] ints = new int[] { 8, 2, 6, 3, 1, 5, 9, 7, 4 };
            List<int> tt = new();
            
            foreach (int i in ints)
                Console.WriteLine(i);
            // Array Sort
            Array.Sort(ints);
            Array.Reverse(ints);
            foreach (int i in ints)
                Console.WriteLine(i);
        }

        /// <summary>
        /// 최대값 인덱스
        /// </summary>
        public void IndexOfMax()
        {
            int[] ints = new int[] { 8, 2, 6, 3, 1, 5, 9, 7, 4 };
            int maxIndex = Array.IndexOf(ints, ints.Max());
        }

        /// <summary>
        /// 얕은 복사
        /// </summary>
        public void shallowCopy()
        {
            int[] ints = new int[] { 8, 5, 2, 4, 6, 3, 1, 7 };
            int[] ints2 = new int[] { };

            ints2 = ints;

            Array.Sort(ints);
            Console.WriteLine(ints);
            Console.WriteLine(ints2);
        }

        /// <summary>
        /// 깊은 복사
        /// </summary>
        public void deepCopy()
        {
            int[] ints = new int[] { 8, 5, 2, 4, 6, 3, 1, 7 };
            int[] ints2 = new int[ints.Length];
            ints.CopyTo(ints2, 0); // { 8, 5, 2, 4, 6, 3, 1, 7 }
            Array.Copy(ints, ints2, ints.Length); // { 8, 5, 2, 4, 6, 3, 1, 7 }

            Array.Sort(ints);
            Console.WriteLine(ints);
            Console.WriteLine(ints2);
        }
        public int[] solution(long n)
        {
            int[] answer = new int[] { };

            char[] charArray = n.ToString().ToCharArray();
            System.Array.Reverse(charArray);

            answer = System.Array.ConvertAll(charArray, c => (int)char.GetNumericValue(c));

            return answer;
        }

        //int[]에 x 포함 갯수 찾기
        public int solution(int[] array)
        {
            int answer = string.Join("", array).Count(x => x == '7');
            return answer;
        }
    }
}
