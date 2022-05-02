
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Data.SqlClient;

namespace BlazorApp3.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var rand = new Random();
            using (SqlConnection conn = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=Master;Trusted_Connection=True;MultipleActiveResultSets=true"))
            { 
                var Id = rand.Next(2500);
                var Numero = rand.Next(2500).ToString();
                conn.Open();
                for (int i = 0; i < 2500; i++)
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        Id = rand.Next(2500);
                        Numero = rand.Next(2500).ToString();
                        cmd.CommandText = "INSERT INTO data(Id,Numero) VALUES(@param1,@param2)";

                        cmd.Parameters.AddWithValue("@param1", Id);
                        cmd.Parameters.AddWithValue("@param2", Numero);
                        cmd.ExecuteNonQuery();
                    }
                }
                conn.Close();
            }
        }
    }
}
