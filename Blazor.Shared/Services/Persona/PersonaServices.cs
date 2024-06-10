using Blazor.Shared.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Services.Persona
{
    public class PersonaServices : IPersonaServices
    {
        string connectionString = string.Empty;
        private readonly IConfiguration configuration;

        public PersonaServices(IConfiguration _configuration)
        {
            connectionString = _configuration.GetConnectionString("DBConnection");
        }
 
        public IEnumerable<PersonaEntity> GetAllPersonas()
        {
            List<PersonaEntity> lstPersona = new List<PersonaEntity>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_ObtenerPersona", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    PersonaEntity persona = new PersonaEntity();
                    persona.idPersona = Convert.ToInt32(rdr["idPersona"]);
                    persona.CI = rdr["CI"].ToString();
                    persona.Nombre = rdr["Nombre"].ToString();
                    persona.Telefono = rdr["Telefono"].ToString();

                    lstPersona.Add(persona);
                }
                con.Close();
            }
            return lstPersona;
        }

        public void AddPersona(PersonaEntity persona)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_CrearPersona", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CI", persona.CI);
                cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", persona.Telefono);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdatePersona(PersonaEntity persona)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_ActualizarPersona", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idPersona", persona.idPersona);
                cmd.Parameters.AddWithValue("@CI", persona.CI);
                cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", persona.Telefono);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeletePersona(int? idPersona)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_EliminarPersona", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("idPersona", idPersona);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
