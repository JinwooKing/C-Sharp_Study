using DocumentFormat.OpenXml.Spreadsheet;

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
            int i = 2;

            if (File.Exists(path))
            {
                string directoryName = Path.GetDirectoryName(path);
				string fileNameWithoutExtension = Path.Combine(directoryName, Path.GetFileNameWithoutExtension(path));
				string extension = Path.GetExtension(path);

				do
                {
					path = $"{fileNameWithoutExtension} ({i++}){extension}";
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
			string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".txt";
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
				NlogHelper.LogWrite(e.ToString(), NlogHelper.LogType.Error);
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
