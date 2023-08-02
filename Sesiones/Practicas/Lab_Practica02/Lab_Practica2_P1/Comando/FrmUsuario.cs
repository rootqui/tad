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
    public partial class FrmUsuario : Form
    {
        SqlConnection objConexion = new SqlConnection();
        SqlCommand objComando = new SqlCommand();

        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void FrmText_Load(object sender, EventArgs e)
        {
            try
            {
                objConexion.ConnectionString = "Server=.;Database=TAD2020II;Integrated Security=SSPI;";
                objComando.Connection = objConexion;
                objComando.CommandType = CommandType.StoredProcedure;
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
                objComando.CommandText = "Insertar_Usuario";
                objComando.Parameters.Clear();
                objComando.Parameters.AddWithValue("@USUA_CORREO", TxtCorreo.Text);
                objComando.Parameters.AddWithValue("@USUA_CLAVE", TxtClave.Text);
                objComando.Parameters.AddWithValue("@USUA_NOMBRE", TxtNombre.Text);
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
                objComando.CommandText = "Actualizar_Usuario";
                objComando.Parameters.Clear();
                objComando.Parameters.AddWithValue("@USUA_ID", TxtID.Text);
                objComando.Parameters.AddWithValue("@USUA_CORREO", TxtCorreo.Text);
                objComando.Parameters.AddWithValue("@USUA_CLAVE", TxtClave.Text);
                objComando.Parameters.AddWithValue("@USUA_NOMBRE", TxtNombre.Text);
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
                objComando.CommandText = "Eliminar_Usuario";
                objComando.Parameters.Clear();
                objComando.Parameters.AddWithValue("@USUA_ID", TxtID.Text);
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

        private void BtnAyudaID_Click(object sender, EventArgs e)
        {
            try
            {
                //Implementar busquea con SP: Ayuda_Usuarios y cargar registro de usuario seleccionado
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

        private void BtnAyudaCorreo_Click(object sender, EventArgs e)
        {
            try
            {
                //Implementar busquea con SP: Ayuda_Usuarios_Correo y cargar registro de usuario seleccionado

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

        private void BtnAyudaNombre_Click(object sender, EventArgs e)
        {
            try
            {
                //Implementar busquea con SP: Ayuda_Usuarios_Nombre y cargar registro de usuario seleccionado

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
