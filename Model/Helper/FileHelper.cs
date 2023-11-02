using ConsoleAppSample.Utilities;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ConsoleAppSample.Model.Helper
{
    public class FileHelper
    {
        //File 클래스
        //단일 파일에 대한 만들기, 복사, 삭제, 이동 및 열기를 위한 정적 메서드를 제공하고 FileStream 개체 만들기를 지원합니다.
        //https://learn.microsoft.com/ko-kr/dotnet/api/system.io.file

        /// <summary>
        /// 목적지에 중복된 파일이 있는지 검사한 후, 고유한 파일명으로 파일을 이동합니다.
        /// </summary>
        /// <param name="sourceFileName">원본 파일 경로</param>
        /// <param name="destFileName">목적지 파일 경로</param>
        public static void FileMove(string sourceFileName, string destFileName)
        {
            if (File.Exists(destFileName))
                destFileName = GetUniqueFileName(destFileName);

            //이동
            File.Move(sourceFileName, destFileName);
        }

        /// <summary>
        /// 파일 경로를 받아, 고유한 파일명을 생성하여 반환합니다.
        /// 이미 존재하는 파일명인 경우, 숫자를 접미사로 추가하여 고유성을 확보합니다.
        /// </summary>
        /// <param name="path">파일 경로</param>
        /// <returns>고유한 파일명</returns>
        public static string GetUniqueFileName(string path)
        {
            if (File.Exists(path))
            {
                string directoryName = Path.GetDirectoryName(path);
                string fileNameWithoutExtension = Path.Combine(directoryName, Path.GetFileNameWithoutExtension(path));
                string extension = Path.GetExtension(path);
                int suffix = 2;
                
                do
                {
                    path = $"{fileNameWithoutExtension} ({suffix++}){extension}";
                } while (File.Exists(path));
            }
            return path;
        }


        /// <summary>
        /// PARCIO 파일생성
        /// </summary>
        /// <param name="dataList"></param>
        public static void WriteFile(List<TagInfo> dataList)
		{
			string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Guid.NewGuid().ToString("N") + ".txt";
            //매우빠른속도로 파일이 생성 상황에서 파일이름의 중복을 방지하기 위해 Guid.NewGuid().ToString("N") 추가
            string rootDir = Path.Combine(Consts.FILE_ROOT_PATH, fileName);
			string tempDir = Path.Combine(Consts.FILE_TEMP_PATH, fileName);
			try
			{
				// 파일 생성.
				// parcIO는 해당 폴더에 파일 생성시 바로 읽기 때문에 문제가 될 여지가 있어서 
				// temp 폴더에 생성후 복사 방식으로 처리. 
				using (StreamWriter writer = File.CreateText(tempDir))
				{
					string tagStr = string.Empty;

					//마지막 반복문
					int lastIndex = dataList.Count - 1;

					for (int i = 0; i < dataList.Count; i++)
					{
						TagInfo tag = dataList[i];
						tagStr = string.Format("{0},{1},{2},{3}", tag.tagName, tag.tagTime, tag.tagValue, 192);
						if (i == lastIndex)
							writer.Write(tagStr);
						else
							writer.WriteLine(tagStr);
					}
				}

				// 생성한 파일을 이동.
				File.Move(tempDir, rootDir);
				//File.Copy(tempDir, rootDir);
			}
			catch (Exception e)
			{
				NlogHelper.Log(e.ToString(), LogType.Error);
			}
		}

        public static void UpdateDateTime()
        {
            var di = new DirectoryInfo(@$"C:\Users\jinwo\Desktop\CAS_GatherDatas_Output\Output");
            var dirs = di.GetDirectories();
            foreach (var dir in dirs)
            {
                var tagName = string.Join(".", dir.Name.Split(".").Skip(2).ToArray());
                var files = dir.GetFiles();

                foreach (var file in files)
                {

                    var newdir = Path.Combine($@"C:\Users\jinwo\Desktop\CAS_GatherDatas_Output\Output", file.Name.Substring(0, 6));
                    if (!Directory.Exists(newdir))
                        Directory.CreateDirectory(newdir);

                    using (var reader = new StreamReader(file.FullName))
                    using (var writer = new StreamWriter(Path.Combine(newdir, string.Concat(file.Name[6..^4], "tagName.txt"))))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var splitedLine = line.Split(",");
                            var datetimeStr = splitedLine[0];
                            var datetime = new DateTime(int.Parse(datetimeStr[0..4]),
                                int.Parse(datetimeStr[5..7]),
                                int.Parse(datetimeStr[8..10]),
                                int.Parse(datetimeStr[11..13]),
                                int.Parse(datetimeStr[14..16]),
                                int.Parse(datetimeStr[17..19]));
                            writer.WriteLine(string.Concat(tagName, ",", datetime.AddMonths(2).AddDays(1).ToString("G"), ",", splitedLine[1]));
                        }
                    }

                    //file.Delete();
                }
            }
        }

		public class TagInfo
		{
			public string tagName { get; set; }

			//public DateTime tagTime { get; set; }
			public string tagTime { get; set; }
			public string tagValue { get; set; }
			public string tagQuality { get; set; }
		}
	}
}
