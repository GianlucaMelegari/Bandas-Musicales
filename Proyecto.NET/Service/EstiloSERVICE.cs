using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Service
{
    public class EstiloSERVICE
    {
        public List<Estilo> listar()
        {
            List<Estilo> lista = new List<Estilo>();
            AccesoDatos datos= new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id, Descripcion from ESTILOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Estilo aux = new Estilo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Description"];

                    lista.Add(aux);
                }

                return lista;

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
    }
}
