using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Domain;

namespace ConnectLib
{
    public class SQLBroke
    {

        private SqlConnection SqlConnection;
        private SqlConnectionStringBuilder SqlConnectionStringBuilder;
        public string DataBase { get; protected set; }
        public SQLBroke(string database)
        {
            this.DataBase = database;
            ConnectTo();
        }
        public void ConnectTo()
        {
            SqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            SqlConnectionStringBuilder.DataSource = "DESKTOP-M4V9RKV";    //資料庫指標
            SqlConnectionStringBuilder.InitialCatalog = DataBase;
            SqlConnectionStringBuilder.IntegratedSecurity = false;
            SqlConnectionStringBuilder.UserID = "Hanpower";
            SqlConnectionStringBuilder.Password = "24722674";
            SqlConnection = new SqlConnection(SqlConnectionStringBuilder.ToString());  //使用指標連接資料庫
        }
        public void Insert(string[] UnitInfo, short[] Location, string TableName)
        {
            SqlConnection _SqlConnection = new SqlConnection(SqlConnectionStringBuilder.ToString());
            try
            {
                string TestComm = string.Format("INSERT INTO dbo.{0}({1}) VALUES({2})", TableName, "機組名稱,額定發電,正式運轉,使用機型,熱源形式,冷源形式,熱交換器,地點X,地點Y", string.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},{8}", UnitInfo[0], UnitInfo[1], UnitInfo[2], UnitInfo[3], UnitInfo[4], UnitInfo[5], UnitInfo[6], Location[0], Location[1]));
                SqlCommand InsertComm = new SqlCommand(TestComm, _SqlConnection);
                if (_SqlConnection.State == ConnectionState.Closed)
                {
                    _SqlConnection.Open();
                }
                InsertComm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return;
            }
            finally
            {
                if (_SqlConnection != null && _SqlConnection.State == ConnectionState.Open)
                    _SqlConnection.Close();
            }
        }
        public void Insert(short[] unitData, string TableName, string[] DataTag, DateTime dateTime)
        {
            string[] TagString = GetStringFromArray(DataTag);
            SqlConnection _SqlConnection = new SqlConnection(SqlConnectionStringBuilder.ToString());
            try
            {
                string TestComm = string.Format("INSERT INTO dbo.{0}({1}) VALUES({2})", TableName, TagString[0], TagString[1]);
                SqlCommand InsertComm = new SqlCommand(TestComm, _SqlConnection);
                for (int a = 1; a < DataTag.Length; a++)
                {
                    string Temp = "@" + DataTag[a];
                    InsertComm.Parameters.AddWithValue(Temp, unitData[a - 1]);
                }
                InsertComm.Parameters.AddWithValue("@時間", dateTime);
                if (_SqlConnection.State == ConnectionState.Closed)
                {
                    _SqlConnection.Open();
                }
                InsertComm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_SqlConnection != null && _SqlConnection.State == ConnectionState.Open)
                    _SqlConnection.Close();
            }
        }
        public void Insert(string TableName, string TripName, DateTime dateTime, string status, int NewTripInput,int NewTripInput2,int NewTripInput3)
        {
            SqlConnection _SqlConnection = new SqlConnection(SqlConnectionStringBuilder.ToString());
            try
            {
                string TestComm = string.Format("INSERT INTO dbo.{0}({1}) VALUES({2})", TableName, "Name,Time,Status,OldTrip,OldTrip2,OldAlarm", string.Format("'{0}','{1}','{2}',{3},{4},{5}",TripName,dateTime.ToString("yyyy-MM-dd HH:mm:ss"),status,NewTripInput,NewTripInput2,NewTripInput3));
                SqlCommand InsertComm = new SqlCommand(TestComm, _SqlConnection);
                if (_SqlConnection.State == ConnectionState.Closed)
                {
                    _SqlConnection.Open();
                }
                InsertComm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_SqlConnection != null && _SqlConnection.State == ConnectionState.Open)
                    _SqlConnection.Close();
            }
        }
        public void Insert(AuthorityManagent authorityManagent, string TableName)
        {
            SqlConnection _SqlConnection = new SqlConnection(SqlConnectionStringBuilder.ToString());
            try
            {
                string TestComm = string.Format("INSERT INTO dbo.{0}({1}) VALUES({2})", TableName, "UserName,Password,Authority", string.Format("'{0}','{1}','{2}'", authorityManagent.UserName, authorityManagent.Password, authorityManagent.Auth));
                SqlCommand InsertComm = new SqlCommand(TestComm, _SqlConnection);
                if (_SqlConnection.State == ConnectionState.Closed)
                {
                    _SqlConnection.Open();
                }
                InsertComm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return;
            }
            finally
            {
                if (_SqlConnection != null && _SqlConnection.State == ConnectionState.Open)
                    _SqlConnection.Close();
            }
        }
        public void Update(string TableName, string TripName, DateTime dateTime, string status, int NewTripInput, int NewTripInput2, int NewAlarmInput)
        {
            SqlConnection _SqlConnection = new SqlConnection(SqlConnectionStringBuilder.ToString());
            try
            {
                string TestComm = string.Format("UPDATE dbo.{0} set Name='{1}',Time='{2}',status='{3}',OldTrip={4} ,OldTrip2 ={5},OldAlarm={6} where Name='{1}' AND status = '發生'", TableName, TripName, dateTime.ToString("yyyy-MM-dd HH:mm:ss"),status,NewTripInput,NewTripInput2,NewAlarmInput);
                SqlCommand InsertComm = new SqlCommand(TestComm, _SqlConnection);
                if (_SqlConnection.State == ConnectionState.Closed)
                {
                    _SqlConnection.Open();
                }
                InsertComm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return;
            }
            finally
            {
                if (_SqlConnection != null && _SqlConnection.State == ConnectionState.Open)
                    _SqlConnection.Close();
            }
        }
        public void Delete(string TableName)
        {
            SqlConnection _SqlConnection = new SqlConnection(SqlConnectionStringBuilder.ToString());
            try
            {
                string TextComm = string.Format("TRUNCATE TABLE dbo.{0}", TableName);
                SqlCommand DeleteComm = new SqlCommand(TextComm, _SqlConnection);
                if (_SqlConnection.State == ConnectionState.Closed)
                {
                    _SqlConnection.Open();
                }
                DeleteComm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return;
            }
            finally
            {
                if (_SqlConnection != null && _SqlConnection.State == ConnectionState.Open)
                    _SqlConnection.Close();
            }
        }
        public void Delete(string TableName, string DataTag, string value)
        {
            SqlConnection _SqlConnection = new SqlConnection(SqlConnectionStringBuilder.ToString());
            try
            {
                string TextComm = string.Format("DELETE FROM dbo.{0} where {1} = '{2}'", TableName, DataTag, value);
                SqlCommand DeleteComm = new SqlCommand(TextComm, _SqlConnection);
                if (_SqlConnection.State == ConnectionState.Closed)
                {
                    _SqlConnection.Open();
                }
                DeleteComm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_SqlConnection != null && _SqlConnection.State == ConnectionState.Open)
                    _SqlConnection.Close();
            }
        }
        public DataTable GetDataSource(string TableName)
        {
            SqlConnection _SqlConnection = new SqlConnection(SqlConnectionStringBuilder.ToString());
            DataTable dataTable = new DataTable();
            try
            {
                string TextComm = string.Format("SELECT * FROM dbo.{0} ", TableName);
                SqlCommand SelectComm = new SqlCommand(TextComm, _SqlConnection);
                if (_SqlConnection.State == ConnectionState.Closed)
                {
                    _SqlConnection.Open();
                }
                SqlDataReader reader = SelectComm.ExecuteReader();
                dataTable.Load(reader);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (_SqlConnection != null && _SqlConnection.State == ConnectionState.Open)
                    _SqlConnection.Close();
            }

            return dataTable;
        }
        public object[] Find(string TableName, string SerachItem)
        {
            List<object> list = new List<object>();
            SqlConnection _SqlConnection = new SqlConnection(SqlConnectionStringBuilder.ToString());
            try
            {
                string TextComm = string.Format("SELECT * FROM dbo.{0}", TableName);
                SqlCommand SelectComm = new SqlCommand(TextComm, _SqlConnection);
                if (SqlConnection.State == ConnectionState.Closed)
                {
                    _SqlConnection.Open();
                }
                SqlDataReader reader = SelectComm.ExecuteReader();
                while (reader.Read())
                {
                    object value = reader[SerachItem];
                    list.Add(value);
                }
                return list.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_SqlConnection != null && _SqlConnection.State == ConnectionState.Open)
                    _SqlConnection.Close();
            }
        }
        public List<List<object>> Search(string StartTime, string DataTag, string SearchName, string TableName)
        {
            SqlConnection _SqlConnection = new SqlConnection(SqlConnectionStringBuilder.ToString());
            List<List<object>> listBuffer = new List<List<object>>();
            List<object> list = new List<object>(); // datatype = int
            List<object> DTList = new List<object>(); // datatype  =datetime
            try
            {
                string TextComm = string.Format("SELECT TOP (1000) [{0}],[{1}] FROM [dbo].[{2}] WHERE {3} >= '{4}'", DataTag, SearchName, TableName, SearchName, StartTime);
                SqlCommand SelectComm = new SqlCommand(TextComm, _SqlConnection);
                if (_SqlConnection.State == ConnectionState.Closed)
                {
                    _SqlConnection.Open();
                }
                SqlDataReader reader = SelectComm.ExecuteReader();

                while (reader.Read())
                {
                    int SH = Convert.ToInt16(reader[DataTag].ToString());
                    DateTime DT = Convert.ToDateTime(reader[SearchName].ToString());
                    list.Insert(0, SH);
                    DTList.Insert(0, DT);
                }
                listBuffer.Add(DTList);
                listBuffer.Add(list);
                return listBuffer;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_SqlConnection != null && _SqlConnection.State == ConnectionState.Open)
                    _SqlConnection.Close();
            }
        }
        public string[] Search(string SearchName, string TableName)
        {
            SqlConnection _SqlConnection = new SqlConnection(SqlConnectionStringBuilder.ToString());
            List<string> TripArray = new List<string>();
            try
            {
                string TextComm = string.Format("SELECT {0} FROM [dbo].[{1}]", SearchName, TableName);
                SqlCommand SelectComm = new SqlCommand(TextComm, _SqlConnection);
                if (SqlConnection.State == ConnectionState.Closed)
                {
                    _SqlConnection.Open();
                }
                SqlDataReader reader = SelectComm.ExecuteReader();
                while (reader.Read())
                {
                    String TripName = reader[SearchName].ToString();
                    TripArray.Insert(0, TripName);
                }
                return TripArray.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_SqlConnection != null && _SqlConnection.State == ConnectionState.Open)
                    _SqlConnection.Close();
            }
        }
        public int TripValueSearch(string SearchName, string TableName)
        {
            int i = 0;
            SqlConnection _SqlConnection = new SqlConnection(SqlConnectionStringBuilder.ToString());
            try
            {
                string TextComm = string.Format("SELECT TOP (1) {0} FROM dbo.{1} ORDER BY Time DESC", SearchName, TableName);
                SqlCommand SelectComm = new SqlCommand(TextComm, _SqlConnection);
                if (_SqlConnection.State == ConnectionState.Closed)
                {
                    _SqlConnection.Open();
                }
                SqlDataReader reader = SelectComm.ExecuteReader();
                while (reader.Read())
                {
                    i = (int)reader[SearchName];
                }
                return i;
            }
            catch (InvalidOperationException)
            {
                return 0;
            }
            finally
            {
                if (_SqlConnection != null && _SqlConnection.State == ConnectionState.Open)
                    _SqlConnection.Close();
            }
        }
        public List<List<object>> LastSearch(string DataTag, string TableName, string SearchName)
        {
            SqlConnection _SqlConnection = new SqlConnection(SqlConnectionStringBuilder.ToString());
            List<List<object>> listBuffer = new List<List<object>>();
            List<object> list = new List<object>(); // datatype = int
            List<object> DTList = new List<object>(); // datatype  =datetime
            try
            {
                string TextComm = string.Format("SELECT TOP 1000 [{0}],[{1}] FROM [dbo].[{2}] order by {3} desc", DataTag, SearchName, TableName, SearchName);
                SqlCommand SelectComm = new SqlCommand(TextComm, _SqlConnection);
                if (_SqlConnection.State == ConnectionState.Closed)
                {
                    _SqlConnection.Open();
                }
                SqlDataReader reader = SelectComm.ExecuteReader();
                while (reader.Read())
                {
                    int SH = Convert.ToInt16(reader[DataTag].ToString());
                    DateTime DT = Convert.ToDateTime(reader[SearchName].ToString());
                    list.Add(SH);
                    DTList.Add(DT);
                }

                listBuffer.Add(DTList);
                listBuffer.Add(list);
                return listBuffer;
            }
            catch (Exception)
            {
                throw;
            }

            finally
            {
                if (_SqlConnection != null && _SqlConnection.State == ConnectionState.Open)
                    _SqlConnection.Close();
            }
        }
        public AuthorityManagent Login(string UserName, string Password)
        {
            SqlConnection _SqlConnection = new SqlConnection(SqlConnectionStringBuilder.ToString());
            AuthorityManagent managent = null;
            try
            {
                string TextComm = "SELECT * FROM dbo.Authority";
                SqlCommand SelectComm = new SqlCommand(TextComm, _SqlConnection);
                if (_SqlConnection.State == ConnectionState.Closed)
                {
                    _SqlConnection.Open();
                }
                SqlDataReader reader = SelectComm.ExecuteReader();

                while (reader.Read())
                {
                    managent = new AuthorityManagent(reader["UserName"].ToString().Trim(), reader["Password"].ToString().Trim(), (AuthorityManagent.Authority)Enum.Parse(typeof(AuthorityManagent.Authority), reader["Authority"].ToString().Trim()));
                    if (managent.UserName == UserName && managent.Password == Password)
                    {
                        managent.CheckAuthority = true;
                        break;
                    }
                }
                return managent;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_SqlConnection != null && _SqlConnection.State == ConnectionState.Open)
                    _SqlConnection.Close();
            }
        }
        private string[] GetStringFromArray(string[] DataTag)
        {
            string[] Recode = new string[2];
            int i;
            for (i = 0; i < DataTag.Length - 1; i++)
            {
                Recode[0] += DataTag[i] + ",";
                Recode[1] += "@" + DataTag[i] + ",";
            }
            Recode[0] += DataTag[i];
            Recode[1] += "@" + DataTag[i];
            return Recode;
        }
    }
}
