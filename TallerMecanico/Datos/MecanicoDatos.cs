using System.Data.SqlClient;
using System.Data;
using TallerMecanico.Models;

namespace TallerMecanico.Datos
{
    public class MecanicoDatos
    {
        public List<MecanicoModelo> Listar()
        {

            var oLista = new List<MecanicoModelo>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listarMecanico", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new MecanicoModelo()
                        {
                            Idpersona = Convert.ToInt32(dr["Idpersona"]),
                            Identificacion = dr["Identificacion"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Nacimiento = dr["Nacimiento"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Escolaridad = dr["Escolaridad"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }
        public MecanicoModelo Obtener(int Idpersona)
        {
            var oPersona = new MecanicoModelo();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerMecanico", conexion);
                cmd.Parameters.AddWithValue("Idpersona", Idpersona);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oPersona.Idpersona = Convert.ToInt32(dr["Idpersona"]);
                        oPersona.Identificacion = dr["Identificacion"].ToString();
                        oPersona.Nombre = dr["Nombre"].ToString();
                        oPersona.Apellido = dr["Apellido"].ToString();
                        oPersona.Nacimiento = dr["Nacimiento"].ToString();
                        oPersona.Direccion = dr["Direccion"].ToString();
                        oPersona.Telefono = dr["Telefono"].ToString();
                        oPersona.Escolaridad = dr["Escolaridad"].ToString();

                    }
                }
            }
            return oPersona;
        }
        public bool Guardar(MecanicoModelo oPersona)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarMecanico", conexion);
                    cmd.Parameters.AddWithValue("Identificacion", oPersona.Identificacion);
                    cmd.Parameters.AddWithValue("Nombre", oPersona.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oPersona.Apellido);
                    cmd.Parameters.AddWithValue("Nacimiento", oPersona.Nacimiento);
                    cmd.Parameters.AddWithValue("Direccion", oPersona.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", oPersona.Telefono);
                    cmd.Parameters.AddWithValue("Escolaridad", oPersona.Escolaridad);
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
        public bool Editar(MecanicoModelo oPersona)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarMecanico", conexion);
                    cmd.Parameters.AddWithValue("Idpersona", oPersona.Idpersona);
                    cmd.Parameters.AddWithValue("Identificacion", oPersona.Identificacion);
                    cmd.Parameters.AddWithValue("Nombre", oPersona.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oPersona.Apellido);
                    cmd.Parameters.AddWithValue("Nacimiento", oPersona.Nacimiento);
                    cmd.Parameters.AddWithValue("Direccion", oPersona.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", oPersona.Telefono);
                    cmd.Parameters.AddWithValue("Escolaridad", oPersona.Escolaridad);
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
        public bool Eliminar(int Idpersona)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarMecanico", conexion);
                    cmd.Parameters.AddWithValue("Idpersona", Idpersona);
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
