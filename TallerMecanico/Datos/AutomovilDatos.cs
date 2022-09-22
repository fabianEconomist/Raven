using System.Data.SqlClient;
using System.Data;
using TallerMecanico.Models;
using System.Collections.Generic;
using TallerMecanico.Datos;
using System.Numerics;

namespace TallerMecanico.Datos
{
    public class AutomovilDatos
    {
        public List<AutomovilModelo> Listar()
        {

            var oLista = new List<AutomovilModelo>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarAutomovil", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oLista.Add(new AutomovilModelo()
                        {
                            IdAutomovil = Convert.ToInt32(dr["IdAutomovil"]),
                            FKIdCliente = Convert.ToInt32(dr["FKIdCliente"]),
                            Identificacion = dr["Identificacion"].ToString(),
                            Placa = dr["Placa"].ToString(),
                            Tipo = dr["Tipo"].ToString(),
                            Modelo = dr["Modelo"].ToString(),
                            Marca = dr["Marca"].ToString(),
                            CiudadOrigen = dr["CiudadOrigen"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Capacidad = dr["Capacidad"].ToString(),
                            Cilindraje = dr["Cilindraje"].ToString()

                        });
                    }
                }
            }
            return oLista;
        }
        public AutomovilModelo Obtener(int IdAutomovil)
        {
            var oPersona = new AutomovilModelo();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerAutomovil", conexion);
                cmd.Parameters.AddWithValue("IdAutomovil", IdAutomovil);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oPersona.IdAutomovil = Convert.ToInt32(dr["IdAutomovil"]);
                        oPersona.Identificacion = dr["Identificacion"].ToString();
                        oPersona.Placa = dr["Placa"].ToString();
                        oPersona.Tipo = dr["Tipo"].ToString();
                        oPersona.Modelo = dr["Modelo"].ToString();
                        oPersona.Marca = dr["Marca"].ToString();
                        oPersona.CiudadOrigen = dr["CiudadOrigen"].ToString();
                        oPersona.Descripcion = dr["Descripcion"].ToString();
                        oPersona.Capacidad = dr["Capacidad"].ToString();
                        oPersona.Cilindraje = dr["Cilindraje"].ToString();

                    }
                }
            }
            return oPersona;
        }
        public bool Guardar(AutomovilModelo oPersona)
        {
            bool rpta;
            
            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarAutomovil", conexion);
                    cmd.Parameters.AddWithValue("Identificacion", oPersona.Identificacion);
                    cmd.Parameters.AddWithValue("FKIdCliente", oPersona.FKIdCliente);
                    cmd.Parameters.AddWithValue("Placa", oPersona.Placa);
                    cmd.Parameters.AddWithValue("Tipo", oPersona.Tipo);
                    cmd.Parameters.AddWithValue("Modelo", oPersona.Modelo);
                    cmd.Parameters.AddWithValue("Marca", oPersona.Marca);
                    cmd.Parameters.AddWithValue("CiudadOrigen", oPersona.CiudadOrigen);
                    cmd.Parameters.AddWithValue("Descripcion", oPersona.Descripcion);
                    cmd.Parameters.AddWithValue("Capacidad", oPersona.Capacidad);
                    cmd.Parameters.AddWithValue("Cilindraje", oPersona.Cilindraje);
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
        public bool Editar(AutomovilModelo oPersona)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarAutomovil", conexion);
                    cmd.Parameters.AddWithValue("IdAutomovil", oPersona.IdAutomovil);
                    cmd.Parameters.AddWithValue("Identificacion", oPersona.Identificacion);
                    cmd.Parameters.AddWithValue("Placa", oPersona.Placa);
                    cmd.Parameters.AddWithValue("Tipo", oPersona.Tipo);
                    cmd.Parameters.AddWithValue("Modelo", oPersona.Modelo);
                    cmd.Parameters.AddWithValue("Marca", oPersona.Marca);
                    cmd.Parameters.AddWithValue("CiudadOrigen", oPersona.CiudadOrigen);
                    cmd.Parameters.AddWithValue("Descripcion", oPersona.Descripcion);
                    cmd.Parameters.AddWithValue("Capacidad", oPersona.Capacidad);
                    cmd.Parameters.AddWithValue("Cilindraje", oPersona.Cilindraje);
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
        public bool Eliminar(int IdAutomovil)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarAutomovil", conexion);
                    cmd.Parameters.AddWithValue("IdAutomovil", IdAutomovil);
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

        //nuevo metodo obtener2---------------------------------------------------
        public AutomovilModelo Obtener2(int IdAuto)
        {
            var oPersona = new AutomovilModelo();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerAutomovil2", conexion);
                cmd.Parameters.AddWithValue("IdAutomovil", IdAuto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        oPersona.FKIdCliente = Convert.ToInt32(dr["FKIdCliente"]);
                        oPersona.IdAutomovil = Convert.ToInt32(dr["IdAutomovil"]);
                        oPersona.Identificacion = dr["Identificacion"].ToString();
                        oPersona.Placa = dr["Placa"].ToString();
                        oPersona.Tipo = dr["Tipo"].ToString();
                        oPersona.Modelo = dr["Modelo"].ToString();
                        oPersona.Marca = dr["Marca"].ToString();
                        oPersona.CiudadOrigen = dr["CiudadOrigen"].ToString();
                        oPersona.Descripcion = dr["Descripcion"].ToString();
                        oPersona.Capacidad = dr["Capacidad"].ToString();
                        oPersona.Cilindraje = dr["Cilindraje"].ToString();

                    }
                }
            }
            return oPersona;
        }

    }
}
