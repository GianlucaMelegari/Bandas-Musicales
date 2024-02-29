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
    public partial class frmBandaMusical : Form
    {
        private List<BandaMusical> listaMusical;
        public frmBandaMusical()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void dgvBandas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBandas.CurrentRow != null)
            {
                BandaMusical seleccionado = (BandaMusical)dgvBandas.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.UrlImagenTapa);
            }


        }

        private void cargar()
        {
            BandaMusicalSERVICE service = new BandaMusicalSERVICE();
            try
            {
                listaMusical = service.listar();
                dgvBandas.DataSource = listaMusical;
                ocultarColumnas();
                cargarImagen(listaMusical[0].UrlImagenTapa);
                 
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void ocultarColumnas()
        {
            dgvBandas.Columns["UrlImagenTapa"].Visible = false;
            dgvBandas.Columns["Id"].Visible = false;
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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            BandaMusical seleccionado;
            seleccionado = (BandaMusical)dgvBandas.CurrentRow.DataBoundItem;

            frmAltaBandaMusical modificar = new frmAltaBandaMusical(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        
        private void btnEliminarFisica_Click(object sender, EventArgs e)
        {
            BandaMusicalSERVICE banda = new BandaMusicalSERVICE();
            BandaMusical seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("Estas seguro que queres eliminarlo?","Eliminado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); //MENSAJE MODAL
                if(respuesta == DialogResult.Yes)
                {
                    seleccionado = (BandaMusical)dgvBandas.CurrentRow.DataBoundItem;
                    banda.eliminar(seleccionado.Id);
                    cargar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<BandaMusical> listaFiltrada;
            string filtro = txtFiltro.Text;

            if (filtro.Length>= 3)
            {
                listaFiltrada = listaMusical.FindAll(x => x.Titulo.ToUpper().Contains(filtro.ToUpper()) || x.Genero.Descripcion.ToUpper().Contains(filtro.ToUpper()));

            }
            else
            {
                listaFiltrada = listaMusical;
            }

            dgvBandas.DataSource = null;
            dgvBandas.DataSource = listaFiltrada;
            ocultarColumnas();

        }
    }
}
