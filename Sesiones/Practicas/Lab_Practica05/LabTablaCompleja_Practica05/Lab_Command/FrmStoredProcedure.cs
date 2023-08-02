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

namespace Lab_Command
{
    public partial class FrmStoredProcedure : Form
    {
        SqlConnection objConexion = new SqlConnection();
        SqlCommand objComando = new SqlCommand();
        public FrmStoredProcedure()
        {
            InitializeComponent();
        }

        private void FrmText_Load(object sender, EventArgs e)
        {
            try
            {
                objConexion.ConnectionString = "Server=.;Database=Lab_TAD;Integrated Security=true;";
                objComando.CommandType = CommandType.StoredProcedure;
                objComando.Connection = objConexion;

                // app config
                // sqlconecconstringbuilder
                // etc
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                objComando.CommandText = "Insertar_Producto";
                objComando.Parameters.Clear();
                objComando.Parameters.AddWithValue("@PROD_NOMBRE", TxtNombre.Text);
                objConexion.Open();
                objComando.ExecuteNonQuery();  
                MessageBox.Show("El registro se insertó", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                objConexion.Close();
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                objComando.CommandText = "Actualizar_Producto";
                objComando.Parameters.Clear();
                objComando.Parameters.AddWithValue("@PROD_ID", TxtID.Text);
                objComando.Parameters.AddWithValue("@PROD_NOMBRE", TxtNombre.Text);
                objConexion.Open();
                objComando.ExecuteNonQuery(); 
                MessageBox.Show("El registro se actualizó", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                objConexion.Close();
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                objComando.CommandText = "Eliminar_Producto";
                objComando.Parameters.Clear();
                objComando.Parameters.AddWithValue("@PROD_ID", TxtID.Text);
                objConexion.Open();
                objComando.ExecuteNonQuery(); 
                MessageBox.Show("El registro se eliminó", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                objConexion.Close();
            }
        }
    }
}
