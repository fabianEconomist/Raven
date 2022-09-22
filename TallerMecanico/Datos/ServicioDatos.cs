using System.Data.SqlClient;
using System.Data;
using TallerMecanico.Models;

namespace TallerMecanico.Datos
{
    public class ServicioDatos
    {
        public List<ServicioModelo> Listar()
        {

            var oLista = new List<ServicioModelo>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listarServicio", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new ServicioModelo()
                        {
                            IdServicio = Convert.ToInt32(dr["IdServicio"]),
                            FKIdCliente = Convert.ToInt32(dr["FKIdCliente"]),
                            FKIdAutomovil = Convert.ToInt32(dr["FKIdAutomovil"]),
                            FKIdMecanico = Convert.ToInt32(dr["FKIdMecanico"]),
                            NivelAceite = dr["NivelAceite"].ToString(),
                            NivelFrenos = dr["NivelFrenos"].ToString(),
                            NivelDireccion = dr["NivelDireccion"].ToString(),
                            NivelRefrigerante = dr["NivelRefrigerante"].ToString(),
                            Repuestos = dr["Repuestos"].ToString(),
                            Fecha = dr["Fecha"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }
        public ServicioModelo Obtener(int IdServicio)
        {
            var oPersona = new ServicioModelo();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerServicio", conexion);
                cmd.Parameters.AddWithValue("IdServicio", IdServicio);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oPersona.IdServicio = Convert.ToInt32(dr["IdServicio"]);
                        oPersona.FKIdCliente = Convert.ToInt32(dr["FKIdCliente"]);
                        oPersona.FKIdAutomovil = Convert.ToInt32(dr["FKIdAutomovil"]);
                        oPersona.FKIdMecanico = Convert.ToInt32(dr["FKIdMecanico"]);
                        oPersona.NivelAceite = dr["NivelAceite"].ToString();
                        oPersona.NivelFrenos = dr["NivelFrenos"].ToString();
                        oPersona.NivelDireccion = dr["NivelDireccion"].ToString();
                        oPersona.NivelRefrigerante = dr["NivelRefrigerante"].ToString();
                        oPersona.Repuestos = dr["Repuestos"].ToString();
                        oPersona.Fecha = dr["Fecha"].ToString();

                    }
                }
            }
            return oPersona;
        }
        public bool Guardar(ServicioModelo oPersona)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarServicio", conexion);
                    cmd.Parameters.AddWithValue("IdServicio", oPersona.IdServicio);
                    cmd.Parameters.AddWithValue("FKIdCliente", oPersona.FKIdCliente);
                    cmd.Parameters.AddWithValue("FKIdAutomovil", oPersona.FKIdAutomovil);
                    cmd.Parameters.AddWithValue("FKIdMecanico", oPersona.FKIdMecanico);
                    cmd.Parameters.AddWithValue("NivelAceite", oPersona.NivelAceite);
                    cmd.Parameters.AddWithValue("NivelFrenos", oPersona.NivelFrenos);
                    cmd.Parameters.AddWithValue("NivelDireccion", oPersona.NivelDireccion);
                    cmd.Parameters.AddWithValue("NivelRefrigerante", oPersona.NivelRefrigerante);
                    cmd.Parameters.AddWithValue("Repuestos", oPersona.Repuestos);
                    
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
        public bool Editar(ServicioModelo oPersona)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarServicio", conexion);
                    cmd.Parameters.AddWithValue("IdServicio", oPersona.IdServicio);
                    cmd.Parameters.AddWithValue("FKIdCliente", oPersona.FKIdCliente);
                    cmd.Parameters.AddWithValue("FKIdAutomovil", oPersona.FKIdAutomovil);
                    cmd.Parameters.AddWithValue("FKIdMecanico", oPersona.FKIdMecanico);
                    cmd.Parameters.AddWithValue("NivelAceite", oPersona.NivelAceite);
                    cmd.Parameters.AddWithValue("NivelFrenos", oPersona.NivelFrenos);
                    cmd.Parameters.AddWithValue("NivelDireccion", oPersona.NivelDireccion);
                    cmd.Parameters.AddWithValue("NivelRefrigerante", oPersona.NivelRefrigerante);
                    cmd.Parameters.AddWithValue("Repuestos", oPersona.Repuestos);
                    cmd.Parameters.AddWithValue("Fecha", oPersona.Fecha);
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
        public bool Eliminar(int IdServicio)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarServicio", conexion);
                    cmd.Parameters.AddWithValue("IdServicio", IdServicio);
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
