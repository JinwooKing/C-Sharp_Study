namespace ConsoleAppSample.Model.Helper
{
    public class FileHelper
    {
        //File 클래스
        //단일 파일에 대한 만들기, 복사, 삭제, 이동 및 열기를 위한 정적 메서드를 제공하고 FileStream 개체 만들기를 지원합니다.
        //https://learn.microsoft.com/ko-kr/dotnet/api/system.io.file

        /// <summary>
        /// 목적지에 중복된 파일 있는지 검사 후 파일 이동
        /// </summary>
        /// <param name="sourceFileName"></param>
        /// <param name="destFileName"></param>
        public static void FileMove(string sourceFileName, string destFileName)
        {
            if (File.Exists(destFileName))
                destFileName = GetUniqFileName(destFileName);

            //이동
            File.Move(sourceFileName, destFileName);
        }

        /// <summary>
        /// 고유한 파일 이름
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetUniqFileName(string path)
        {
            int i = 1;

            if (File.Exists(path))
            {
                FileInfo fi = new FileInfo(path);
                string FileNameWithoutExtension = Path.Combine(fi.DirectoryName, Path.GetFileNameWithoutExtension(path));

                do
                {
                    path = string.Concat(FileNameWithoutExtension, $" ({i++})", fi.Extension);
                } while (File.Exists(path));
            }
            return path;
        }
    }
}
