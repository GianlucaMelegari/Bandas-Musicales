using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.NET
{
    internal class TiposEdicion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }

    }
}
