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

namespace LabDataSet
{
    public partial class FrmBusqueda : Form
    {
        public DataGridViewRow objRow;

        public FrmBusqueda()
        {
            InitializeComponent();
        }

        public FrmBusqueda(SqlDataReader objDR, string lsTitulo)
        {
            InitializeComponent();
            try
            {
                DataTable objTabla = new DataTable();
                this.Text = lsTitulo;
                objTabla.Load(objDR, LoadOption.OverwriteChanges);
                dataGridView1.DataSource = objTabla;                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Sobrecarga de constructor para el form con DataSet
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
            //try
            //{
            //    DataTable objTabla = new DataTable();
            //    objTabla.Load(objDR, LoadOption.OverwriteChanges);
            //    dataGridView1.DataSource = objTabla;
            //}
            //catch (SqlException sqlex)
            //{
            //    MessageBox.Show(sqlex.Message);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
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
