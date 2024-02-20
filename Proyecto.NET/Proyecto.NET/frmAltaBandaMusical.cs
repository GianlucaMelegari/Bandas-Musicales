using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Service;
using System.Globalization;

namespace Proyecto.NET
{
    public partial class frmAltaBandaMusical : Form
    {
        public frmAltaBandaMusical()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            BandaMusical banda = new BandaMusical();
            BandaMusicalSERVICE service = new BandaMusicalSERVICE();

            try
            {
                //banda.Fecha = dtpFechaLanzamiento.Value;
                //banda.Fecha = txtFechaLanz.Text

                string fechaTexto = txtFechaLanz.Text;

                // Intentar convertir el texto a DateTime
                if (DateTime.TryParseExact(fechaTexto, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha))
                {
                    // La conversión fue exitosa
                    banda.Fecha = fecha;
                }
                else
                {
                    // La conversión falló, la entrada no es una fecha válida
                    MessageBox.Show("Formato de Fecha Inválido. Por favor, ingrese una fecha en el formato dd/MM/yyyy.");
                    return; // Salir del método si la fecha no es válida
                }



                banda.Titulo = txtTitulo.Text;
                
                if (int.TryParse(txtCantCanciones.Text, out int cantCanciones))
                    banda.CantCanciones = cantCanciones;

                 service.agregar(banda);
                 MessageBox.Show("Agregado exitosamente");
                 Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
