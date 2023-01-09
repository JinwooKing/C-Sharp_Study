namespace ConsoleAppSample.Study.Cls
{
    internal class PreprocessorDirectivesCls
    {
        public PreprocessorDirectivesCls()
        {
        //C# 전처리기 지시문
        //컴파일러에는 별도의 전처리기가 없지만, 이 단원에 설명된 지시문은 전처리기가 있는 것처럼 처리됩니다.
        //조건부 컴파일에서 지시문을 유용하게 사용할 수 있습니다. C 및 C++ 지시문과 달리, 매크로를 만드는 데는 해당 지시문을 사용할 수 없습니다.
        //전처리기 지시문은 한 줄에서 유일한 명령이어야 합니다.
        https://learn.microsoft.com/ko-kr/dotnet/csharp/language-reference/preprocessor-directives

            //#define DEBUG

            //조건부 컴파일
#if DEBUG
            Console.WriteLine("Debug build");
#elif RELEASE
                Console.WriteLine("RELEASE build");
#elif JINWOO
                Console.WriteLine("JINWOO");
#endif
        }
    }
}
