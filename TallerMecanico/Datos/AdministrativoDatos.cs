using System.Data.SqlClient;
using System.Data;
using TallerMecanico.Models;

namespace TallerMecanico.Datos
{
    public class AdministrativoDatos
    {
        public List<AdministrativoModelo> Listar()
        {

            var oLista = new List<AdministrativoModelo>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listarAdministrativo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new AdministrativoModelo()
                        {
                            Idpersona = Convert.ToInt32(dr["Idpersona"]),
                            Identificacion = dr["Identificacion"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Nacimiento = dr["Nacimiento"].ToString(),
                            Cargo = dr["Cargo"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }
        public AdministrativoModelo Obtener(int Idpersona)
        {
            var oPersona = new AdministrativoModelo();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerAdministrativo", conexion);
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
                        oPersona.Cargo = dr["Cargo"].ToString();
                    }
                }
            }
            return oPersona;
        }
        public bool Guardar(AdministrativoModelo oPersona)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarAdministrativo", conexion);
                    cmd.Parameters.AddWithValue("Identificacion", oPersona.Identificacion);
                    cmd.Parameters.AddWithValue("Nombre", oPersona.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oPersona.Apellido);
                    cmd.Parameters.AddWithValue("Nacimiento", oPersona.Nacimiento);
                    cmd.Parameters.AddWithValue("Cargo", oPersona.Cargo);
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
        public bool Editar(AdministrativoModelo oPersona)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarAdministrativo", conexion);
                    cmd.Parameters.AddWithValue("Idpersona", oPersona.Idpersona);
                    cmd.Parameters.AddWithValue("Identificacion", oPersona.Identificacion);
                    cmd.Parameters.AddWithValue("Nombre", oPersona.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oPersona.Apellido);
                    cmd.Parameters.AddWithValue("Nacimiento", oPersona.Nacimiento);
                    cmd.Parameters.AddWithValue("Cargo", oPersona.Cargo);
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
                    SqlCommand cmd = new SqlCommand("sp_EliminarAdministrativo", conexion);
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
