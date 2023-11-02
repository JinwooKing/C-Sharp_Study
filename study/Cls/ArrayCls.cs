namespace ConsoleAppSample.Study.Cls
{
    public class ArrayCls
    {
        //Array 클래스
        //배열을 만들고, 조작하고, 검색 및 정렬하여 공용 언어 런타임에서 모든 배열의 기본 클래스 역할을 수행하도록 하는 메서드를 제공합니다.
        //https://learn.microsoft.com/ko-kr/dotnet/api/system.array

        public ArrayCls()
        {
            //int[] ints = Enumerable.Range(1, 10).Select(x => x * x).ToArray();
            //int[] ints2 = Enumerable.Repeat(1, 10).ToArray();

            int[] ints = new int[3];
            int[] ints2 = new int[] { };
            int[] ints3 = new int[] { 8, 2, 6, 3, 1, 5, 9, 7, 4 };
            int[] ints4 = new int[5] { 1, 2, 3, 4, 5 };

            int[,] ints5 = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            ints5.GetLength(0); // 3
            ints5.GetLength(1); // 2

            #region Array
            // Creates and initializes a new three-dimensional Array of type int.
            Array myArr = Array.CreateInstance(typeof(int), 2, 3, 4);//{int[2, 3, 4]}
            for (int i = myArr.GetLowerBound(0); i <= myArr.GetUpperBound(0); i++)
            {
                for (int j = myArr.GetLowerBound(1); j <= myArr.GetUpperBound(1); j++)
                {
                    for (int k = myArr.GetLowerBound(2); k <= myArr.GetUpperBound(2); k++)
                    {
                        myArr.SetValue((i * 100) + (j * 10) + k, i, j, k);
                    }
                }
            }

            // Displays the properties of the Array.
            Console.WriteLine("The Array has {0} dimension(s) and a total of {1} elements.", myArr.Rank, myArr.Length);
            Console.WriteLine("\tLength\tLower\tUpper");

            for (int dimension = 0; dimension < myArr.Rank; dimension++)
            {
                Console.Write("{0}:\t{1}", dimension, myArr.GetLength(dimension));
                Console.WriteLine("\t{0}\t{1}", myArr.GetLowerBound(dimension), myArr.GetUpperBound(dimension));

                //배열의 인덱스
                //myArr.GetLength(dimension);
                //배열에서 지정된 차원의 첫 번째 요소의 인덱스를 가져옵니다.
                //myArr.GetLowerBound(dimension);
                //배열에서 지정된 차원의 마지막 요소의 인덱스를 가져옵니다.
                //myArr.GetUpperBound(dimension);
            }

            // Displays the contents of the Array.
            Console.WriteLine("The Array contains the following values:");
            PrintValues(myArr);

            void PrintValues(Array myArray)
            {
                System.Collections.IEnumerator myEnumerator = myArray.GetEnumerator();
                int i = 0;
                int cols = myArray.GetLength(myArray.Rank - 1);
                while (myEnumerator.MoveNext())
                {
                    if (i < cols)
                    {
                        i++;
                    }
                    else
                    {
                        Console.WriteLine();
                        i = 1;
                    }
                    //Console.Write("\t{0}", String.Format("{0:000}",myEnumerator.Current));
                    Console.Write("\t{0:000}", myEnumerator.Current);
                }
                Console.WriteLine();
            }
            #endregion

            long t = 12345;
            Array.Sort(t.ToString().ToArray());
            t.ToString().AsEnumerable().Reverse();
            var temp = from num in t.ToString() select Convert.ToInt16(t.ToString());

            char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', };
            chars.Reverse();
            ints.Max(); // 최대값
            ints.Sum(); // 모든합
            ints.Average(); // 평균
            ints.Reverse(); // 뒤집기
            ints.Except(new int[] { 1, 2, 3 }).ToArray();
            ints.OrderBy(x => x).Take(5).ToArray(); //오름차순
            ints.OrderBy(x => -x).Take(5).ToArray(); //내림차순

            Array.IndexOf(ints, ints.Max()); // Array의 인덱스 찾기

            char[] tt = "123".ToCharArray();
            Array.IndexOf(tt, '1'); // 0
            Array.IndexOf(tt, "1"); // -1
            Array.IndexOf(tt, 1); // -1
            Array.IndexOf(tt, Convert.ToChar(1)); // -1
            Array.IndexOf(tt, Convert.ToChar(1.ToString())); // 0
            Array.LastIndexOf(tt, "1");

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

            int[] arr1 = { 1, 2, 3, 4 };
            int[] arr2 = { 5, 6, 7 };
            int[] arr3 = arr1.Concat(arr2).ToArray(); //{ 1, 2, 3, 4, 5, 6, 7 };
            int[] arr4 = arr1.Skip(2).ToArray(); //{ 3, 4 };

            Array.Resize(ref arr1, arr1.Length + arr2.Length);
            Array.Copy(arr2, 0, arr1, arr1.Length - arr2.Length, arr2.Length); //{ 1, 2, 3, 4, 5, 6, 7 };
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

            ints.CopyTo(ints2, 2); // { 8, 5, 2, 4, 6, 3, 1, 7 }
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
            Array.Reverse(charArray);

            answer = Array.ConvertAll(charArray, c => (int)char.GetNumericValue(c));

            return answer;
        }

        //int[]에 x 포함 갯수 찾기
        public int solution(int[] array)
        {
            int answer = string.Join("", array).Count(x => x == '7');
            return answer;
        }

        public int[] solution(int[] num_list, int n)
        {
            return num_list.Skip(n - 1).ToArray();
        }
    }
}
