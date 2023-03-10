using sqlapp.Models;
using System.Data.SqlClient;

namespace sqlapp.Services

{
    public class ProductService
    {
        private static string db_source = " ";
        private static string db_user = "shubhamsaini";
        private static string db_password= "Rajkumars_123#";
        private static string db_database = "appdb";

        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }

        private SqlConnection GetConnection()
        {
            var _builder= new SqlConnectionStringBuilder();

            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);

        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();

            List<Product> _product_lst = new List<Product>();

            string statement = "SELECT ProductId,ProductName,Quantity from Product";

            conn.Open();

            SqlCommand cmd = new SqlCommand(statement, conn);

            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product= new Product();
                    {

                        ProductId = reader.GetInt32(0);
                        ProductName = reader.GetString(1);
                        Quantity = reader.GetInt32(2);
                    };

                    _product_lst.Add(product);
                }
                
            }
                conn.Close();
            return _product_lst;

        }
        
    }
}
