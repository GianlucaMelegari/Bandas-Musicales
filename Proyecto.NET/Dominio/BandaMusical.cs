using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class BandaMusical
    {
        
        public DateTime Fecha { get; set; }

        [DisplayName("Título")]
        public string Titulo { get; set;}

        [DisplayName("Canciones")]
        public int CantCanciones { get; set; }

        public string UrlImagenTapa { get; set; }

        [DisplayName("Género")]
        public Estilo Genero { get; set; } 

        public TiposEdicion Formato {  get; set; } 
    }
}
