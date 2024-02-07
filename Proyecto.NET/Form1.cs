using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto.NET
{
    public partial class Form1 : Form
    {
        private List<BandaMusical> listaMusical;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BandaMusicalSERVICE service = new BandaMusicalSERVICE();
            listaMusical = service.listar();
            dgvBandas.DataSource = listaMusical;
            cargarImagen(listaMusical[0].UrlImagenTapa);
        }

        private void dgvBandas_SelectionChanged(object sender, EventArgs e)
        {
            BandaMusical seleccionado = (BandaMusical)dgvBandas.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagenTapa);
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
    }
}
