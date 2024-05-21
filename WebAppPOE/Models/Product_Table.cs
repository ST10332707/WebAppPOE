using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace WebAppPOE.Models
{
    public class Product_Table : Controller
    {
        public static string con_string = "Server=tcp:webbapp2.database.windows.net,1433;Initial Catalog=myDatabase;Persist Security Info=False;User ID=Nater;Password=UNK@2520;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int ProductPrice { get; set; }

        public string ProductCategory { get; set; }

        public int ProductAvailability { get; set; }

        public int insert_product(Product_Table p)
        {

            try
            {
                string sql = "INSERT INTO productTable (productName, productPrice, productCategory, productAvailability) VALUES (@Name, @Price, @Category, @Availability)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", p.ProductName);
                cmd.Parameters.AddWithValue("@Price", p.ProductPrice);
                cmd.Parameters.AddWithValue("@Category", p.ProductCategory);
                cmd.Parameters.AddWithValue("@Availability", p.ProductAvailability);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception e)
            {
                // Log the exception or handle it appropriately
                // For now, rethrow the exception
                throw e;
            }

        }

        public static List<Product_Table> GetAllProducts()
        {
            List<Product_Table> products = new List<Product_Table>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM Product_Table";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product_Table product = new Product_Table();
                    product.ProductID = Convert.ToInt32(reader["ProductID"]);
                    product.ProductName = reader["ProductName"].ToString();
                    product.ProductPrice = Convert.ToInt32(reader["productPrice"]);
                    product.ProductCategory = reader["ProductCategory"].ToString();
                    product.ProductAvailability = Convert.ToInt32(reader["productAvailability"]);

                    products.Add(product);
                }
            }

            return products;
        }
    }
}
