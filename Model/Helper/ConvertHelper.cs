using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.Model.Helper
{
	public class ConvertHelper
	{
		/// <summary>
		/// Base64로 인코딩된 문자열을 디코딩
		/// </summary>
		/// <param name="base64EncodedString"></param>
		/// <returns></returns>
		public static string FromBase64StringToUTF8String(string base64EncodedString)
		{
			try
			{
				return Encoding.UTF8.GetString(Convert.FromBase64String(base64EncodedString));
			}
			catch (Exception ex)
			{
				return base64EncodedString;
			}
		}
	}
}
