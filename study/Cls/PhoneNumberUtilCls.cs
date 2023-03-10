using PhoneNumbers;

namespace ConsoleAppSample.Study.Cls
{
	public class PhoneNumberUtilCls
	{
		//PhoneNumberUtil 클래스
		//https://github.com/erezak/libphonenumber-csharp/blob/master/csharp/PhoneNumbers/PhoneNumberUtil.cs

		/// <summary>
		/// 전화번호 국가별 정규화
		/// </summary>
		/// <param name="number"></param>
		/// <param name="country"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		string PhoneNumberNormalization(string number, string country)
	{
		//1. PhoneNumberUtil 클래스의 인스턴스를 가져옴
		PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();

		//2. PL 국가번호를 가진 전화번호를 파싱하여 PhoneNumber 객체에 할당
		PhoneNumber phoneNumber = phoneUtil.Parse(number, country);

		//3. phoneNumber가 유효한 전화번호인지 검증하고, 유효하지 않으면 예외 발생
		bool isVaildNumber = phoneUtil.IsValidNumber(phoneNumber);
		if (!isVaildNumber)
			throw new Exception();

		//4. PhoneNumber 객체를 국제전화번호 형식으로 변환하고, 공백을 대시(-)로 변경하여 RECP_Phone 변수에 할당
		string normalizedPhoneNumber = phoneUtil.Format(phoneNumber, PhoneNumberFormat.INTERNATIONAL).Replace(" ", "-");

		//5. 결과를 콘솔에 출력
		Console.WriteLine($"{country} : {normalizedPhoneNumber}");
		return normalizedPhoneNumber;
	}
}
}
