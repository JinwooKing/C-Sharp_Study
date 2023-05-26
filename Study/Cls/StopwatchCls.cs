using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.Study.Cls
{
    public class StopwatchCls
    {
        public static void Time(Action action)
        {
            var st = Stopwatch.StartNew();
            action();
            Console.WriteLine($"{action.Method.ToString()}: {st.Elapsed}" );
        }

        public static void Time(Func<int> function)
        {
            var st = Stopwatch.StartNew();
            function();
            Console.WriteLine($"{function.Method.ToString()}: {st.Elapsed}");
        }

        public static void ActcionDelay()
        {
            var randomNum = new Random().Next(1000, 3000);

            Console.WriteLine($"Delay: {randomNum}");
            Task.Delay(randomNum).Wait();
        }

        public static int FunctionDelay()
        {
            var randomNum = new Random().Next(1000, 3000);
                
            Console.WriteLine($"Delay: {randomNum}");
            Task.Delay(randomNum).Wait();
            return randomNum;
        }

    }
}
