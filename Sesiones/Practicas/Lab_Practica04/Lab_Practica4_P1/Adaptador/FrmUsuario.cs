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

namespace Adaptador
{
    public partial class FrmUsuario : Form
    {
        SqlConnection objConexion = new SqlConnection();

        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void FrmText_Load(object sender, EventArgs e)
        {
            try
            {
                objConexion.ConnectionString = "Server=.;Database=TAD2020II;Integrated Security=SSPI;";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {

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

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {

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

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

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


        private void DgvUsuario_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvUsuario.SelectedRows.Count != 0)
            {
                
            }
        }

        private void BtnSincronizar_Click(object sender, EventArgs e)
        {
            try
            {
                
                MessageBox.Show("Los registros han sido sincronizados", "Notificación");
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
