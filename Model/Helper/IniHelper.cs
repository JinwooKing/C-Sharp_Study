using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleAppSample.Model.Helper
{
    public class IniHelper
    {
        //private static string currentPath = Directory.GetCurrentDirectory();
        private static string currentPath = AppDomain.CurrentDomain.BaseDirectory;
        private static string filePath = Path.Combine(currentPath, "ConfigEx.ini");

        public static StringBuilder SERVER = new StringBuilder();
        public static StringBuilder DATABASE = new StringBuilder();
        public static StringBuilder UID = new StringBuilder();
        public static StringBuilder PWD = new StringBuilder();


        static IniHelper()
        { // GetPrivateProfileString("카테고리", "Key값", "기본값", "저장할 변수", "불러올 경로");
            if (!File.Exists(filePath))
                File.Create(filePath);
            WritePrivateProfileString("SQL", "server", "1", filePath);
            WritePrivateProfileString("SQL", "database", "2", filePath);
            WritePrivateProfileString("SQL", "uid", "3", filePath);
            WritePrivateProfileString("SQL", "pwd", "4", filePath);

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

        /// <summary>
        /// ConfigEx.ini에서 section, key 값에 대한 정보를 가져옵니다.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetPrivateProfileString(string section, string key)
        {
            StringBuilder temp = new StringBuilder(32);
            GetPrivateProfileString(section, key, "", temp, 32, filePath);
            return temp.ToString();
        }
    }
}
