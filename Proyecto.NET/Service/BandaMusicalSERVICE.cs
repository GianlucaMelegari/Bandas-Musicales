﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Service
{
    public class BandaMusicalSERVICE
    {
        //en esta clase se declaran los metodos para acceder a la base de datos

        public List<BandaMusical> listar()
        {
            List<BandaMusical>lista=new List<BandaMusical>();

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true";
                comando.CommandType=System.Data.CommandType.Text;
                comando.CommandText = "select Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion Genero, T.Descripcion Formato from DISCOS D, ESTILOS E, TIPOSEDICION T where D.IdEstilo=E.Id AND D.IdTipoEdicion=T.Id";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    BandaMusical aux = new BandaMusical();

                    aux.Titulo = (string)lector["Titulo"];
                    aux.Fecha = (DateTime)lector["FechaLanzamiento"];
                    aux.CantCanciones = (int)lector["CantidadCanciones"];
                    aux.UrlImagenTapa = (string)lector["UrlImagenTapa"];
                    //si no le creamos el objeto Genero / Formato nos da referencia nula ya que no existiria ningun objeto cargado
                    aux.Genero = new Estilo();
                    aux.Genero.Descripcion = (string)lector["Genero"];
                    aux.Formato = new TiposEdicion();
                    aux.Formato.Descripcion = (string)lector["Formato"];
                    
                    lista.Add(aux);  

                }
                conexion.Close();
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void agregar(BandaMusical nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into DISCOS (Titulo, FechaLanzamiento, CantidadCanciones) values ('" + nuevo.Titulo + "' , '" + nuevo.Fecha + "' , '" + nuevo.CantCanciones + "')");
                datos.ejecutarAccion();
                //datos.setearConsulta("INSERT INTO DISCOS (Titulo, FechaLanzamiento, CantidadCanciones) VALUES (@Titulo, @Fecha, @CantCanciones)");
                //datos.Comando.Parameters.AddWithValue("@Titulo", nuevo.Titulo);
                //datos.comando.Parameters.AddWithValue("@Fecha", nuevo.Fecha);
                //datos.comando.Parameters.AddWithValue("@CantCanciones", nuevo.CantCanciones);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(BandaMusical modificar)
        {

        }

    }

}
