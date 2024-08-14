using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel;

namespace LoadingTextFileToDatabase
{
    public class WorkingWithDatabase
    {
        public static string WriteTheDatabase(List<string> dataToSave)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["SqlConnection"];
            SqlConnection connection = new SqlConnection(settings.ConnectionString);
            try
            {
                connection.Open();
                for (int i = 0; i < dataToSave.Count; i++)
                {
                    string workingLine = dataToSave[i];
                    string[] givenRecording = workingLine.Split(';');
                    try
                    {
                        string query = "INSERT INTO dbo.[BriefOfInformation] ([Name],[Phone],[PlaceWork]) VALUES (N'" + givenRecording[0] + "',N'" + givenRecording[1] + "',N'" + givenRecording[2] + "')";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                connection.Close();
                return "Запись в базу успешна";
            }
            catch (Exception ex)
            {
                return "Ошибка при записи данных в базу: " + ex.Message + "";
            }
        }

        public static string NumberOfMentions()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["SqlConnection"];
            SqlConnection connection = new SqlConnection(settings.ConnectionString);
            try
            {
                connection.Open();
                string query = "DECLARE @Mentions TABLE (Word NVARCHAR(MAX),Count int)" +
                    "INSERT INTO @Mentions SELECT [Name], COUNT(*) FROM dbo.[BriefOfInformation] GROUP BY [Name]" +
                    "INSERT INTO @Mentions SELECT [Phone], COUNT(*) FROM dbo.[BriefOfInformation] GROUP BY [Phone]" +
                    "INSERT INTO @Mentions SELECT [PlaceWork], COUNT(*) FROM dbo.[BriefOfInformation] GROUP BY [PlaceWork] " +
                    "DELETE dbo.[NumberOfMentions]" +
                    "INSERT INTO dbo.[NumberOfMentions] select * from @Mentions";               
                SqlCommand command = new SqlCommand(query, connection);               
                command.ExecuteNonQuery();
                return "Подсчет упоминаний в базе прошел успешно";
            }
            catch (SqlException ex)
            {
                return "Ошибка при подсчете упоминаний в базе: " + ex.Message + "";
            }
        }
    }
}
