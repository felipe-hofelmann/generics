using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAppGenerics.Models.Repository
{
    public class ManualRepository : BaseRepository<Manual>
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\GitHub-Projects\generics\WebAppGenerics\WebAppGenerics\App_Data\Estamparia.mdf;Integrated Security=True";
        public void Create(Manual model)
        {
            ExecNonQuery("INSERT INTO Manual" +
                       "( Operador, Auxiliar, Producao) " +
                       $"Values ('{model.Estampador}'" +
                       $",{model.Auxiliar}" +
                       $",'{model.Producao}')");
        }

        public List<Manual> Read()
        {
            List<Manual> list = new List<Manual>();

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Comando SQL de Insert
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = "SELECT Id, Estampador, Auxiliar, Producao FROM Manual";
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Manual model = new Manual();
                            model.Id = Convert.ToInt32(dataReader["Id"]);
                            model.Estampador = dataReader["Estampador"].ToString();
                            model.Auxiliar = dataReader["Auxiliar"].ToString();
                            model.Producao = Convert.ToInt32(dataReader["Producao"]);
                            list.Add(model);
                        }
                    }
                }
                return list;
            }
        }
        public Manual Read(int id)
        {
            Manual model = new Manual();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Comando SQL de Insert
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = $"SELECT Id, Estampador, Auxiliar, Producao FROM Manual WHERE Id={id}";
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            model.Id = Convert.ToInt32(dataReader["Id"]);
                            model.Estampador = dataReader["Estampador"].ToString();
                            model.Auxiliar = dataReader["Auxiliar"].ToString();
                            model.Producao = Convert.ToInt32(dataReader["Producao"]);
                        }
                    }
                }
            }
            return model;
        }
        public void Update(Manual model)
        {
            ExecNonQuery("UPDATE Manual " +
                            "SET " +
                                $"Estampador='{model.Estampador}'" +
                                $",Auxiliar= {model.Auxiliar}" +
                                $", Producao='{model.Producao}'" +
                            $"WHERE Id = {model.Id}");
        }
        public void Delete(int id)
        {
            ExecNonQuery($"DELETE FROM Manual WHERE Id ={id}");
        }

        private void ExecNonQuery(string comando)
        {
            // Conectar no DB
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Comando SQL de Insert
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = comando;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}