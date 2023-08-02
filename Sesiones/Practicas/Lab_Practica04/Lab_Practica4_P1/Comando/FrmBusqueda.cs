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

namespace Comando
{
    public partial class FrmBusqueda : Form
    {
        public SqlDataReader objDR;
        public DataGridViewRow objRow;

        public FrmBusqueda()
        {
            InitializeComponent();
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

        private void FrmBusqueda_Load(object sender, EventArgs e)
        {
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
    }
}
