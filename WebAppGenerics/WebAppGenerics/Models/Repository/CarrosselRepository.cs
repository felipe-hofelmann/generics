using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAppGenerics.Models.Repository
{
    public class CarrosselRepository 
    {
        private  string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\GitHub-Projects\generics\WebAppGenerics\WebAppGenerics\App_Data\Estamparia.mdf;Integrated Security=True";
        public  void Create(Carrossel model)
        {
            ExecNonQuery("INSERT INTO Carrossel" +
                       "( Operador, Revisor, Producao) " +
                       $"Values ('{model.Operador}'" +
                       $",'{model.Revisor}'" +
                       $",'{model.Producao}')");
        }

        public  List<Carrossel> Read()
        {
            List<Carrossel> list = new List<Carrossel>();

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Comando SQL de Insert
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = "SELECT Id, Operador, Revisor, Producao FROM Carrossel";
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Carrossel model = new Carrossel();
                            model.Id = Convert.ToInt32(dataReader["Id"]);
                            model.Operador = dataReader["Operador"].ToString();
                            model.Revisor = dataReader["Revisor"].ToString();
                            model.Producao = Convert.ToInt32(dataReader["Producao"]);
                            list.Add(model);
                        }
                    }
                }
                return list;
            }
        }
        public Carrossel Read(int id)
        {
            Carrossel model = new Carrossel();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Comando SQL de Insert
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = $"SELECT Id, Operador, Revisor, Producao FROM Carrossel WHERE Id={id}";
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            model.Id = Convert.ToInt32(dataReader["Id"]);
                            model.Operador = dataReader["Operador"].ToString();
                            model.Revisor = dataReader["Revisor"].ToString();
                            model.Producao = Convert.ToInt32(dataReader["Producao"]);
                        }
                    }
                }
            }
            return model;
        }
        public void Update(Carrossel model)
        {
            ExecNonQuery("UPDATE Carrossel " +
                            "SET " +
                                $"Operador='{model.Operador}'" +
                                $",Revisor= '{model.Revisor}'" +
                                $", Producao='{model.Producao}'" +
                            $"WHERE Id = {model.Id}");
        }
        public void Delete(int id)
        {
            ExecNonQuery($"DELETE FROM Carrossel WHERE Id ={id}");
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