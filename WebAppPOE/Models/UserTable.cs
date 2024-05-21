using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace WebAppPOE.Models
{
    public class UserTable
    {
        public static string con_string = "Server=tcp:webbapp2.database.windows.net,1433;Initial Catalog=myDatabase;Persist Security Info=False;User ID=Nater;Password=UNK@2520;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        public int userID { get; set; }
        public string userName { get; set; }

        public string userSurname { get; set; }

        public string userEmail { get; set; }

        //the method for inserting data regarding the user
        public int insert_User(UserTable m)
        {

            try
            {
                string sql = "INSERT INTO userTable (userName, userSurname, userEmail) VALUES (@Name, @Surname, @Email)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", m.userName);
                cmd.Parameters.AddWithValue("@Surname", m.userSurname);
                cmd.Parameters.AddWithValue("@Email", m.userEmail);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                throw ex;
            }
        }

    }
}
