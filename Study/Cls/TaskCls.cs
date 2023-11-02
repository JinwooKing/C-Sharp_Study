using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.Study.Cls
{
	public class TaskCls
	{
		//Task 클래스
		//비동기 작업을 나타냅니다.
        //https://learn.microsoft.com/ko-kr/dotnet/api/system.threading.tasks.task
        TaskCls() 
		{
			Task.Delay(100); // 100밀리초
            Task.Delay(TimeSpan.FromSeconds(1)); // 1초
            Task.Delay(TimeSpan.FromMinutes(1)); // 1분 동안의 지연 작업이 수행

            Task.Run(async () => {
                // Just loop.
                await Task.Delay(1000);
                int ctr = 0;
                for (ctr = 0; ctr <= 1000000; ctr++)
                { }
                Console.WriteLine("Finished {0} loop iterations",
                                  ctr);
            });

            Task.Run(() => {
                // Just loop.
                Task.Delay(1000);
                int ctr = 0;
                for (ctr = 0; ctr <= 1000000; ctr++)
                { }
                Console.WriteLine("Finished {0} loop iterations",
                                  ctr);
            });

            // Wait on a single task with no timeout specified.
            Task taskA = Task.Run(() => Thread.Sleep(2000));
            Console.WriteLine("taskA Status: {0}", taskA.Status);
            try
            {
                taskA.Wait();
                Console.WriteLine("taskA Status: {0}", taskA.Status);
            }
            catch (AggregateException)
            {
                Console.WriteLine("Exception in taskA.");
            }

            // Wait on a single task with a timeout specified.
            Task taskB = Task.Run(() => Thread.Sleep(2000));
            try
            {
                taskB.Wait(1000);       // Wait for 1 second.
                bool completed = taskB.IsCompleted;
                Console.WriteLine("Task B completed: {0}, Status: {1}",
                                 completed, taskB.Status);
                if (!completed)
                    Console.WriteLine("Timed out before task B completed.");
            }
            catch (AggregateException)
            {
                Console.WriteLine("Exception in taskA.");
            }
        }

        public static async Task HelloAsync()
		{
			Console.WriteLine("start");
			await Task.Delay(1000);
            Console.WriteLine("Hello");
            Console.WriteLine("end");
        }
	}
}                                                                  
