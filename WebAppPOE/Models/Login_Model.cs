using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace WebAppPOE.Models
{
    public class Login_Model : Controller
    {
        
        public static string con_string = "Server=tcp:webbapp2.database.windows.net,1433;Initial Catalog=myDatabase;Persist Security Info=False;User ID=Nater;Password=UNK@2520;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public int SelectUser(string email, string name)
        {
            int userID = -1; // Default value if user is not found
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT userID FROM userTable WHERE userEmail = @Email AND userName = @Name";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Name", name);
                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        userID = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it appropriately
                    throw ex;
                }
            }
            return userID;
        }
    }
}
