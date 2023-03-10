using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSample.Study.Cls
{
	public class UdpClientCls
	{
		//UdpClient클래스
		//UDP(User Datagram Protocol) 네트워크 서비스를 제공합니다.
		//https://learn.microsoft.com/ko-kr/dotnet/api/system.net.sockets.udpclient

		/// <summary>
		/// UDP 데이터를 송신합니다.
		/// </summary>
		#region UDP 클라이언트
		void CreateUDPClient()
		{
			// 1. UDP 소켓 만들기
			UdpClient udpClient = new UdpClient();

			// 2. 서버에게 데이터 보내기
			string message = "Hello, Server!";
			byte[] data = Encoding.UTF8.GetBytes(message);
			string serverIP = "192.168.0.1"; // 서버 IP 주소
			int serverPort = 12345; // 서버 포트 번호
			IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);
			udpClient.Send(data, data.Length, serverEP);

			// 3. 서버에서 보내온 응답 받아 처리
			byte[] responseData = udpClient.Receive(ref serverEP);
			string responseMsg = Encoding.UTF8.GetString(responseData);
			Console.WriteLine("서버로부터 응답 받음: {0}", responseMsg);

			udpClient.Close();
		}
		#endregion

		/// <summary>
		/// UDP 데이터를 수신합니다.
		/// </summary>
		#region UDP 서버
		void CreateUDPServer()
		{
			// 1. UDP 소켓 만들기
			UdpClient udpServer = new UdpClient(12345); // 포트 12345 사용

			Console.WriteLine("UDP 서버가 시작되었습니다.");

			// 2. UDP 소켓 바인딩 및 수신 대기 시작
			IPEndPoint clientEP = new IPEndPoint(IPAddress.Any, 0);

			while (true)
			{
				byte[] data = udpServer.Receive(ref clientEP); // 데이터 수신 대기

				// 3. 수신된 데이터 처리
				Console.WriteLine("클라이언트 [{0}:{1}]에서 데이터 수신: {2}",
					clientEP.Address.ToString(), clientEP.Port, Encoding.UTF8.GetString(data));

				// 4. 클라이언트에게 응답
				string responseMsg = "Hello, Client!";
				byte[] responseBytes = Encoding.UTF8.GetBytes(responseMsg);
				udpServer.Send(responseBytes, responseBytes.Length, clientEP);
			}
		}
		#endregion
	}
}
