using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.Study.Cls
{
    public class TimerCls
    {
        public TimerCls()
        {
            // 5분마다 실행할 작업 설정
            Timer timer1 = new Timer(Work1, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));

            // 10분마다 실행할 작업 설정
            Timer timer2 = new Timer(Work2, null, TimeSpan.Zero, TimeSpan.FromMinutes(10));

            Console.WriteLine("타이머가 설정되었습니다. 종료하려면 엔터를 누르세요.");
            Console.ReadLine();
        }

        private static void Work1(object state)
        {
            Console.WriteLine("5분마다 실행되는 작업: {0}", DateTime.Now);
            // 여기에 5분마다 실행할 작업 코드를 작성하세요.
        }

        private static void Work2(object state)
        {
            Console.WriteLine("10분마다 실행되는 작업: {0}", DateTime.Now);
            // 여기에 10분마다 실행할 작업 코드를 작성하세요.
        }
    }
}
