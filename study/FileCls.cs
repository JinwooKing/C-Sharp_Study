using System;
using System.IO;

namespace ConsoleAppSample.Study
{
    class FileCls
    {
        /// <summary>
        /// 목적지에 중복된 파일 있는지 검사 후 파일 이동
        /// </summary>
        public static void FileMove(string sourceFileName, string destFileName)
        {
            int i = 0;
            if (File.Exists(destFileName))
            {
                while (File.Exists(destFileName + $" ({++i})")) ;
                destFileName = destFileName + $" ({i})";
            }

            //이동
            File.Move(sourceFileName, destFileName);
        }

    }
}
