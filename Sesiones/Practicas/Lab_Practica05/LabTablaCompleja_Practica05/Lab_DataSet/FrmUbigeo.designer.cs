namespace Lab_DataSet
{
    partial class FrmUbigeo
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
            this.label1 = new System.Windows.Forms.Label();
            this.CmbDepartamento = new System.Windows.Forms.ComboBox();
            this.CmbProvincia = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbDistrito = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDepa = new System.Windows.Forms.TextBox();
            this.TxtProv = new System.Windows.Forms.TextBox();
            this.TxtDist = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Departamento";
            // 
            // CmbDepartamento
            // 
            this.CmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDepartamento.FormattingEnabled = true;
            this.CmbDepartamento.Location = new System.Drawing.Point(92, 12);
            this.CmbDepartamento.Name = "CmbDepartamento";
            this.CmbDepartamento.Size = new System.Drawing.Size(332, 21);
            this.CmbDepartamento.TabIndex = 1;
            this.CmbDepartamento.SelectedIndexChanged += new System.EventHandler(this.CmbDepartamento_SelectedIndexChanged);
            // 
            // CmbProvincia
            // 
            this.CmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProvincia.FormattingEnabled = true;
            this.CmbProvincia.Location = new System.Drawing.Point(92, 39);
            this.CmbProvincia.Name = "CmbProvincia";
            this.CmbProvincia.Size = new System.Drawing.Size(332, 21);
            this.CmbProvincia.TabIndex = 3;
            this.CmbProvincia.SelectedIndexChanged += new System.EventHandler(this.CmbProvincia_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Provincia";
            // 
            // CmbDistrito
            // 
            this.CmbDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDistrito.FormattingEnabled = true;
            this.CmbDistrito.Location = new System.Drawing.Point(92, 66);
            this.CmbDistrito.Name = "CmbDistrito";
            this.CmbDistrito.Size = new System.Drawing.Size(332, 21);
            this.CmbDistrito.TabIndex = 5;
            this.CmbDistrito.SelectedIndexChanged += new System.EventHandler(this.CmbDistrito_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Distrito";
            // 
            // TxtDepa
            // 
            this.TxtDepa.Location = new System.Drawing.Point(430, 12);
            this.TxtDepa.Name = "TxtDepa";
            this.TxtDepa.ReadOnly = true;
            this.TxtDepa.Size = new System.Drawing.Size(49, 20);
            this.TxtDepa.TabIndex = 6;
            // 
            // TxtProv
            // 
            this.TxtProv.Location = new System.Drawing.Point(430, 40);
            this.TxtProv.Name = "TxtProv";
            this.TxtProv.ReadOnly = true;
            this.TxtProv.Size = new System.Drawing.Size(49, 20);
            this.TxtProv.TabIndex = 7;
            // 
            // TxtDist
            // 
            this.TxtDist.Location = new System.Drawing.Point(430, 66);
            this.TxtDist.Name = "TxtDist";
            this.TxtDist.ReadOnly = true;
            this.TxtDist.Size = new System.Drawing.Size(49, 20);
            this.TxtDist.TabIndex = 8;
            // 
            // FrmUbigeo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 101);
            this.Controls.Add(this.TxtDist);
            this.Controls.Add(this.TxtProv);
            this.Controls.Add(this.TxtDepa);
            this.Controls.Add(this.CmbDistrito);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbProvincia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbDepartamento);
            this.Controls.Add(this.label1);
            this.Name = "FrmUbigeo";
            this.Text = "Consulta de Ubigeos";
            this.Load += new System.EventHandler(this.FrmUbigeo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbDepartamento;
        private System.Windows.Forms.ComboBox CmbProvincia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbDistrito;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtDepa;
        private System.Windows.Forms.TextBox TxtProv;
        private System.Windows.Forms.TextBox TxtDist;
    }
}

