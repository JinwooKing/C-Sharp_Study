using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.study
{
    internal class DirectoryClass
    {
        //Directory 클래스
        //디렉터리 및 하위 디렉터리를 만들고, 이동하고, 열거하는 정적 메서드를 노출합니다.

        //DirectoryInfo 클래스
        //디렉터리 및 하위 디렉터리를 만들고, 이동하고, 열거하는 인스턴스 메서드를 노출합니다.
        public string CurrentDirectory { get; set; }

        public DirectoryClass()
        {
            //현재 Directory 경로
            CurrentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine(CurrentDirectory);
        }

        DirectoryInfo target = new DirectoryInfo(@"C:\target");

        /// <summary>
        /// 폴더에 일정기간이 지난 파일 삭제
        /// </summary>
        /// <param name="di"></param>
        public void DeleteFile(DirectoryInfo di)
        {
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
    }
}
