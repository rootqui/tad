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
    public partial class Busqueda : Form
    {
        public DataGridViewRow objRow;
        public Busqueda()
        {
            InitializeComponent();
        }

        public Busqueda (object loQuery, string lsTitulo)
        {
            InitializeComponent();
            this.Text = lsTitulo;
            dataGridView1.DataSource = loQuery;
        }

        public Busqueda(SqlDataReader objDR, string lsTitulo)
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
