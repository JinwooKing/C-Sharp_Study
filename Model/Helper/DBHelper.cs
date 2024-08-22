using Dapper;
using Oracle.ManagedDataAccess.Client;
using Microsoft.Data.SqlClient;

namespace ConsoleAppSample.Model.Helper
{
    public class DBHelper
    {
        public DBHelper()
        {
            OracleConnectionTest();
            SqlServerConnectionTest();

            #region LocalDB 접속 
            string connectionString = $@"Server=(localdb)\mssqllocaldb;Database=aspnet-AlarmEvent-94b1bc1f-2098-47d8-9acf-efacf00135f3;Trusted_Connection=True;MultipleActiveResultSets=true;";
            var conn = new SqlConnection(connectionString);
            conn.Open();

            string? version = conn.Query<string>("SELECT @@VERSION").FirstOrDefault();
            Console.WriteLine(version);
            #endregion
        }

        private static string SERVER = "000.000.000.000";
		private static string UID = "sa";
		private static string PWD = "000000";
		private static string DATABASE = "AdventureWorksLT2019";

		private static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder
		{
			DataSource = SERVER,
			UserID = UID,
			Password = PWD,
			InitialCatalog = DATABASE,
			Encrypt = true,
			TrustServerCertificate = true,
			ColumnEncryptionSetting = SqlConnectionColumnEncryptionSetting.Enabled
		};

		/// <summary>
		///  SqlConnection 객체를 반환
		/// </summary>
		/// <returns></returns>
		public static string GetConnectionString()
		{
			return sqlConnectionStringBuilder.ConnectionString;
		}

		/// <summary>
		/// SQL Server 데이터베이스
		/// </summary>
		public static void SqlServerConnectionTest()
        {
            //0. 접속정보
            string SERVER = "000.000.000.000";
            string UID = "<로그인>";
            string PWD = "<암호>";
            string DATABASE = "<데이터베이스 명>";

            //1. SqlConnectionStringBuilder 사용
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
				DataSource = SERVER,
				UserID = UID,
				Password = PWD,
				InitialCatalog = DATABASE,
				Encrypt = true,
				TrustServerCertificate = true,
				ColumnEncryptionSetting = SqlConnectionColumnEncryptionSetting.Enabled
			};

            //1-2. ConnectionString 사용
            //string ConnectionString = $"Data Source={SERVER};Initial Catalog={DATABASE};User ID={UID};Password={PWD}";
            //string ConnectionString = $"server={SERVER};database={DATABASE};uid={UID};pwd={PWD}";

            //2. 데이터베이스 연결 및 버전 조회
            using (SqlConnection conn = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                string sql = "SELECT @@VERSION";

                conn.Open();

                string rtnVal = conn.Query<string>(sql).First();
                Console.Write(rtnVal);
            }
        }

        /// <summary>
        /// Oracle 데이터베이스
        /// </summary>
        public static void OracleConnectionTest()
        {
            string ConnectionString = $@"Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = {SERVER})(PORT = {1521}))) 
                                                        (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe))); User Id={UID};Password={PWD};";
            //"Data Source={DataSource};User Id={UserId};Password={Password};";

            OracleConnection conn = new OracleConnection(ConnectionString);
            conn.Open();
            //OracleCommand cmd = new OracleCommand();
            //cmd.Connection = conn;
            //
            //cmd.CommandText = "SELECT SYSDATE FROM DUAL";
            //OracleDataReader reader = cmd.ExecuteReader();
            //if (reader.Read())
            //{
            //    Console.WriteLine(reader[0]);
            //}
        }
    }
}
