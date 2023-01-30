namespace ConsoleAppSample.Study.Cls
{
    public class DirectoryClass
    {
        //Directory 클래스
        //디렉터리 및 하위 디렉터리를 만들고, 이동하고, 열거하는 정적 메서드를 노출합니다.
        //https://learn.microsoft.com/ko-kr/dotnet/api/system.io.directory

        //DirectoryInfo 클래스
        //디렉터리 및 하위 디렉터리를 만들고, 이동하고, 열거하는 인스턴스 메서드를 노출합니다.
        //https://learn.microsoft.com/ko-kr/dotnet/api/system.io.directoryinfo

        /// <summary>
        /// 현재 디렉토리 경로
        /// </summary>
        public void GetCurrentDirectory()
        {
            string CurrentDirectory = string.Empty;

            //웹 애플리케이션
            //using System.Web;
            //HttpContext.Current.Server.MapPath("/");

            //현재 Directory 경로
            CurrentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine(CurrentDirectory);
        }

        /// <summary>
        /// 일정기간이 지난 파일 삭제
        /// </summary>
        /// <param name="di"></param>
        public void DeleteFile()
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\target");

            try
            {
                //타겟 경로에 파일들이 존재한다면
                if (di.Exists)
                {
                    FileInfo[] files = di.GetFiles();

                    //일주일 된 파일 지우기 날짜 초기화
                    DateTime date = DateTime.Now.AddDays(-7);

                    foreach (FileInfo file in files)
                    {
                        //파일의 마지막 쓰여진 시간과 date 날짜와 비교
                        if (DateTime.Compare(date, file.LastWriteTime) > 0)
                        {
                            //확장자가 .txt인 파일들 지워라
                            if (System.Text.RegularExpressions.Regex.IsMatch(file.Name, ".txt"))
                            {
                                File.Delete(di + "\\" + file.Name);
                                Console.WriteLine($"{file.Name} 파일 삭제 완료");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DelFile] {ex.ToString()}");
            }
        }

        /// <summary>
        /// 폴더에 있는 파일 이동
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destPath"></param>
        public static void FileSync(string sourcePath, string destPath)
        {

            DirectoryInfo sourceDi = new DirectoryInfo(sourcePath);
            DirectoryInfo destDi = new DirectoryInfo(destPath);

            FileInfo[] sourceFiles = sourceDi.GetFiles();

            foreach (FileInfo sourceFile in sourceFiles)
            {
                string sourceFileName = sourceFile.FullName;
                string destFileName = Path.Combine(destPath, sourceFile.Name);

                int i = 0;
                if (File.Exists(destFileName))
                {
                    while (File.Exists(destFileName + $" ({++i})")) ;
                    destFileName = destFileName + $" ({i})";
                }

                File.Copy(sourceFileName, destFileName);
                File.Delete(sourceFileName);
            }
        }
    }
}
