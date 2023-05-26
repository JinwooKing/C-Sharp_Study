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
        /// Base64로 인코딩된 문자열을 UTF8 문자열로 디코딩합니다.
        /// </summary>
        /// <param name="base64EncodedString">Base64로 인코딩된 문자열</param>
        /// <returns>디코딩된 UTF8 문자열</returns>
        public static string DecodeBase64ToUTF8(string base64EncodedString)
        {
			try
			{
                return Encoding.UTF8.GetString(Convert.FromBase64String(base64EncodedString));
            }
            catch (Exception)
			{
				return base64EncodedString;
			}
		}
	}
}
