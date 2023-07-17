using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PC3_P1
{
    public partial class FrmBusqueda : Form
    {
        public DataGridViewRow objRow;
        public SqlDataReader objDR;

        public FrmBusqueda()
        {
            InitializeComponent();
        }


        // Construcctor para la ventana de Ayuda, que permita un objeto de tipo SqlDataReader 
        public FrmBusqueda(SqlDataReader objDR, string lsTitulo)
        {
            InitializeComponent();
            try
            {
                this.Text = lsTitulo;
                DataTable objTabla = new DataTable();
                objTabla.Load(objDR, LoadOption.OverwriteChanges);
                dataGridView1.DataSource = objTabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public FrmBusqueda(DataView objDataView, string lsTitulo)
        {
            InitializeComponent();
            try
            {
                this.Text = lsTitulo;
                dataGridView1.DataSource = objDataView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            objRow = dataGridView1.SelectedRows[0];
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            objRow = null;
            this.Close();
        }

       
    }
}
