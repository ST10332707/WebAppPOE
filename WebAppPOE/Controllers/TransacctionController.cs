using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebAppPOE.Models;

namespace WebAppPOE.Controllers
{
    public class TransacctionController : Controller
    {
        [HttpPost]
        public ActionResult AddTransaction(int userID, int productID)
        {
            try
            {
                // Create a new instance of SqlConnection using the connection string
                using (SqlConnection con = new SqlConnection(Product_Table.con_string))
                {
                    // Define the SQL query to insert a new record into the transactionTable
                    string sql = "INSERT INTO Transaction_Table (userID, productID) VALUES (@UserID, @ProductID)";

                    // Create a new instance of SqlCommand with the SQL query and SqlConnection
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        // Add parameters to the SqlCommand for userID and productID
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@ProductID", productID);

                        // Open the SqlConnection
                        con.Open();

                        // Execute the SqlCommand to insert the record into the transactionTable
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Close the SqlConnection
                        con.Close();

                        // Check if the insert operation was successful
                        if (rowsAffected > 0)
                        {
                            // Send the user to the home page after placing they have placed an order
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            // If the insert data is not inserted, return an error view or message
                            return View("OrderFailed");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception and returns error message
                return View("Error");
            }
        }
    }
}
