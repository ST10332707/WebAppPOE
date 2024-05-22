using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace WebAppPOE.Models
{
    public class UserTable
    {
        public static string con_string = "Server=tcp:webbapp2.database.windows.net,1433;Initial Catalog=myDatabase;Persist Security Info=False;User ID=Nater;Password=UNK@2520;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        public int UserID { get; set; }
        public string UserName { get; set; }

        public string UserSurname { get; set; }

        public string UserEmail { get; set; }

        //the method for inserting data regarding the user
        public int insert_User(UserTable m)
        {

            try
            {
                string sql = "INSERT INTO UserTable (UserName, UserSurname, UserEmail) VALUES (@Name, @Surname, @Email)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", m.UserName);
                cmd.Parameters.AddWithValue("@Surname", m.UserSurname);
                cmd.Parameters.AddWithValue("@Email", m.UserEmail);
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
