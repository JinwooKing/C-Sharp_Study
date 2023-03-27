using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Web.Http;

namespace ConsoleAppSample.Study.Cls.Package
{
	public class DapperCls
	{
		/// <summary>
		/// 데이터베이스 : AdventureWorksLT2019 
		/// 테이블반환 함수 : ufnGetCustomerInformation
		/// </summary>
		[HttpGet]
		[Route("api/CustomerInformation")]
		public Customer Get([FromUri] CustomerInformationParameter _param)
		{
			Customer rtnVal = new Customer();

			string CONNECTIONSTRING = "ConfigEx.CONNECTIONSTRING";

			using (var conn = new SqlConnection(CONNECTIONSTRING))
			{
				string sql = $@"SELECT * FROM [dbo].[ufnGetCustomerInformation] (@CustomerID)";

				var p = new DynamicParameters();

				p.Add("@CustomerID", _param.customerID);

				rtnVal = conn.Query<Customer>(sql, p, commandType: CommandType.Text).FirstOrDefault();
			}

			return rtnVal;
		}
		
		/// <summary>
		/// 데이터베이스 : AdventureWorks2014
		/// 저장프로시저 : uspGetBillOfMaterials
		/// </summary>
		[HttpGet]
		[Route("api/EmployeeManagers")]
		public EmployeeManager Get([FromUri] EmployeeManagersParameter _param)
		{
			EmployeeManager rtnVal = new EmployeeManager();

			string CONNECTIONSTRING = "ConfigEx.CONNECTIONSTRING";

			using (var conn = new SqlConnection(CONNECTIONSTRING))
			{
				string sql = $@"uspGetEmployeeManagers";

				var p = new DynamicParameters();

				p.Add("@BusinessEntityID", _param.businessEntityID);

				rtnVal = conn.Query<EmployeeManager>(sql, p, commandType: CommandType.StoredProcedure).FirstOrDefault();
			}

			return rtnVal;
		}

		#region Model
		public class CustomerInformationParameter
		{
			public string customerID { get; set; }
		}

		public class Customer
		{
			public string? CustomerID { get; set; }
			public string? FirstName { get; set; }
			public string? LastName { get; set; }
		}

		public class EmployeeManagersParameter
		{
			public string? businessEntityID { get; set; }
		}

		public class EmployeeManager
		{
			public string? recursionLevel { get; set; }
			public string? businessEntityID { get; set; }
			public string? firstName { get; set; }
			public string? lastName { get; set; }
			public string organizationNode { get; set; }
			public string? managerFirstName { get; set; }
			public string? managerLastName { get; set; }
		}
		#endregion
	}
}
