using System.Data.SqlClient;
using System.Data;
using TallerMecanico.Models;
using System.Collections.Generic;
using TallerMecanico.Datos;

namespace TallerMecanico.Datos
{
    public class PersonaDatos
    {
        public List<PersonaModelo> Listar()
        {

            var oLista = new List<PersonaModelo>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new PersonaModelo()
                        {
                            Idpersona = Convert.ToInt32(dr["Idpersona"]),
                            Identificacion = dr["Identificacion"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Nacimiento = dr["Nacimiento"].ToString(),
                            Ciudad = dr["Ciudad"].ToString(),
                            Email = dr["Email"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }
        public PersonaModelo Obtener(int Idpersona)
        {
            var oPersona = new PersonaModelo();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
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
                        oPersona.Ciudad = dr["Ciudad"].ToString();
                        oPersona.Email = dr["Email"].ToString();

                    }
                }
            }
            return oPersona;
        }
        public bool Guardar(PersonaModelo oPersona)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarCliente", conexion);
                    cmd.Parameters.AddWithValue("Identificacion", oPersona.Identificacion);
                    cmd.Parameters.AddWithValue("Nombre", oPersona.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oPersona.Apellido);
                    cmd.Parameters.AddWithValue("Nacimiento", oPersona.Nacimiento);
                    cmd.Parameters.AddWithValue("Ciudad", oPersona.Ciudad);
                    cmd.Parameters.AddWithValue("Email", oPersona.Email);
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
        public bool Editar(PersonaModelo oPersona)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("Idpersona", oPersona.Idpersona);
                    cmd.Parameters.AddWithValue("Identificacion", oPersona.Identificacion);
                    cmd.Parameters.AddWithValue("Nombre", oPersona.Nombre);
                    cmd.Parameters.AddWithValue("Apellido", oPersona.Apellido);
                    cmd.Parameters.AddWithValue("Nacimiento", oPersona.Nacimiento);
                    cmd.Parameters.AddWithValue("Ciudad", oPersona.Ciudad);
                    cmd.Parameters.AddWithValue("Email", oPersona.Email);
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
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
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
