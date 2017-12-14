using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Lab5.Models;
using System.Data.SqlClient;
namespace TP_Lab5.DAO
{
    public class RecordsDAO : DAO
    {
        public List<Records> GetAllRecords()
        {
            Connect();
            List<Records> recordList = new List<Records>();
            Log.For(this).Info("FORLOG");
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Car", Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Records record = new Records();
                    record.Id = Convert.ToInt32(reader["Id"]);
                    record.cathegory = Convert.ToString(reader["Cathegory"]);
                    record.model = Convert.ToString(reader["CarModel"]);
                    record.vin = Convert.ToString(reader["VINNumber"]);
                    record.trname = Convert.ToString(reader["CarBrand"]);
                    record.recedivs = Convert.ToString(reader["PreviousViolation"]);
                    recordList.Add(record);
                }
                reader.Close();
            }
            catch (Exception) { }
            finally { Disconnect(); }
            return recordList;
        }
        public bool AddRecord(Records record)
        {
            bool result = true;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(
                "INSERT INTO Car(CarBrand, CarModel, Cathegory, VINNUmber, PreviousViolation )" +
                "VALUES ((@CarBrand, @CarModel, @Cathegory, @VINNUmber, @PreviousViolation)", Connection
                );
                cmd.Parameters.AddWithValue("@CarBrand", record.trname);
                cmd.Parameters.AddWithValue("@CarModel", record.model);
                cmd.Parameters.AddWithValue("@Cathegory", record.cathegory);
                cmd.Parameters.AddWithValue("@VINNUmber", record.vin);
                cmd.Parameters.AddWithValue("@PreviousViolation", record.recedivs);
                cmd.ExecuteNonQuery();

           }
            catch (Exception) { result = false; }
            finally { Disconnect(); }
            return result;
        }
        public void EditRecord(Records record)
        {
            try
            {
                Connect();
                string str = "UPDATE Car SET CarBrand = '" + record.trname
                + "', CarModel = '" + record.model
                + "', Cathegory = '" + record.cathegory
                + "', VINNUmber = '" + record.vin
                + "', PreviousViolation = '" + record.recedivs
                + "'WHERE Id = " + record.Id;
                SqlCommand com = new SqlCommand(str, Connection);
                com.ExecuteNonQuery();
            }
            finally
            {
                Disconnect();
            }
        }
        public void DeleteRecord(int id)
        {
            try
            {
                Connect();
                string str = "DELETE FROM Car WHERE Id=" + id;
                SqlCommand com = new SqlCommand(str, Connection);
                com.ExecuteNonQuery();
            }
            finally
            {
                Disconnect();
            }
        }
    }
}