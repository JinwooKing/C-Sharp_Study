﻿// 어플리케이션 기본 경로를 가져온다.
string baseDir = AppDomain.CurrentDomain.BaseDirectory;

// 사용하는 환경에 따라 결과값이 달라진다.
string currDir = Directory.GetCurrentDirectory();

Console.WriteLine(@$"baseDir : {baseDir}");
Console.WriteLine(@$"currDir : {currDir}");

Console.ReadKey();

