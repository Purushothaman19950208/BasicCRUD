using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using BasicCRUD.DataModels.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BasicCRUD.DataModels.Dapper
{
    public class Products : IProducts
    {
        IConfiguration _configuration;
        string connectionString = string.Empty;

        public Products(IConfiguration configuration)
        {
            _configuration = configuration;
             connectionString = this.GetConnection();
        }
        public int Add(Product product)
        {
            int count = 0;
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO Product(Name, Price) VALUES(@Name, @Price); SELECT CAST(SCOPE_IDENTITY() as INT);";
                    count = con.Execute(query, product);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        private string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DBConnection").Value;
            return connection;
        }

        public int DeleteProduct(int id)
        {

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var affectedRows = connection.Execute("Delete from Product Where Id = @Id", new { Id = id });
                    connection.Close();
                    return affectedRows;
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public int EditProduct(Product product)
        {
            int rowAffected = 0;
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                try
                {

                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Id", product.Id);
                    parameters.Add("@ProductName", product.Name);
                    parameters.Add("@ProductPrice", product.Price);
                    parameters.Add("@CategoryId", product.CategoryId);
                    rowAffected = con.Execute("PRODUCTUPDATE", parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }

            return rowAffected;
        }

        public List<Product> GetProductList()
        {
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                try
                {

                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    List<Product> products = con.Query<Product>("GetAllProducts", commandType: CommandType.StoredProcedure).ToList();
                    con.Close();
                    return products;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public Product GetProduct(int id)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Product product = connection.Query<Product>("select P.NAME,p.PRICE, C.NAME from PRODUCT P  left outer join CATEGORY C on c.ID = p.CategoryId WHERE ID =  @Id", new { Id = id }).FirstOrDefault();
                    connection.Close();
                    return product;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        public List<Category> GetCategoriesList()
        {
            using (IDbConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    List<Category> categories = con.Query<Category>("SELECT * FROM CATEGORY").ToList();
                    con.Close();
                    return categories;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
