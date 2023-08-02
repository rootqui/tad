namespace Lab_TablaCompleja
{
    partial class FrmRecursivo_Ubigeo
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnDeshacer = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.BtnInsertar = new System.Windows.Forms.Button();
            this.TxtNom = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.LblClave = new System.Windows.Forms.Label();
            this.TvwUbigeo = new System.Windows.Forms.TreeView();
            this.TxtCod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSincronizar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnDeshacer
            // 
            this.BtnDeshacer.Location = new System.Drawing.Point(473, 420);
            this.BtnDeshacer.Margin = new System.Windows.Forms.Padding(4);
            this.BtnDeshacer.Name = "BtnDeshacer";
            this.BtnDeshacer.Size = new System.Drawing.Size(100, 28);
            this.BtnDeshacer.TabIndex = 56;
            this.BtnDeshacer.Tag = "H";
            this.BtnDeshacer.Text = "&Deshacer";
            this.BtnDeshacer.UseVisualStyleBackColor = true;
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(365, 418);
            this.BtnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(100, 28);
            this.BtnEliminar.TabIndex = 55;
            this.BtnEliminar.Tag = "H";
            this.BtnEliminar.Text = "&Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Location = new System.Drawing.Point(257, 420);
            this.BtnActualizar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(100, 28);
            this.BtnActualizar.TabIndex = 54;
            this.BtnActualizar.Tag = "H";
            this.BtnActualizar.Text = "&Actualizar";
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // BtnInsertar
            // 
            this.BtnInsertar.Location = new System.Drawing.Point(149, 420);
            this.BtnInsertar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnInsertar.Name = "BtnInsertar";
            this.BtnInsertar.Size = new System.Drawing.Size(100, 28);
            this.BtnInsertar.TabIndex = 53;
            this.BtnInsertar.Tag = "H";
            this.BtnInsertar.Text = "&Insertar";
            this.BtnInsertar.UseVisualStyleBackColor = true;
            this.BtnInsertar.Click += new System.EventHandler(this.BtnInsertar_Click);
            // 
            // TxtNom
            // 
            this.TxtNom.Location = new System.Drawing.Point(135, 350);
            this.TxtNom.Margin = new System.Windows.Forms.Padding(4);
            this.TxtNom.MaxLength = 100;
            this.TxtNom.Name = "TxtNom";
            this.TxtNom.Size = new System.Drawing.Size(572, 22);
            this.TxtNom.TabIndex = 52;
            this.TxtNom.Tag = "HOL";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(16, 354);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(64, 17);
            this.Label3.TabIndex = 58;
            this.Label3.Text = "Nombre";
            // 
            // TxtId
            // 
            this.TxtId.Location = new System.Drawing.Point(135, 318);
            this.TxtId.Margin = new System.Windows.Forms.Padding(4);
            this.TxtId.MaxLength = 5;
            this.TxtId.Name = "TxtId";
            this.TxtId.Size = new System.Drawing.Size(89, 22);
            this.TxtId.TabIndex = 51;
            this.TxtId.Tag = "HOL";
            // 
            // LblClave
            // 
            this.LblClave.AutoSize = true;
            this.LblClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblClave.Location = new System.Drawing.Point(16, 321);
            this.LblClave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblClave.Name = "LblClave";
            this.LblClave.Size = new System.Drawing.Size(23, 17);
            this.LblClave.TabIndex = 57;
            this.LblClave.Text = "ID";
            // 
            // TvwUbigeo
            // 
            this.TvwUbigeo.FullRowSelect = true;
            this.TvwUbigeo.HideSelection = false;
            this.TvwUbigeo.Location = new System.Drawing.Point(16, 15);
            this.TvwUbigeo.Margin = new System.Windows.Forms.Padding(4);
            this.TvwUbigeo.Name = "TvwUbigeo";
            this.TvwUbigeo.Size = new System.Drawing.Size(691, 290);
            this.TvwUbigeo.TabIndex = 50;
            this.TvwUbigeo.Tag = "HL";
            this.TvwUbigeo.DoubleClick += new System.EventHandler(this.TvwUbigeo_DoubleClick);
            // 
            // TxtCod
            // 
            this.TxtCod.Location = new System.Drawing.Point(135, 382);
            this.TxtCod.Margin = new System.Windows.Forms.Padding(4);
            this.TxtCod.MaxLength = 5;
            this.TxtCod.Name = "TxtCod";
            this.TxtCod.Size = new System.Drawing.Size(89, 22);
            this.TxtCod.TabIndex = 59;
            this.TxtCod.Tag = "HOL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 385);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 60;
            this.label1.Text = "Código Sunat";
            // 
            // btnSincronizar
            // 
            this.btnSincronizar.Location = new System.Drawing.Point(580, 420);
            this.btnSincronizar.Name = "btnSincronizar";
            this.btnSincronizar.Size = new System.Drawing.Size(112, 28);
            this.btnSincronizar.TabIndex = 61;
            this.btnSincronizar.Text = "Sincronizar";
            this.btnSincronizar.UseVisualStyleBackColor = true;
            this.btnSincronizar.Click += new System.EventHandler(this.btnSincronizar_Click);
            // 
            // FrmRecursivo_Ubigeo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 463);
            this.Controls.Add(this.btnSincronizar);
            this.Controls.Add(this.TxtCod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnDeshacer);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnActualizar);
            this.Controls.Add(this.BtnInsertar);
            this.Controls.Add(this.TxtNom);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.TxtId);
            this.Controls.Add(this.LblClave);
            this.Controls.Add(this.TvwUbigeo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmRecursivo_Ubigeo";
            this.Text = "Ubigeo";
            this.Load += new System.EventHandler(this.FrmRecursivo_Ubigeo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button BtnDeshacer;
        internal System.Windows.Forms.Button BtnEliminar;
        internal System.Windows.Forms.Button BtnActualizar;
        internal System.Windows.Forms.Button BtnInsertar;
        internal System.Windows.Forms.TextBox TxtNom;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox TxtId;
        internal System.Windows.Forms.Label LblClave;
        internal System.Windows.Forms.TreeView TvwUbigeo;
        internal System.Windows.Forms.TextBox TxtCod;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSincronizar;
    }
}

