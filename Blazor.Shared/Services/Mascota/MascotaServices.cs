using Blazor.Shared.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Services.Mascota
{
    public class MascotaServices : IMascotaServices
    {
        string connectionString = string.Empty;
        private readonly IConfiguration configuration;

        public MascotaServices(IConfiguration _configuration)
        {
            connectionString = _configuration.GetConnectionString("DBConnection");
        }

        public IEnumerable<MascotaEntity> GetAllMascotas()
        {
            List<MascotaEntity> lstMascota = new List<MascotaEntity>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_ObtenerMascota", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    MascotaEntity mascota = new MascotaEntity();
                    mascota.idMascota = Convert.ToInt32(rdr["idMascota"]);
                    mascota.Nombre = rdr["Nombre"].ToString();
                    mascota.Especie = rdr["Especie"].ToString();
                    mascota.Raza = rdr["Raza"].ToString();
                    mascota.Color = rdr["Color"].ToString();
                    mascota.FechaNacimiento = Convert.ToDateTime(rdr["FechaNacimiento"]);
                    mascota.PesoActual = Convert.ToSingle(rdr["PesoActual"]);
                    mascota.idCliente = Convert.ToInt32(rdr["idCliente"]);

                    lstMascota.Add(mascota);
                }
                con.Close();
            }
            return lstMascota;
        }

        public void AddMascota(MascotaEntity mascota)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_CrearMascota", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", mascota.Nombre);
                cmd.Parameters.AddWithValue("@Especie", mascota.Especie);
                cmd.Parameters.AddWithValue("@Raza", mascota.Raza);
                cmd.Parameters.AddWithValue("@Color", mascota.Color);
                cmd.Parameters.AddWithValue("@FechaNacimiento", mascota.FechaNacimiento);
                cmd.Parameters.AddWithValue("@PesoActual", mascota.PesoActual);
                cmd.Parameters.AddWithValue("@idCliente", mascota.idCliente);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateMascota(MascotaEntity mascota)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_ActualizarMascota", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idMascota", mascota.idMascota);
                cmd.Parameters.AddWithValue("@Nombre", mascota.Nombre);
                cmd.Parameters.AddWithValue("@Especie", mascota.Especie);
                cmd.Parameters.AddWithValue("@Raza", mascota.Raza);
                cmd.Parameters.AddWithValue("@Color", mascota.Color);
                cmd.Parameters.AddWithValue("@FechaNacimiento", mascota.FechaNacimiento);
                cmd.Parameters.AddWithValue("@PesoActual", mascota.PesoActual);
                cmd.Parameters.AddWithValue("@idCliente", mascota.idCliente);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteMascota(int? idMascota)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_EliminarMascota", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idMascota", idMascota);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        /*==============================================================================*/
        public IEnumerable<MascotaEntity> GetClienteMascota()
        {
            List<MascotaEntity> lstMascota = new List<MascotaEntity>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_ObtenerClienteMascota", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    MascotaEntity mascota = new MascotaEntity();
                    mascota.idMascota = Convert.ToInt32(rdr["idMascota"]);
                    mascota.Nombre = rdr["Nombre"].ToString();
                    mascota.Especie = rdr["Especie"].ToString();
                    mascota.Raza = rdr["Raza"].ToString();
                    mascota.Color = rdr["Color"].ToString();
                    mascota.FechaNacimiento = Convert.ToDateTime(rdr["FechaNacimiento"]);
                    mascota.PesoActual = Convert.ToSingle(rdr["PesoActual"]);
                    mascota.idCliente = Convert.ToInt32(rdr["idCliente"]);

                    lstMascota.Add(mascota);
                }
                con.Close();
            }
            return lstMascota;
        }
    }
}
