﻿namespace PracticaCalificada
{
    partial class FrmReceta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.BtnInsertar = new System.Windows.Forms.Button();
            this.BtnAyudaMed = new System.Windows.Forms.Button();
            this.TxtNomMed = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.DtpFec = new System.Windows.Forms.DateTimePicker();
            this.Label2 = new System.Windows.Forms.Label();
            this.TxtID = new System.Windows.Forms.TextBox();
            this.LblClave = new System.Windows.Forms.Label();
            this.TxtIDMed = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtInd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtCant = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtIdProd = new System.Windows.Forms.TextBox();
            this.BtnAyudaProd = new System.Windows.Forms.Button();
            this.TxtNomProd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnItemEliminar = new System.Windows.Forms.Button();
            this.BtnItemActualizar = new System.Windows.Forms.Button();
            this.BtnItemInsertar = new System.Windows.Forms.Button();
            this.DgvDetalle = new System.Windows.Forms.DataGridView();
            this.BtnAyudaRec = new System.Windows.Forms.Button();
            this.TxtIDPac = new System.Windows.Forms.TextBox();
            this.BtnAyudaPac = new System.Windows.Forms.Button();
            this.TxtNomPac = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnEliminar.Location = new System.Drawing.Point(497, 511);
            this.BtnEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(100, 28);
            this.BtnEliminar.TabIndex = 38;
            this.BtnEliminar.Tag = "H";
            this.BtnEliminar.Text = "&Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnActualizar.Location = new System.Drawing.Point(389, 511);
            this.BtnActualizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(100, 28);
            this.BtnActualizar.TabIndex = 37;
            this.BtnActualizar.Tag = "H";
            this.BtnActualizar.Text = "&Actualizar";
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnGrabar_Click);
            // 
            // BtnInsertar
            // 
            this.BtnInsertar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnInsertar.Location = new System.Drawing.Point(281, 511);
            this.BtnInsertar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnInsertar.Name = "BtnInsertar";
            this.BtnInsertar.Size = new System.Drawing.Size(100, 28);
            this.BtnInsertar.TabIndex = 36;
            this.BtnInsertar.Tag = "H";
            this.BtnInsertar.Text = "&Insertar";
            this.BtnInsertar.UseVisualStyleBackColor = true;
            this.BtnInsertar.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnAyudaMed
            // 
            this.BtnAyudaMed.Location = new System.Drawing.Point(696, 44);
            this.BtnAyudaMed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnAyudaMed.Name = "BtnAyudaMed";
            this.BtnAyudaMed.Size = new System.Drawing.Size(32, 25);
            this.BtnAyudaMed.TabIndex = 74;
            this.BtnAyudaMed.TabStop = false;
            this.BtnAyudaMed.Tag = "H";
            this.BtnAyudaMed.Text = "...";
            this.BtnAyudaMed.UseVisualStyleBackColor = true;
            this.BtnAyudaMed.Click += new System.EventHandler(this.BtnAyudaTrab_Click);
            // 
            // TxtNomMed
            // 
            this.TxtNomMed.Location = new System.Drawing.Point(195, 46);
            this.TxtNomMed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtNomMed.MaxLength = 300;
            this.TxtNomMed.Name = "TxtNomMed";
            this.TxtNomMed.Size = new System.Drawing.Size(492, 22);
            this.TxtNomMed.TabIndex = 73;
            this.TxtNomMed.Tag = "HOL";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(16, 49);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(53, 17);
            this.Label6.TabIndex = 78;
            this.Label6.Text = "Médico";
            // 
            // DtpFec
            // 
            this.DtpFec.CustomFormat = "dd/MM/yyyy";
            this.DtpFec.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpFec.Location = new System.Drawing.Point(296, 14);
            this.DtpFec.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DtpFec.Name = "DtpFec";
            this.DtpFec.Size = new System.Drawing.Size(127, 22);
            this.DtpFec.TabIndex = 72;
            this.DtpFec.Tag = "L";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(232, 18);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(47, 17);
            this.Label2.TabIndex = 77;
            this.Label2.Text = "Fecha";
            // 
            // TxtID
            // 
            this.TxtID.Location = new System.Drawing.Point(83, 15);
            this.TxtID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtID.MaxLength = 300;
            this.TxtID.Name = "TxtID";
            this.TxtID.Size = new System.Drawing.Size(84, 22);
            this.TxtID.TabIndex = 71;
            this.TxtID.Tag = "HL";
            // 
            // LblClave
            // 
            this.LblClave.AutoSize = true;
            this.LblClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblClave.Location = new System.Drawing.Point(16, 18);
            this.LblClave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblClave.Name = "LblClave";
            this.LblClave.Size = new System.Drawing.Size(58, 17);
            this.LblClave.TabIndex = 76;
            this.LblClave.Text = "Número";
            // 
            // TxtIDMed
            // 
            this.TxtIDMed.Location = new System.Drawing.Point(101, 46);
            this.TxtIDMed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtIDMed.MaxLength = 300;
            this.TxtIDMed.Name = "TxtIDMed";
            this.TxtIDMed.Size = new System.Drawing.Size(84, 22);
            this.TxtIDMed.TabIndex = 79;
            this.TxtIDMed.Tag = "HL";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtInd);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtCant);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtIdProd);
            this.groupBox1.Controls.Add(this.BtnAyudaProd);
            this.groupBox1.Controls.Add(this.TxtNomProd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BtnItemEliminar);
            this.groupBox1.Controls.Add(this.BtnItemActualizar);
            this.groupBox1.Controls.Add(this.BtnItemInsertar);
            this.groupBox1.Controls.Add(this.DgvDetalle);
            this.groupBox1.Location = new System.Drawing.Point(16, 110);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(868, 389);
            this.groupBox1.TabIndex = 84;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalles";
            // 
            // TxtInd
            // 
            this.TxtInd.Location = new System.Drawing.Point(105, 55);
            this.TxtInd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtInd.MaxLength = 300;
            this.TxtInd.Multiline = true;
            this.TxtInd.Name = "TxtInd";
            this.TxtInd.Size = new System.Drawing.Size(657, 96);
            this.TxtInd.TabIndex = 103;
            this.TxtInd.Tag = "HL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 59);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 102;
            this.label4.Text = "Indicaciones";
            // 
            // TxtCant
            // 
            this.TxtCant.Location = new System.Drawing.Point(772, 23);
            this.TxtCant.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtCant.MaxLength = 300;
            this.TxtCant.Name = "TxtCant";
            this.TxtCant.Size = new System.Drawing.Size(84, 22);
            this.TxtCant.TabIndex = 101;
            this.TxtCant.Tag = "HL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(699, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 100;
            this.label3.Text = "Cantidad";
            // 
            // TxtIdProd
            // 
            this.TxtIdProd.Location = new System.Drawing.Point(93, 23);
            this.TxtIdProd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtIdProd.MaxLength = 300;
            this.TxtIdProd.Name = "TxtIdProd";
            this.TxtIdProd.Size = new System.Drawing.Size(84, 22);
            this.TxtIdProd.TabIndex = 99;
            this.TxtIdProd.Tag = "HL";
            // 
            // BtnAyudaProd
            // 
            this.BtnAyudaProd.Location = new System.Drawing.Point(659, 22);
            this.BtnAyudaProd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnAyudaProd.Name = "BtnAyudaProd";
            this.BtnAyudaProd.Size = new System.Drawing.Size(32, 25);
            this.BtnAyudaProd.TabIndex = 97;
            this.BtnAyudaProd.TabStop = false;
            this.BtnAyudaProd.Tag = "H";
            this.BtnAyudaProd.Text = "...";
            this.BtnAyudaProd.UseVisualStyleBackColor = true;
            this.BtnAyudaProd.Click += new System.EventHandler(this.BtnAyudaProd_Click);
            // 
            // TxtNomProd
            // 
            this.TxtNomProd.Location = new System.Drawing.Point(187, 23);
            this.TxtNomProd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtNomProd.MaxLength = 300;
            this.TxtNomProd.Name = "TxtNomProd";
            this.TxtNomProd.Size = new System.Drawing.Size(463, 22);
            this.TxtNomProd.TabIndex = 96;
            this.TxtNomProd.Tag = "HOL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 98;
            this.label1.Text = "Producto";
            // 
            // BtnItemEliminar
            // 
            this.BtnItemEliminar.Location = new System.Drawing.Point(776, 231);
            this.BtnItemEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnItemEliminar.Name = "BtnItemEliminar";
            this.BtnItemEliminar.Size = new System.Drawing.Size(81, 28);
            this.BtnItemEliminar.TabIndex = 95;
            this.BtnItemEliminar.Text = "Eliminar";
            this.BtnItemEliminar.UseVisualStyleBackColor = true;
            this.BtnItemEliminar.Click += new System.EventHandler(this.BtnItemEliminar_Click);
            // 
            // BtnItemActualizar
            // 
            this.BtnItemActualizar.Location = new System.Drawing.Point(776, 196);
            this.BtnItemActualizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnItemActualizar.Name = "BtnItemActualizar";
            this.BtnItemActualizar.Size = new System.Drawing.Size(81, 28);
            this.BtnItemActualizar.TabIndex = 94;
            this.BtnItemActualizar.Text = "Actualizar";
            this.BtnItemActualizar.UseVisualStyleBackColor = true;
            this.BtnItemActualizar.Click += new System.EventHandler(this.BtnItemActualizar_Click);
            // 
            // BtnItemInsertar
            // 
            this.BtnItemInsertar.Location = new System.Drawing.Point(776, 160);
            this.BtnItemInsertar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnItemInsertar.Name = "BtnItemInsertar";
            this.BtnItemInsertar.Size = new System.Drawing.Size(81, 28);
            this.BtnItemInsertar.TabIndex = 93;
            this.BtnItemInsertar.Text = "Agregar";
            this.BtnItemInsertar.UseVisualStyleBackColor = true;
            this.BtnItemInsertar.Click += new System.EventHandler(this.BtnItemInsertar_Click);
            // 
            // DgvDetalle
            // 
            this.DgvDetalle.AllowDrop = true;
            this.DgvDetalle.AllowUserToAddRows = false;
            this.DgvDetalle.AllowUserToDeleteRows = false;
            this.DgvDetalle.AllowUserToResizeColumns = false;
            this.DgvDetalle.AllowUserToResizeRows = false;
            this.DgvDetalle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvDetalle.ColumnHeadersHeight = 29;
            this.DgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvDetalle.Location = new System.Drawing.Point(8, 160);
            this.DgvDetalle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DgvDetalle.MultiSelect = false;
            this.DgvDetalle.Name = "DgvDetalle";
            this.DgvDetalle.ReadOnly = true;
            this.DgvDetalle.RowHeadersWidth = 51;
            this.DgvDetalle.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvDetalle.Size = new System.Drawing.Size(760, 219);
            this.DgvDetalle.TabIndex = 84;
            this.DgvDetalle.Tag = "HOL";
            this.DgvDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDetalle_CellContentClick);
            this.DgvDetalle.DoubleClick += new System.EventHandler(this.DgvDetalle_DoubleClick);
            // 
            // BtnAyudaRec
            // 
            this.BtnAyudaRec.Location = new System.Drawing.Point(176, 15);
            this.BtnAyudaRec.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnAyudaRec.Name = "BtnAyudaRec";
            this.BtnAyudaRec.Size = new System.Drawing.Size(32, 25);
            this.BtnAyudaRec.TabIndex = 85;
            this.BtnAyudaRec.TabStop = false;
            this.BtnAyudaRec.Tag = "H";
            this.BtnAyudaRec.Text = "...";
            this.BtnAyudaRec.UseVisualStyleBackColor = true;
            this.BtnAyudaRec.Click += new System.EventHandler(this.BtnAyudaCon_Click);
            // 
            // TxtIDPac
            // 
            this.TxtIDPac.Location = new System.Drawing.Point(101, 78);
            this.TxtIDPac.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtIDPac.MaxLength = 300;
            this.TxtIDPac.Name = "TxtIDPac";
            this.TxtIDPac.Size = new System.Drawing.Size(84, 22);
            this.TxtIDPac.TabIndex = 89;
            this.TxtIDPac.Tag = "HL";
            // 
            // BtnAyudaPac
            // 
            this.BtnAyudaPac.Location = new System.Drawing.Point(696, 76);
            this.BtnAyudaPac.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnAyudaPac.Name = "BtnAyudaPac";
            this.BtnAyudaPac.Size = new System.Drawing.Size(32, 25);
            this.BtnAyudaPac.TabIndex = 87;
            this.BtnAyudaPac.TabStop = false;
            this.BtnAyudaPac.Tag = "H";
            this.BtnAyudaPac.Text = "...";
            this.BtnAyudaPac.UseVisualStyleBackColor = true;
            this.BtnAyudaPac.Click += new System.EventHandler(this.BtnAyudaPac_Click);
            // 
            // TxtNomPac
            // 
            this.TxtNomPac.Location = new System.Drawing.Point(195, 78);
            this.TxtNomPac.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtNomPac.MaxLength = 300;
            this.TxtNomPac.Name = "TxtNomPac";
            this.TxtNomPac.Size = new System.Drawing.Size(492, 22);
            this.TxtNomPac.TabIndex = 86;
            this.TxtNomPac.Tag = "HOL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 81);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 17);
            this.label5.TabIndex = 88;
            this.label5.Text = "Paciente";
            // 
            // FrmReceta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 554);
            this.Controls.Add(this.TxtIDPac);
            this.Controls.Add(this.BtnAyudaPac);
            this.Controls.Add(this.TxtNomPac);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnAyudaRec);
            this.Controls.Add(this.TxtIDMed);
            this.Controls.Add(this.BtnAyudaMed);
            this.Controls.Add(this.TxtNomMed);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.DtpFec);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.TxtID);
            this.Controls.Add(this.LblClave);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnActualizar);
            this.Controls.Add(this.BtnInsertar);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmReceta";
            this.Text = "Receta";
            this.Load += new System.EventHandler(this.FrmPregunta1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button BtnEliminar;
        internal System.Windows.Forms.Button BtnActualizar;
        internal System.Windows.Forms.Button BtnInsertar;
        internal System.Windows.Forms.Button BtnAyudaMed;
        internal System.Windows.Forms.TextBox TxtNomMed;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.DateTimePicker DtpFec;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox TxtID;
        internal System.Windows.Forms.Label LblClave;
        internal System.Windows.Forms.TextBox TxtIDMed;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.DataGridView DgvDetalle;
        internal System.Windows.Forms.Button BtnAyudaRec;
        internal System.Windows.Forms.Button BtnItemEliminar;
        internal System.Windows.Forms.Button BtnItemActualizar;
        internal System.Windows.Forms.Button BtnItemInsertar;
        internal System.Windows.Forms.TextBox TxtIDPac;
        internal System.Windows.Forms.Button BtnAyudaPac;
        internal System.Windows.Forms.TextBox TxtNomPac;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox TxtIdProd;
        internal System.Windows.Forms.Button BtnAyudaProd;
        internal System.Windows.Forms.TextBox TxtNomProd;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox TxtCant;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox TxtInd;
        internal System.Windows.Forms.Label label4;
    }
}