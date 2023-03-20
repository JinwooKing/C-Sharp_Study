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
// async, await

// yield 문법
/*foreach (int pInt in GetIntArrary())
{
	Console.WriteLine(pInt);
}

foreach (string str in GetStrArrary())
{
	Console.WriteLine($"{str}");
}


IEnumerable<string> GetStrArrary()
{
	string[] strArr = { "TEST1", "TEST2", "TEST3" };
	foreach (string str in strArr)
		yield return str;
}

IEnumerable<int> GetIntArrary()
{
	int[] intArr = { 1, 2, 3 };
	foreach (int tInt in intArr)
		yield return tInt;
}*/

Console.ReadKey();
