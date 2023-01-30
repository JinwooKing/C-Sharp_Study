using System.IO.Compression;

namespace ConsoleAppSample.Study.Cls
{
    public class ZipArchiveCls
    {
        //ZipArchive 클래스
        //zip 보관 파일 형식으로 압축된 파일 패키지를 나타냅니다.
        //https://learn.microsoft.com/ko-kr/dotnet/api/system.io.compression.ziparchive?view=net-7.0

        string whiteList = ".zip|.txt";
        string blackList = ".exe";

        ZipArchiveCls()
        {
            string sourceDirectoryName = @"D:\9999.TEST\release";
            string destinationArchiveFileName = @"D:\9999.TEST\release.zip";
            string destinationDirectoryName = @"D:\9999.TEST\unzip";

            //0. 소스 디렉터리 생성
            if (!Directory.Exists(sourceDirectoryName))
                Directory.CreateDirectory(sourceDirectoryName);

            //1. 소스 디렉터리를 zip 파일로 만들기, 소스 디렉터리 내부 모든 파일 zip 파일에 추가
            if (!File.Exists(destinationArchiveFileName))
                ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName);

            #region File.Create zip 파일 생성 에러
            //File.Create로 zip파일 생성하여 사용 시 오류 발생
            //File.Create(destinationArchiveFileName);
            #endregion

            //2. 기존 zip 보관 파일에 새 파일 추가
            using (ZipArchive archive = ZipFile.Open(@"D:\9999.TEST\release.zip", ZipArchiveMode.Update))
            {
                //내부에 같은 이름의 파일이 있어도 중복생성되어 사용시 주의필요
                ZipArchiveEntry readmeEntry = archive.CreateEntry("Readme.txt");
                using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
                {
                    writer.WriteLine("Information about this package.");
                    writer.WriteLine("========================");
                }

                ZipArchiveEntry readmeEntry2 = archive.CreateEntry("Test.txt");
                using (StreamWriter writer = new StreamWriter(readmeEntry2.Open()))
                {
                    writer.WriteLine("Test.");
                    writer.WriteLine("========================");
                }
            }

            //3. zip 파일의 내용을 디렉터리에 추출	
            using (ZipArchive archive = ZipFile.OpenRead(@"D:\9999.TEST\release.zip"))
            {
                //3-1. zip 파일내의 모든 파일 추출
                //archive.ExtractToDirectory(destinationDirectoryName);

                //3-2. zip 파일내의 일부 파일 추출
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    // .txt인 파일 추출
                    if (!Directory.Exists(destinationDirectoryName))
                        Directory.CreateDirectory(destinationDirectoryName);

                    if (entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                        entry.ExtractToFile(Path.Combine(destinationDirectoryName, entry.Name));
                }
            }
        }

        public bool CheckFileExtension(string archiveFileName)
        {
            using (ZipArchive archive = ZipFile.OpenRead(archiveFileName))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    string fileName = entry.FullName;
                    string fileExt = Path.GetExtension(fileName);

                    var whiteAry = whiteList.Split(new String[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    var blackAry = blackList.Split(new String[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

                    //파일 확장자 .zip이라면 압축해제
                    if (".zip".Equals(fileExt))
                    {
                        #region 파일 확장자 .zip이라면 압축해제
                        string extractPath = @"D:\";

                        extractPath = Path.GetFullPath(extractPath);

                        string destinationPath = Path.GetFullPath(Path.Combine(extractPath, entry.FullName));

                        if (File.Exists(destinationPath))
                            File.Delete(destinationPath);

                        if (destinationPath.StartsWith(extractPath, StringComparison.Ordinal))
                            entry.ExtractToFile(destinationPath);

                        if (!CheckFileExtension(destinationPath))
                        {
                            File.Delete(destinationPath);
                            return false;
                        }
                        else
                        {
                            File.Delete(destinationPath);
                        }
                        #endregion
                    }

                    //폴더는 마지막에 / 문자
                    if (entry.FullName.EndsWith(@"/", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    //파일 확장자 없다면 폴더인지 확인
                    if ("".Equals(fileExt))
                    {
                        #region 파일 확장자 없다면 폴더인지 확인
                        string extractPath = @"D:\";

                        extractPath = Path.GetFullPath(extractPath);

                        string destinationPath = Path.GetFullPath(Path.Combine(extractPath, entry.FullName));

                        if (File.Exists(destinationPath))
                            File.Delete(destinationPath);

                        if (destinationPath.StartsWith(extractPath, StringComparison.Ordinal))
                            entry.ExtractToFile(destinationPath);

                        FileAttributes chkAtt = File.GetAttributes(destinationPath);
                        if ((chkAtt & FileAttributes.Directory) == FileAttributes.Directory)
                        {
                            File.Delete(destinationPath);
                            continue;
                        }
                        else
                        {
                            File.Delete(destinationPath);
                            return false;
                        }

                        #endregion
                    }

                    if (whiteAry.Count(s => s.Equals("*")) == 0 && whiteAry.Count(s => s.Equals(fileExt)) == 0)
                    {
                        return false;
                    }
                    if (blackAry.Count(s => s.Equals("*")) > 0 || blackAry.Count(s => s.Equals(fileExt)) > 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }    
}
