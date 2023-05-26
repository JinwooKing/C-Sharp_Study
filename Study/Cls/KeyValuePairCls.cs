using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.Study.Cls
{
    internal class KeyValuePairCls
    {
        public KeyValuePairCls() {
            var kvp = new KeyValuePair<string, Action>[] {
            new KeyValuePair<string, Action>("TEST1", T1),
            new KeyValuePair<string, Action>("TEST2", T2),
            new KeyValuePair<string, Action>("TEST3", T3),
            };

            Console.WriteLine(kvp[0].Key);
            kvp[0].Value();

            void T1()
            {
                Console.Write("T1");
            }

            void T2()
            {
                Console.Write("T2");
            }

            void T3()
            {
                Console.Write("T3");
            }
        }
    }
}
