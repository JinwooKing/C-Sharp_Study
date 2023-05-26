using ClosedXML.Excel;

namespace ConsoleAppSample.Study.Cls.Package
{
	public class ClosedXMLCls
	{
		/// <summary>
		/// Excel 파일 생성
		/// </summary>
		void DownloadExcel()
		{
			// 엑셀 파일 열기
			using (var workbook = new XLWorkbook())
			{
				#region 정보
				// 셀 가져오기
				//var cell = worksheet.Cell("A1");
				// 셀 값 변경하기
				//cell.Value = "새로운 값";
				#endregion

				// 첫 번째 시트 선택
				var worksheet = workbook.Worksheets.Add("Sheet1");

				// Header 셀 가져오기
				var HeaderCellA1 = worksheet.Cell("A1");
				var HeaderCellB1 = worksheet.Cell("B1");

				// Header 셀 값 변경하기
				HeaderCellA1.Value = "이름";
				HeaderCellB1.Value = "전화번호";

				// Header Style
				worksheet.Range(HeaderCellA1, HeaderCellB1).Style.Fill.BackgroundColor = XLColor.FromArgb(128, 128, 128);
				worksheet.Range(HeaderCellA1, HeaderCellB1).Style.Font.FontColor = XLColor.White;
				worksheet.Range(HeaderCellA1, HeaderCellB1).Style.Font.Bold = true;
				// Header end

				// Data 편집
				int rowIdx = 2;

				#region SampleData
				var sampleData = new[]
				{
					 new { Name ="박진우", Phone = "010-7133-2619" },
					 new { Name ="홍길동", Phone = "01071332619" },
					 new { Name ="김철수", Phone = "+01071332619" },
				};
				#endregion

				foreach (var sample in sampleData)
				{
					worksheet.Cell(rowIdx, "A").Value = sample.Name;
					//worksheet.Cell(rowIdx, "B").Style.NumberFormat.Format = "@"; //표시 형식 '텍스트'로 변경
					worksheet.Cell(rowIdx, "B").SetValue(sample.Phone);

                    rowIdx++;
				}
				
				// 서식세팅
				worksheet.Columns("A", "B").AdjustToContents(); // 컨텐츠 크기에 width 맞추기
				worksheet.Rows().Height = 14;
				worksheet.Style.Font.FontName = "Arial";
				worksheet.Row(1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);


				// 변경 사항 저장하기
				string filePath = $@"D:\test.xlsx";
				FileInfo file = new FileInfo(filePath);
				workbook.SaveAs(file.FullName);

				// 스트림에 담아서 응답 (웹 / returnType / ActionResult)
				// var stream = new MemoryStream();
				// workbook.SaveAs(stream);
				// stream.Position = 0;
				// HttpContext.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
				// Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
				// return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
			}
		}
	}
}
