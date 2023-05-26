using DocumentFormat.OpenXml.Drawing.Diagrams;

namespace ConsoleAppSample.Study
{
    internal class Operation
    {
        Operation()
        {
            // 산술 연산자 + - * / , % (modulo)
            double 섭씨 = 12;
            double 화씨 = (섭씨 * 9 / 5) + 32; // 53.6

            int i = 100 % 3; //1

            // 할당 연산자
            int a = 100;
            a = a + 50;
            a += 50;
            a *= 50;

            // 증감 연산자 ++, --
            int x = 0;
            x++; // x = x + 1; 
            ++x;
            x--; --x;

            x = 0;
            int y = x++; // 1
            x = 0;
            int z = ++x; // 0

            // 비교 연산자 >, >=, <. <=, ==
            int index = 100;
            if (index >= 100) { }

            // 논리 연산자 && || !
            if (index > 1 && index < 1000)
            {
                index++;
            }

            x = 0;
            y = 1;
            if (++x > 0 || ++y > 1)
            {
                // ...
            }
            Console.WriteLine(x + y);

            // 비트연산자
            x = 0x07; // 0000 0111 (7)
            y = 0x0D; // 0000 1101 (13)
            x = Convert.ToInt32("00000111", 2);
            y = Convert.ToInt32("00001101", 2);

            //null 확인
            string st = "";
            
            if (st is null)
                st = "is null";

            if (st is not null)
                st = "is not null";
        }
    }
}
