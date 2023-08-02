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
    public partial class FrmText : Form
    {
        SqlConnection objConexion = new SqlConnection();
        SqlCommand objComando = new SqlCommand();
        public FrmText()
        {
            InitializeComponent();
        }

        private void FrmText_Load(object sender, EventArgs e)
        {
            try
            {
                objConexion.ConnectionString = "Server=.;Database=Lab_TAD;Integrated Security=true;";
                objConexion.Open();
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
                objComando.CommandText = "insert into producto (prod_nombre, prod_marca, prod_modelo) values ('" + TxtNombre.Text + "')";
                objComando.CommandType = CommandType.Text;
                objComando.Connection = objConexion;
                objComando.Parameters.Clear();
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
                objComando.CommandText = "update producto set prod_nombre = '" + TxtNombre.Text + "' where prod_id = " + TxtID.Text;
                objComando.CommandType = CommandType.Text;
                objComando.Connection = objConexion;
                objComando.Parameters.Clear();
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
                objComando.CommandText = "delete from producto where prod_id = " + TxtID.Text;
                objComando.CommandType = CommandType.Text;
                objComando.Connection = objConexion;
                objComando.Parameters.Clear();
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
