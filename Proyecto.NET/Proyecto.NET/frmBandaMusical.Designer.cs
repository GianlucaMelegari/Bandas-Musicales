﻿namespace Proyecto.NET
{
    partial class frmBandaMusical
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvBandas = new System.Windows.Forms.DataGridView();
            this.pbAlbum = new System.Windows.Forms.PictureBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminarFisica = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBandas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbum)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBandas
            // 
            this.dgvBandas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBandas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvBandas.Location = new System.Drawing.Point(12, 12);
            this.dgvBandas.MultiSelect = false;
            this.dgvBandas.Name = "dgvBandas";
            this.dgvBandas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBandas.Size = new System.Drawing.Size(578, 249);
            this.dgvBandas.TabIndex = 0;
            this.dgvBandas.SelectionChanged += new System.EventHandler(this.dgvBandas_SelectionChanged);
            // 
            // pbAlbum
            // 
            this.pbAlbum.Location = new System.Drawing.Point(616, 12);
            this.pbAlbum.Name = "pbAlbum";
            this.pbAlbum.Size = new System.Drawing.Size(263, 249);
            this.pbAlbum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAlbum.TabIndex = 1;
            this.pbAlbum.TabStop = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(12, 277);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(93, 277);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(74, 23);
            this.btnModificar.TabIndex = 3;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminarFisica
            // 
            this.btnEliminarFisica.Location = new System.Drawing.Point(509, 277);
            this.btnEliminarFisica.Name = "btnEliminarFisica";
            this.btnEliminarFisica.Size = new System.Drawing.Size(81, 23);
            this.btnEliminarFisica.TabIndex = 4;
            this.btnEliminarFisica.Text = "Eliminar Fisica";
            this.btnEliminarFisica.UseVisualStyleBackColor = true;
            this.btnEliminarFisica.Click += new System.EventHandler(this.btnEliminarFisica_Click);
            // 
            // frmBandaMusical
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 330);
            this.Controls.Add(this.btnEliminarFisica);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.pbAlbum);
            this.Controls.Add(this.dgvBandas);
            this.Name = "frmBandaMusical";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBandas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlbum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBandas;
        private System.Windows.Forms.PictureBox pbAlbum;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminarFisica;
    }
}

