using Blazor.Shared.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Services.Huesped
{
    public class HuespedServices : IHuespedServices
    {
        string connectionString = string.Empty;
        private readonly IConfiguration configuration;

        public HuespedServices(IConfiguration _configuration)
        {
            connectionString = _configuration.GetConnectionString("DBConnection");
        }

        public IEnumerable<HuespedEntity> GetAllHuespedes()
        {
            List<HuespedEntity> lstHuesped = new List<HuespedEntity>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_ObtenerHuesped", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    HuespedEntity huesped = new HuespedEntity();
                    huesped.idHuesped = Convert.ToInt32(rdr["idHuesped"]);
                    huesped.FechaIngreso = Convert.ToDateTime(rdr["FechaIngreso"]);
                    huesped.FechaSalida = Convert.ToDateTime(rdr["FechaSalida"]);
                    huesped.CostoHospedaje = Convert.ToSingle(rdr["CostoHospedaje"]);
                    huesped.idMascota = Convert.ToInt32(rdr["idMascota"]);

                    lstHuesped.Add(huesped);
                }
                con.Close();
            }
            return lstHuesped;
        }

        public void AddHuesped(HuespedEntity huesped)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_CrearHuesped", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FechaIngreso", huesped.FechaIngreso);
                cmd.Parameters.AddWithValue("@FechaSalida", huesped.FechaSalida);
                cmd.Parameters.AddWithValue("@CostoHospedaje", huesped.CostoHospedaje);
                cmd.Parameters.AddWithValue("@idMascota", huesped.idMascota);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateHuesped(HuespedEntity huesped)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_ActualizarHuesped", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idHuesped", huesped.idHuesped);
                cmd.Parameters.AddWithValue("@FechaIngreso", huesped.FechaIngreso);
                cmd.Parameters.AddWithValue("@FechaSalida", huesped.FechaSalida);
                cmd.Parameters.AddWithValue("@CostoHospedaje", huesped.CostoHospedaje);
                cmd.Parameters.AddWithValue("@idMascota", huesped.idMascota);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteHuesped(int? idHuesped)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_EliminarHuesped", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idHuesped", idHuesped);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
