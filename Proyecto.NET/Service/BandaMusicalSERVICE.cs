using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using Microsoft.SqlServer.Server;

namespace Service
{
    public class BandaMusicalSERVICE
    {
        //en esta clase se declaran los metodos para acceder a la base de datos

        public List<BandaMusical> listar()
        {
            List<BandaMusical> lista = new List<BandaMusical>();
            AccesoDatos datos = new AccesoDatos();

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion Genero, T.Descripcion Formato, D.IdEstilo,D.IdTipoEdicion, D.Id from DISCOS D, ESTILOS E, TIPOSEDICION T where D.IdEstilo=E.Id AND D.IdTipoEdicion=T.Id";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    BandaMusical aux = new BandaMusical();

                    aux.Id = (int)lector["Id"];
                    aux.Titulo = (string)lector["Titulo"];
                    aux.Fecha = (DateTime)lector["FechaLanzamiento"];
                    aux.CantCanciones = (int)lector["CantidadCanciones"];

                    if (!(lector["UrlImagenTapa"] is DBNull))
                        aux.UrlImagenTapa = (string)lector["UrlImagenTapa"];

                    //si no le creamos el objeto Genero / Formato nos da referencia nula ya que no existiria ningun objeto cargado
                    aux.Genero = new Estilo();
                    aux.Genero.Id = (int)lector["IdEstilo"];
                    aux.Genero.Descripcion = (string)lector["Genero"];
                    aux.Formato = new TiposEdicion();
                    aux.Formato.Id = (int)lector["IdTipoEdicion"];
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

                datos.setearConsulta("insert into DISCOS (Titulo, FechaLanzamiento, CantidadCanciones, IdEstilo, IdTipoEdicion) values (@Titulo, @Fecha, @CantCanciones, @IdEstilo, @IdTipoEdicion)");
                datos.setearParametro("@Titulo", nuevo.Titulo);
                datos.setearParametro("@Fecha", nuevo.Fecha);
                datos.setearParametro("@CantCanciones", nuevo.CantCanciones);
                datos.setearParametro("@IdEstilo", nuevo.Genero.Id);
                datos.setearParametro("@IdTipoEdicion", nuevo.Formato.Id);

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

        public void modificar(BandaMusical banda)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update DISCOS set Titulo= @titulo, FechaLanzamiento= @fecha, CantidadCanciones= @cantcanc, UrlImagenTapa= @urlImagen, IdEstilo= @idEstilo, IdTipoEdicion= @idTipoEdicion where Id= @id");

                datos.setearParametro("@titulo", banda.Titulo);
                datos.setearParametro("@fecha", banda.Fecha);
                datos.setearParametro("@cantcanc", banda.CantCanciones);
                datos.setearParametro("@urlImagen", banda.UrlImagenTapa);
                datos.setearParametro("@idEstilo", banda.Genero.Id);
                datos.setearParametro("@idTipoEdicion", banda.Formato.Id);
                datos.setearParametro("@id", banda.Id);

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

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from DISCOS where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BandaMusical> filtrar(string campo, string criterio, string filtro)
        {
            List<BandaMusical> lista = new List<BandaMusical>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion Genero, T.Descripcion Formato, D.IdEstilo,D.IdTipoEdicion, D.Id from DISCOS D, ESTILOS E, TIPOSEDICION T where D.IdEstilo=E.Id AND D.IdTipoEdicion=T.Id AND  ";
                if (campo == "CantidadCanciones")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "CantidadCanciones > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "CantidadCanciones < " + filtro;
                            break;
                        default:
                            consulta += "CantidadCanciones = " + filtro;
                            break;
                    }
                }
                else if (campo == "Genero")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "E.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "E.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "E.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "T.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "T.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "T.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    BandaMusical aux = new BandaMusical();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.Fecha = (DateTime)datos.Lector["FechaLanzamiento"];
                    aux.CantCanciones = (int)datos.Lector["CantidadCanciones"];

                    if (!(datos.Lector["UrlImagenTapa"] is DBNull))
                        aux.UrlImagenTapa = (string)datos.Lector["UrlImagenTapa"];

                    //si no le creamos el objeto Genero / Formato nos da referencia nula ya que no existiria ningun objeto cargado
                    aux.Genero = new Estilo();
                    aux.Genero.Id = (int)datos.Lector["IdEstilo"];
                    aux.Genero.Descripcion = (string)datos.Lector["Genero"];
                    aux.Formato = new TiposEdicion();
                    aux.Formato.Id = (int)datos.Lector["IdTipoEdicion"];
                    aux.Formato.Descripcion = (string)datos.Lector["Formato"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}


