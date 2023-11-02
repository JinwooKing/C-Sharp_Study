using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.Study.Cls
{
     public class EnumCls
    {
        enum Days { Saturday, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday };
        enum BoilingPoints { Celsius = 100, Fahrenheit = 212 };
        [Flags]
        enum Colors { Red = 1, Green = 2, Blue = 4, Yellow = 8 };

        //Enum 클래스
        //열거형에 대한 기본 클래스를 제공합니다.
        //https://learn.microsoft.com/ko-kr/dotnet/api/system.enum

        EnumCls()
        {

            Type weekdays = typeof(Days);
            Days monday = Days.Monday;
            Days Tuesday = (Days) 3;
            Days Wednesday = (Days) Enum.Parse(typeof(Days), "Wednesday");

            Console.WriteLine("The days of the week, and their corresponding values in the Days Enum are:");

            foreach (string s in Enum.GetNames(weekdays))
                Console.WriteLine("{0,-11}= {1}", s, Enum.Format(weekdays, Enum.Parse(weekdays, s), "d"));

            Type boiling = typeof(BoilingPoints);

            Console.WriteLine();
            Console.WriteLine("Enums can also be created which have values that represent some meaningful amount.");
            Console.WriteLine("The BoilingPoints Enum defines the following items, and corresponding values:");

            foreach (string s in Enum.GetNames(boiling))
                Console.WriteLine("{0,-11}= {1}", s, Enum.Format(boiling, Enum.Parse(boiling, s), "d"));

            Colors myColors = Colors.Red | Colors.Blue | Colors.Yellow;
            //Colors myColors = (Colors) 13;
            Console.WriteLine();
            Console.WriteLine("myColors holds a combination of colors. Namely: {0}", myColors);
        }
    }
}