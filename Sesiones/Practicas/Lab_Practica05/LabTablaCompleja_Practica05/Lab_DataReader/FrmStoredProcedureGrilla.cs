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

namespace Lab_DataReader
{
    public partial class FrmStoredProcedureGrilla : Form
    {
        SqlConnection objConexion = new SqlConnection();
        SqlCommand objComando = new SqlCommand();

        public FrmStoredProcedureGrilla()
        {
            InitializeComponent();
        }

        private void FrmText_Load(object sender, EventArgs e)
        {
            try
            {
                objConexion.ConnectionString = "Server=.;Database=Lab_TAD;Integrated Security=SSPI;";
                objComando.Connection = objConexion;
                objComando.CommandType = CommandType.StoredProcedure;

                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarGrilla()
        {
            try
            {
                SqlDataReader ObjLectorDatos;
                objComando.CommandText = "Seleccionar_Productos";
                objComando.Parameters.Clear();
                //objComando.ExecuteNonQuery(); //Insert, Update, Delete, no hay un retorno de un dataset
                objConexion.Open();
                ObjLectorDatos = objComando.ExecuteReader(); //Select

                //MessageBox.Show(ObjLectorDatos.HasRows.ToString());
                //MessageBox.Show(ObjLectorDatos.FieldCount.ToString());

                //if (ObjLectorDatos.HasRows)
                //{
                //    while (ObjLectorDatos.Read())
                //    {
                //        MessageBox.Show(ObjLectorDatos.GetValue(1).ToString());
                //    };
                //}

                DataTable ObjTabla = new DataTable();
                ObjTabla.Load(ObjLectorDatos, LoadOption.OverwriteChanges);

                DgvProducto.DataSource = ObjTabla;

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

        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                objComando.CommandText = "Insertar_Producto";

                objComando.Parameters.Clear();
                objComando.Parameters.AddWithValue("@PROD_NOMBRE",TxtNombre.Text);

                objConexion.Open();
                objComando.ExecuteNonQuery(); //¨Para Insertar, Actualizar y Eliminar 
                objConexion.Close();

                MessageBox.Show("El registro se insertó", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
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
                objConexion.Close();

                MessageBox.Show("El registro se actualizó", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
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
                objConexion.Close();
                MessageBox.Show("El registro se eliminó", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
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

        private void DgvProducto_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvProducto.SelectedRows.Count != 0)
            {
                TxtID.Text = DgvProducto.SelectedRows[0].Cells["PROD_ID"].Value.ToString();
                TxtNombre.Text = DgvProducto.SelectedRows[0].Cells["PROD_NOMBRE"].Value.ToString();
            }
        }
    }
}
