﻿using System;
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
            cargar();
        }

        private void dgvBandas_SelectionChanged(object sender, EventArgs e)
        {
            BandaMusical seleccionado = (BandaMusical)dgvBandas.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagenTapa);

            
        }

        private void cargar()
        {
            BandaMusicalSERVICE service = new BandaMusicalSERVICE();
            try
            {
                listaMusical = service.listar();
                dgvBandas.DataSource = listaMusical;
                dgvBandas.Columns["UrlImagenTapa"].Visible = false;
                cargarImagen(listaMusical[0].UrlImagenTapa);
                 
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaBandaMusical alta = new frmAltaBandaMusical();
            alta.ShowDialog();
            cargar();

        }
    }
}
