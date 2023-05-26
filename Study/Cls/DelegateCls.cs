using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.Study.Cls
{
    internal class DelegateCls
    {
        public DelegateCls() {
            //Action과 Func는 모두 C#에서 사용되는 대리자(delegates)입니다.
            //대리자란 메서드를 참조할 수 있는 참조형 타입으로, 다른 메서드를 호출하고 결과를 반환할 수 있습니다.
            //하지만 Action과 Func의 차이점은 다음과 같습니다:
            //반환 유형(Return Type): Action은 반환 유형이 없는 메서드를 참조하는 대리자입니다.
            //반면, Func는 반환 유형이 있는 메서드를 참조하는 대리자입니다.

            Action<string> printMessage = (message) => Console.WriteLine(message);
            printMessage("Hello, World!");

            Func<int, int, int> addNumbers = (x, y) => x + y;
            int result = addNumbers(3, 5);
            Console.WriteLine(result); // Output: 8

            var kvp = new KeyValuePair<string, Func<int>>[] {
                new KeyValuePair<string, Func<int>>("TEST1", T1),
                new KeyValuePair<string, Func<int>>("TEST1", T1),
            };

            Console.WriteLine(kvp[0].Key);
            kvp[0].Value();
            Console.WriteLine(kvp[1].Key);
            kvp[1].Value();

            var kvp2 = new KeyValuePair<string, Action>[] {
                new KeyValuePair<string, Action>("TEST1", T2),
                new KeyValuePair<string, Action>("TEST2", T2),
            };

            Console.WriteLine(kvp2[0].Key);
            kvp2[0].Value();
            Console.WriteLine(kvp2[1].Key);
            kvp2[1].Value();

            int T1()
            {
                Console.WriteLine("T1");
                Task.Delay(3000).Wait();
                return 0;
            }

            void T2()
            {
                Console.WriteLine("T2");
                Task.Delay(3000).Wait();
            }

            Parallel.For(0, 10, i => {
                Time(T1, nameof(T1));
                Time2(T2, nameof(T2));
            });

            void Time(Func<int> func, string function)
            {
                var stopwatch = Stopwatch.StartNew();
                func();
                Console.WriteLine($"{function}: {stopwatch.Elapsed}");
            }

            void Time2(Action func, string function)
            {
                var stopwatch = Stopwatch.StartNew();
                func();
                Console.WriteLine($"{function}: {stopwatch.Elapsed}");
            }
        }
    }
}
