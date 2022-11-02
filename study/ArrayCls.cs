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

        /// <summary>
        /// 더하기
        /// </summary>
        void Sum()
        {
            int[] ints = new int[] { 8, 2, 6, 3, 1, 5, 9, 7, 4 };
            int sum = ints.Sum();
        }
        
        /// <summary>
        /// 정렬
        /// </summary>
        void Sort()
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
        void IndexOfMax()
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

            Array.Copy(ints, ints2, ints.Length);

            Array.Sort(ints);
            Console.WriteLine(ints);
            Console.WriteLine(ints2);
        }
    }
}
