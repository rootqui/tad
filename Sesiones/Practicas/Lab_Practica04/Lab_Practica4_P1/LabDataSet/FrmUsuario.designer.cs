namespace LabDataSet
{
    partial class FrmUsuario
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
            this.BtnInsertar = new System.Windows.Forms.Button();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNom = new System.Windows.Forms.TextBox();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.BtnAyudaApe = new System.Windows.Forms.Button();
            this.BtnAyudaNom = new System.Windows.Forms.Button();
            this.TxtApe = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtUsr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtVer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtCon = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CmbPai = new System.Windows.Forms.ComboBox();
            this.TxtCel = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtCor = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.DtpNac = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.CmbSex = new System.Windows.Forms.ComboBox();
            this.BtnSincronizar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnInsertar
            // 
            this.BtnInsertar.Location = new System.Drawing.Point(54, 285);
            this.BtnInsertar.Name = "BtnInsertar";
            this.BtnInsertar.Size = new System.Drawing.Size(76, 23);
            this.BtnInsertar.TabIndex = 0;
            this.BtnInsertar.Text = "Insertar";
            this.BtnInsertar.UseVisualStyleBackColor = true;
            this.BtnInsertar.Click += new System.EventHandler(this.BtnInsertar_Click);
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Location = new System.Drawing.Point(136, 285);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(76, 23);
            this.BtnActualizar.TabIndex = 1;
            this.BtnActualizar.Text = "Actualizar";
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(218, 285);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(76, 23);
            this.BtnEliminar.TabIndex = 2;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombres";
            // 
            // TxtNom
            // 
            this.TxtNom.Location = new System.Drawing.Point(15, 57);
            this.TxtNom.Name = "TxtNom";
            this.TxtNom.Size = new System.Drawing.Size(169, 20);
            this.TxtNom.TabIndex = 5;
            // 
            // TxtId
            // 
            this.TxtId.Location = new System.Drawing.Point(36, 12);
            this.TxtId.Name = "TxtId";
            this.TxtId.Size = new System.Drawing.Size(41, 20);
            this.TxtId.TabIndex = 6;
            // 
            // BtnAyudaApe
            // 
            this.BtnAyudaApe.Location = new System.Drawing.Point(396, 55);
            this.BtnAyudaApe.Name = "BtnAyudaApe";
            this.BtnAyudaApe.Size = new System.Drawing.Size(25, 23);
            this.BtnAyudaApe.TabIndex = 8;
            this.BtnAyudaApe.Text = "...";
            this.BtnAyudaApe.UseVisualStyleBackColor = true;
            this.BtnAyudaApe.Click += new System.EventHandler(this.BtnAyudaApe_Click);
            // 
            // BtnAyudaNom
            // 
            this.BtnAyudaNom.Location = new System.Drawing.Point(190, 55);
            this.BtnAyudaNom.Name = "BtnAyudaNom";
            this.BtnAyudaNom.Size = new System.Drawing.Size(25, 23);
            this.BtnAyudaNom.TabIndex = 9;
            this.BtnAyudaNom.Text = "...";
            this.BtnAyudaNom.UseVisualStyleBackColor = true;
            this.BtnAyudaNom.Click += new System.EventHandler(this.BtnAyudaNom_Click);
            // 
            // TxtApe
            // 
            this.TxtApe.Location = new System.Drawing.Point(221, 57);
            this.TxtApe.Name = "TxtApe";
            this.TxtApe.Size = new System.Drawing.Size(169, 20);
            this.TxtApe.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Apellidos";
            // 
            // TxtUsr
            // 
            this.TxtUsr.Location = new System.Drawing.Point(15, 96);
            this.TxtUsr.Name = "TxtUsr";
            this.TxtUsr.Size = new System.Drawing.Size(329, 20);
            this.TxtUsr.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Nombre de usuario";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(347, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "@isur.edu.pe";
            // 
            // TxtVer
            // 
            this.TxtVer.Location = new System.Drawing.Point(221, 136);
            this.TxtVer.Name = "TxtVer";
            this.TxtVer.PasswordChar = '*';
            this.TxtVer.Size = new System.Drawing.Size(200, 20);
            this.TxtVer.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(218, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Confirmación";
            // 
            // TxtCon
            // 
            this.TxtCon.Location = new System.Drawing.Point(15, 135);
            this.TxtCon.Name = "TxtCon";
            this.TxtCon.PasswordChar = '*';
            this.TxtCon.Size = new System.Drawing.Size(200, 20);
            this.TxtCon.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Contraseña";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 77;
            this.label8.Text = "Pais";
            // 
            // CmbPai
            // 
            this.CmbPai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPai.FormattingEnabled = true;
            this.CmbPai.Location = new System.Drawing.Point(16, 174);
            this.CmbPai.Name = "CmbPai";
            this.CmbPai.Size = new System.Drawing.Size(199, 21);
            this.CmbPai.TabIndex = 76;
            this.CmbPai.Tag = "HO";
            // 
            // TxtCel
            // 
            this.TxtCel.Location = new System.Drawing.Point(221, 174);
            this.TxtCel.Name = "TxtCel";
            this.TxtCel.Size = new System.Drawing.Size(200, 20);
            this.TxtCel.TabIndex = 79;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(218, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 78;
            this.label9.Text = "Teléfono";
            // 
            // TxtCor
            // 
            this.TxtCor.Location = new System.Drawing.Point(16, 214);
            this.TxtCor.Name = "TxtCor";
            this.TxtCor.Size = new System.Drawing.Size(405, 20);
            this.TxtCor.TabIndex = 81;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(235, 13);
            this.label10.TabIndex = 80;
            this.label10.Text = "Dirección de correo electrónico de recuperación";
            // 
            // DtpNac
            // 
            this.DtpNac.CustomFormat = "dd/MM/yyyy";
            this.DtpNac.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpNac.Location = new System.Drawing.Point(16, 253);
            this.DtpNac.Name = "DtpNac";
            this.DtpNac.Size = new System.Drawing.Size(96, 20);
            this.DtpNac.TabIndex = 82;
            this.DtpNac.Tag = "L";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(13, 237);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 13);
            this.label11.TabIndex = 83;
            this.label11.Text = "Fecha de Nacimiento";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(218, 237);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 85;
            this.label12.Text = "Sexo";
            // 
            // CmbSex
            // 
            this.CmbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSex.FormattingEnabled = true;
            this.CmbSex.Location = new System.Drawing.Point(221, 253);
            this.CmbSex.Name = "CmbSex";
            this.CmbSex.Size = new System.Drawing.Size(199, 21);
            this.CmbSex.TabIndex = 84;
            this.CmbSex.Tag = "HO";
            // 
            // BtnSincronizar
            // 
            this.BtnSincronizar.Location = new System.Drawing.Point(300, 285);
            this.BtnSincronizar.Name = "BtnSincronizar";
            this.BtnSincronizar.Size = new System.Drawing.Size(76, 23);
            this.BtnSincronizar.TabIndex = 86;
            this.BtnSincronizar.Text = "Sincronizar";
            this.BtnSincronizar.UseVisualStyleBackColor = true;
            this.BtnSincronizar.Click += new System.EventHandler(this.BtnSincronizar_Click);
            // 
            // FrmPregunta2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 318);
            this.Controls.Add(this.BtnSincronizar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.CmbSex);
            this.Controls.Add(this.DtpNac);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TxtCor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TxtCel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CmbPai);
            this.Controls.Add(this.TxtVer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtCon);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtUsr);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtApe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnAyudaNom);
            this.Controls.Add(this.BtnAyudaApe);
            this.Controls.Add(this.TxtId);
            this.Controls.Add(this.TxtNom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnActualizar);
            this.Controls.Add(this.BtnInsertar);
            this.Name = "FrmPregunta2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Usuarios (Desconectado)";
            this.Load += new System.EventHandler(this.FrmPregunta2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnInsertar;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtNom;
        private System.Windows.Forms.TextBox TxtId;
        private System.Windows.Forms.Button BtnAyudaApe;
        private System.Windows.Forms.Button BtnAyudaNom;
        private System.Windows.Forms.TextBox TxtApe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtUsr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtVer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtCon;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.ComboBox CmbPai;
        private System.Windows.Forms.TextBox TxtCel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtCor;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.DateTimePicker DtpNac;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.ComboBox CmbSex;
        private System.Windows.Forms.Button BtnSincronizar;
    }
}

