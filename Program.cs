using ConsoleAppSample.Study.Cls;
using System.Diagnostics;

StopwatchCls.Time(StopwatchCls.ActcionDelay);
StopwatchCls.Time(StopwatchCls.FunctionDelay);

Console.ReadKey();

//solution();
//int solution()
//{
//    int[,] dots = { { 1, 4 }, { 9, 2 }, { 3, 8 }, { 11, 6 } };
//        
//    int[] dot1 = { dots[0, 0], dots[0, 1] };
//    int[] dot2 = { dots[1, 0], dots[1, 1] };
//    int[] dot3 = { dots[2, 0], dots[2, 1] };
//    int[] dot4 = { dots[3, 0], dots[3, 1] };
//    int answer = 0;
//        
//    return answer;
//}

// 다중처리
/*
// 1. 순차적 실행
// 동일쓰레드가 0~999 출력
//
for (int i = 0; i < 1000; i++)
{
    Console.WriteLine("{0}: {1}",
        Thread.CurrentThread.ManagedThreadId, i);
}
Console.Read();

// 2. 병렬 처리
// 다중쓰레드가 병렬로 출력
//
Parallel.For(0, 1000, (i) => {
    Console.WriteLine("{0}: {1}",
        Thread.CurrentThread.ManagedThreadId, i);
});
*/
