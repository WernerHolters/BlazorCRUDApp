using Blazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Blazor.Shared.Services.PersonaCliente
{
    public class PersonaClienteServices : IPersonaClienteServices
    {
        string connectionString = string.Empty;
        private readonly IConfiguration configuration;

        public PersonaClienteServices(IConfiguration _configuration)
        {
            connectionString = _configuration.GetConnectionString("DBConnection");
        }

        public void AddPersonaCliente(PersonaClienteEntity personacliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_AsociarPersonaCliente", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FechaAsociacion", personacliente.FechaAsociacion);
                cmd.Parameters.AddWithValue("@idPersona", personacliente.idPersona);
                cmd.Parameters.AddWithValue("@idCliente", personacliente.idCliente);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
