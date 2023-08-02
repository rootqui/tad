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

namespace PracticaCalificada
{
    public partial class FrmBusqueda : Form
    {
        public DataGridViewRow objRow;
        public FrmBusqueda()
        {
            InitializeComponent();
        }

        public FrmBusqueda (object loQuery, string lsTitulo)
        {
            InitializeComponent();
            this.Text = lsTitulo;
            dataGridView1.DataSource = loQuery;
        }

        public FrmBusqueda(SqlDataReader objDR, string lsTitulo)
        {
            InitializeComponent();
            this.Text = lsTitulo;
            try
            {
                DataTable objTabla = new DataTable();
                objTabla.Load(objDR, LoadOption.OverwriteChanges);
                dataGridView1.DataSource = objTabla;
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
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

        private void Busqueda_Load(object sender, EventArgs e)
        {
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            objRow = null;
            this.Close();
        }

        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            objRow = dataGridView1.SelectedRows[0];
            this.Close();
        }
    }
}
