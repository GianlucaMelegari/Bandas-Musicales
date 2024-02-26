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
using Service;
using System.Globalization;

namespace Proyecto.NET
{
    public partial class frmAltaBandaMusical : Form
    {
        private BandaMusical bandaMusical = null;
        public frmAltaBandaMusical()
        {
            InitializeComponent();
        }

        public frmAltaBandaMusical(BandaMusical bandaMusical)
        {
            this.bandaMusical= bandaMusical;
            InitializeComponent();
            Text = "Modificar Banda Musical";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            BandaMusicalSERVICE service = new BandaMusicalSERVICE();

            try
            {
                if (bandaMusical == null)
                    bandaMusical = new BandaMusical();

                string fechaTexto = txtFechaLanz.Text;
                // Intentar convertir el texto a DateTime
                if (DateTime.TryParseExact(fechaTexto, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha))
                {
                    bandaMusical.Fecha = fecha;
                }
                else
                {
                    MessageBox.Show("Formato de Fecha Inválido. Por favor, ingrese una fecha en el formato dd/mm/yyyy.");
                    return; 
                }

                bandaMusical.Titulo = txtTitulo.Text;
                
                if (int.TryParse(txtCantCanciones.Text, out int cantCanciones))
                    bandaMusical.CantCanciones = cantCanciones;

                bandaMusical.UrlImagenTapa = txtUrlImagen.Text;
                bandaMusical.Genero = (Estilo) cbEstilo.SelectedItem;
                bandaMusical.Formato = (TiposEdicion) cbTipoEdicion.SelectedItem;

                if(bandaMusical.Id != 0)
                {
                    service.modificar(bandaMusical);
                    MessageBox.Show("Modificado exitosamente.");

                } else
                {
                    service.agregar(bandaMusical);
                    MessageBox.Show("Agregado exitosamente.");

                }


                Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAltaBandaMusical_Load(object sender, EventArgs e)
        {
            EstiloSERVICE estiloService = new EstiloSERVICE();
            TipoEdicionSERVICE tipoEdicionService = new TipoEdicionSERVICE();
            try
            {
                cbEstilo.DataSource = estiloService.listar();
                cbEstilo.ValueMember = "Id";
                cbEstilo.DisplayMember = "Descripcion";
                cbTipoEdicion.DataSource = tipoEdicionService.listar();
                cbTipoEdicion.ValueMember = "Id";
                cbTipoEdicion.DisplayMember = "Descripcion";    

                if(bandaMusical!=null)
                {
                    txtTitulo.Text = bandaMusical.Titulo;
                    txtFechaLanz.Text = bandaMusical.Fecha.ToString();
                    txtCantCanciones.Text = bandaMusical.CantCanciones.ToString();
                    txtUrlImagen.Text = bandaMusical.UrlImagenTapa;
                    cargarImagen(bandaMusical.UrlImagenTapa);
                    cbEstilo.SelectedValue = bandaMusical.Genero.Id;
                    cbTipoEdicion.SelectedValue = bandaMusical.Formato.Id;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        //private void cbEstilo_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);  
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbAlbum.Load(imagen);
            }
            catch (Exception ex)
            {
                pbAlbum.Load("https://cdn.pixabay.com/photo/2017/02/12/21/29/false-2061132_640.png");
            }
        }

        //private void txtUrlImagen_TextChanged(object sender, EventArgs e)
        //{

        //}
    }
}
