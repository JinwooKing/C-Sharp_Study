﻿namespace ConsoleAppSample.Model.Helper
{
    public static class Consts
    {
        // 어플리케이션 기본 경로를 가져온다.
        public static string baseDir = AppDomain.CurrentDomain.BaseDirectory;

        // 사용하는 환경에 따라 결과값이 달라진다.
        public static string currDir = Directory.GetCurrentDirectory();
        	
        		//=====   파일 저장 경로   =====
		public static string FILE_ROOT_PATH { get; set; }
		public static string FILE_TEMP_PATH { get; set; }
		public static string PORT { get; set; }

	}
}
