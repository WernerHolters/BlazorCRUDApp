using Blazor.Shared.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Services.Cliente
{
    public class ClienteServices : IClienteServices
    {
        string connectionString = string.Empty;
        private readonly IConfiguration configuration;

        public ClienteServices(IConfiguration _configuration)
        {
            connectionString = _configuration.GetConnectionString("DBConnection");
        }


        public IEnumerable<ClienteEntity> GetAllClientes()
        {
            List<ClienteEntity> lstCliente = new List<ClienteEntity>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_ObtenerCliente", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ClienteEntity cliente = new ClienteEntity();
                    cliente.idCliente = Convert.ToInt32(rdr["idCliente"]);
                    cliente.PrimerApellido = rdr["PrimerApellido"].ToString();
                    cliente.CuentaBanco = rdr["CuentaBanco"].ToString();
                    cliente.Direccion = rdr["Direccion"].ToString();
                    cliente.Telefono = rdr["Telefono"].ToString();

                    lstCliente.Add(cliente);
                }
                con.Close();
            }
            return lstCliente;
        }

        public void AddCliente(ClienteEntity cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_CrearCliente", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PrimerApellido", cliente.PrimerApellido);
                cmd.Parameters.AddWithValue("@CuentaBanco", cliente.CuentaBanco);
                cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateCliente(ClienteEntity cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_ActualizarCliente", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idCliente", cliente.idCliente);
                cmd.Parameters.AddWithValue("@PrimerApellido", cliente.PrimerApellido);
                cmd.Parameters.AddWithValue("@CuentaBanco", cliente.CuentaBanco);
                cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        public void DeleteCliente(int? idCliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_EliminarCliente", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("idCliente", idCliente);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
