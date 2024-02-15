using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class BandaMusical
    {
        public DateTime Fecha { get; set; }
        public string Titulo { get; set;}

        public int CantCanciones { get; set; }

        public string UrlImagenTapa { get; set; }

        public Estilo Genero { get; set; }

        public TiposEdicion Formato {  get; set; }
    }
}
