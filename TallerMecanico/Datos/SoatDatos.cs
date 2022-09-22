using System.Data.SqlClient;
using System.Data;
using TallerMecanico.Models;

namespace TallerMecanico.Datos
{
    public class SoatDatos
    {
        public List<SoatModelo> Listar()
        {

            var oLista = new List<SoatModelo>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarSoat", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new SoatModelo()
                        {
                            FKIdAutomovil = Convert.ToInt32(dr["FKIdAutomovil"]),
                            IdSoat = Convert.ToInt32(dr["IdSoat"]),
                            Placa = dr["Placa"].ToString(),
                            NumeroSoat = dr["NumeroSoat"].ToString(),
                            FechaCompra = dr["FechaCompra"].ToString(),
                            FechaExpira = dr["FechaExpira"].ToString()




                        });
                    }
                }
            }
            return oLista;
        }
        public SoatModelo Obtener(int IdSoat)
        {
            var oPersona = new SoatModelo();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerSoat", conexion);
                cmd.Parameters.AddWithValue("IdSoat", IdSoat);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        oPersona.IdSoat = Convert.ToInt32(dr["IdSoat"]);
                        oPersona.FKIdAutomovil = Convert.ToInt32(dr["FKIdAutomovil"]);
                        oPersona.Placa = dr["Placa"].ToString();
                        oPersona.NumeroSoat = dr["NumeroSoat"].ToString();
                        oPersona.FechaCompra = dr["FechaCompra"].ToString();
                        oPersona.FechaExpira = dr["FechaExpira"].ToString();

                    }
                }
            }
            return oPersona;
        }
        public bool Guardar(SoatModelo oPersona)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarSoat", conexion);
                    cmd.Parameters.AddWithValue("FKIdAutomovil", oPersona.FKIdAutomovil);
                    cmd.Parameters.AddWithValue("Placa", oPersona.Placa);
                    cmd.Parameters.AddWithValue("NumeroSoat", oPersona.NumeroSoat);
                    cmd.Parameters.AddWithValue("FechaCompra", oPersona.FechaCompra);
                    cmd.Parameters.AddWithValue("FechaExpira", oPersona.FechaExpira);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        public bool Editar(SoatModelo oPersona)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarSoat", conexion);
                    cmd.Parameters.AddWithValue("Placa", oPersona.Placa);
                    cmd.Parameters.AddWithValue("FKIdAutomovil", oPersona.FKIdAutomovil);
                    cmd.Parameters.AddWithValue("IdSoat", oPersona.IdSoat);
                    cmd.Parameters.AddWithValue("NumeroSoat", oPersona.NumeroSoat);
                    cmd.Parameters.AddWithValue("FechaCompra", oPersona.FechaCompra);
                    cmd.Parameters.AddWithValue("FechaExpira", oPersona.FechaExpira);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    

                }
                rpta = true;
            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        public bool Eliminar(int IdSoat)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarSoat", conexion);
                    cmd.Parameters.AddWithValue("IdSoat", IdSoat);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {

                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
    }
}
