using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace WebAppPOE.Models
{
    public class Product_Display
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCategory { get; set; }
        public bool ProductAvailability { get; set; }

        public Product_Display() { }

        public Product_Display(int id, string name, decimal price, string category, bool availability)
        {
            ProductID = id;
            ProductName = name;
            ProductPrice = price;
            ProductCategory = category;
            ProductAvailability = availability;
        }

        //method for displaying the products
        public static List<Product_Display> SelectProducts()
        {
            List<Product_Display> products = new List<Product_Display>();//list is created

            string con_string = "Server=tcp:webbapp2.database.windows.net,1433;Initial Catalog=myDatabase;Persist Security Info=False;User ID=Nater;Password=UNK@2520;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT ProductID, ProductName, ProductPrice, ProductCategory, ProductAvailability FROM Product_Table";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product_Display product = new Product_Display();
                    product.ProductID = Convert.ToInt32(reader["ProductID"]);
                    product.ProductName = Convert.ToString(reader["ProductName"]);
                    product.ProductPrice = Convert.ToDecimal(reader["ProductPrice"]);
                    product.ProductCategory = Convert.ToString(reader["ProductCategory"]);
                    product.ProductAvailability = Convert.ToBoolean(reader["ProductAvailability"]);
                    products.Add(product);
                }
                reader.Close();
            }
            return products;
        }

    }
}
