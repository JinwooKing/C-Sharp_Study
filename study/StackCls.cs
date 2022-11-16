using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.Study
{
    public class StackCls
    {
        //Stack<T> 클래스
        //지정한 동일 형식의 인스턴스로 이루어진 가변 크기 LIFO(후입선출) 방식의 컬렉션을 나타냅니다.
        //https://learn.microsoft.com/ko-kr/dotnet/api/system.collections.generic.stack-1

        public StackCls()
        {
            ///생성자///
            //비어 있는 상태에서 기본 초기 용량을 가지는 Stack<T> 클래스의 새 인스턴스를 초기화합니다.
            Stack<int> stack = new Stack<int>();

            //지정된 컬렉션에서 복사한 요소를 포함하고 복사한 요소를 모두 수용할 수 있을 정도의 용량을 가진 Stack<T> 클래스의 새 인스턴스를 초기화합니다.
            Stack<int> stack2 = new Stack<int>(new int[] { 1, 2, 3, 4, 5 });

            //비어 있는 상태이고 지정한 초기 용량과 기본 초기 용량 중에서 더 큰 용량을 가지는 Stack<T> 클래스의 새 인스턴스를 초기화합니다.
            Stack<int> stack3 = new Stack<int>(5);

            ///속성///
            //Stack<T>에 포함된 요소 수를 가져옵니다.
            int count = stack.Count;


            ///메서드///
            //Stack<T>에서 개체를 모두 제거합니다.
            stack.Clear();

            //Stack<T>에 요소가 있는지 여부를 확인합니다.
            bool isContain = stack.Contains(1);

            //지정된 배열 인덱스에서 시작하는 기존 1차원 Array에 Stack<T>를 복사합니다.
            int[] nums = new int[stack2.Count];
            stack2.CopyTo(nums, 0); // { 5, 4, 3, 2, 1 }

            //Stack<T>을 새 배열에 복사합니다.
            int[] nums2 = stack2.ToArray();

            //지정된 개체가 현재 개체와 같은지 확인합니다.
            stack.Equals(stack);

            //Stack<T>에 대한 열거자를 반환합니다.
            stack2.GetEnumerator();

            //개체를 Stack<T>의 맨 위에 삽입합니다.
            stack.Push(1);

            //Stack<T>의 맨 위에서 개체를 제거하고 반환합니다.
            stack.Pop();

            //Stack<T>의 맨 위에 개체가 있는지 여부를 나타내는 값을 반환하고, 개체가 있는 경우 이를 result 매개 변수에 복사하고 Stack<T>에서 제거합니다.
            stack.TryPop(out int num);

            //Stack<T>의 맨 위에서 개체를 제거하지 않고 반환합니다.
            stack.Peek();

            //Stack<T>의 맨 위에 개체가 있는지 여부를 나타내는 값을 반환하고, 개체가 있는 경우 이를 result 매개 변수에 복사합니다. Stack<T>에서는 개체가 제거되지 않습니다.
            stack.TryPeek(out int num2);

        }
        //Stack 예제
        public void StackClsExample()
        {
            //Stack 초기화
            Stack<string> numbers = new Stack<string>();
            numbers.Push("one");
            numbers.Push("two");
            numbers.Push("three");
            numbers.Push("four");
            numbers.Push("five");

            // 스택 열거
            foreach (string number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nPopping '{0}'", numbers.Pop());
            Console.WriteLine("Peek at next item to destack: {0}", numbers.Peek());
            Console.WriteLine("Popping '{0}'", numbers.Pop());

            // ToArray 메서드를 사용하여 스택의 복사본을 만들고 IEnumerable<T>를 허용하는 생성자.
            Stack<string> stack2 = new Stack<string>(numbers.ToArray());

            Console.WriteLine("\nContents of the first copy:");
            foreach (string number in stack2)
            {
                Console.WriteLine(number);
            }

            // 스택 크기의 두 배인 배열을 만들고 복사합니다.
            // 스택의 중간에서 시작하는 요소
            // 배열.
            string[] array2 = new string[numbers.Count * 2]; //{ string[10]}
            numbers.CopyTo(array2, numbers.Count); // { null, null, null, "three", "two", "one" }

            // 다음 생성자를 사용하여 두 번째 스택을 만듭니다.
            Stack<string> stack3 = new Stack<string>(array2); // { "one", "two", "three", null, null, null }

            Console.WriteLine("\nContents of the second copy, with duplicates and nulls:");
            foreach (string number in stack3)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nstack2.Contains(\"four\") = {0}", stack2.Contains("four"));

            Console.WriteLine("\nstack2.Clear()");
            stack2.Clear();
            Console.WriteLine("\nstack2.Count = {0}", stack2.Count);

            /*
            five
            four
            three
            two
            one
            
            Popping 'five'
            Peek at next item to destack: four
            Popping 'four'
            
            Contents of the first copy:
            one
            two
            three
            
            Contents of the second copy, with duplicates and nulls:
            one
            two
            three
            
            
            
            
            stack2.Contains("four") = False
            
            stack2.Clear()
            
            stack2.Count = 0
             */
        }

      

        

    }
}
