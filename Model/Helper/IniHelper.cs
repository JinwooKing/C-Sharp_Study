using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.Model.Helper
{
    public class IniHelper
    {
        static string currentPath = Directory.GetCurrentDirectory();
        static string filePath = Path.Combine(currentPath, "info.ini");

        static StringBuilder SERVER = new StringBuilder();
        static StringBuilder DATABASE = new StringBuilder();
        static StringBuilder UID = new StringBuilder();
        static StringBuilder PWD = new StringBuilder();


        public IniHelper()
        { // GetPrivateProfileString("카테고리", "Key값", "기본값", "저장할 변수", "불러올 경로");
            if(!File.Exists(filePath))
                File.Create(filePath);
            WritePrivateProfileString("SQL", "server", "", filePath);
            WritePrivateProfileString("SQL", "database", "", filePath);
            WritePrivateProfileString("SQL", "uid", "", filePath);
            WritePrivateProfileString("SQL", "pwd", "", filePath);

            GetPrivateProfileString("SQL", "server", "", SERVER, 32, filePath);
            GetPrivateProfileString("SQL", "database", "", DATABASE, 32, filePath);
            GetPrivateProfileString("SQL", "uid", "", UID, 32, filePath);
            GetPrivateProfileString("SQL", "pwd", "", PWD, 32, filePath);

            Console.WriteLine($"SERVER : {SERVER.ToString()}");
            Console.WriteLine($"DATABASE : {DATABASE.ToString()}");
            Console.WriteLine($"UID : {UID.ToString()}");
            Console.WriteLine($"PWD : {PWD.ToString()}");
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
    }
}
