﻿using DocumentFormat.OpenXml.Bibliography;

namespace ConsoleAppSample.Study.Cls
{
    public class LinqCls
    {
        public LinqCls()
        {
            //System.Linq 네임스페이스
            //LINQ(Language-Integrated Query)를 사용하는 쿼리를 지원하는 클래스 및 인터페이스를 제공합니다.
            //https://learn.microsoft.com/ko-kr/dotnet/api/system.linq

            int[] ints = Enumerable.Repeat(1, 10).ToArray();
            
            int[] ints2 = Enumerable.Range(1, 10).ToArray();
            int x = 123456789;
            // Method Syntax
     
            var groupedints = ints.GroupBy(i => i % 2);
            // Query Syntax
            //Linq Select
            printArray(from num in ints select num * 2); //2222222222
            printArray(from num in ints2 select num); //12345678910
            printArray(from num in ints2 select num * 2); //2468101214161820

            //Linq Select Distinct
            printArray((from num in ints select num * 2).Distinct()); //2222222222

            //Linq Where
            printArray(from num in ints2 where num % 2 == 0 select num); //246810

            //Linq Order
            printArray(from num in ints2 where num % 2 == 0 orderby num descending select num); //108642



            //그룹, 조인
            //https://learn.microsoft.com/ko-kr/dotnet/csharp/programming-guide/concepts/linq/basic-linq-query-operations

            void printArray(IEnumerable<int> target)
            {
                Console.WriteLine(target);
                foreach (int t in target)
                {
                    Console.Write(t);
                }
                Console.WriteLine();
            }

            int[] num_list = Enumerable.Range(1, 10).ToArray();
            int tt = num_list.Length <= 10 ? num_list.Aggregate((a, b) => a * b) : num_list.Sum();
            num_list.Except(new int[] { 1 }).Sum();

            //temp는 각 자리수의 합
            var temp = x.ToString().ToList().Select(y => int.Parse(y.ToString())).Sum();

            IEnumerable<int> answer = ints.Where((x, i) => (i + 1) % 2 == 0); // 2배수 index만 return
            temp = ints.OrderBy(x => x).OrderBy(x => Math.Abs(x - 5)).ToArray().First(); // 5와 가장 가까운 수
            
            var test = "안녕하세요. 박진우입니다.";
            var result = test.Select(x =>
            {
                if (x == '박')
                    return true;
                else
                    return false;
            });

            //var t = solution( new int[] { 0, 1, 2, 4, 3 }, new bool[] { true } );
            //var nli = Enumerable.Range(1, 100);
            //List<int> t = nli.OrderBy(x => x).ToList(); // 1 2 ... 100
            //List<int> t1 = nli.OrderBy(x => -x).ToList(); // 100 99 ... 1
            //List<int> t2 = nli.OrderBy(x => Math.Abs(x - 10)).ToList(); // 10 9 11 8 12 7 ... 100
        }
    }
}
