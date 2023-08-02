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
                objConexion.ConnectionString = "Server=.;Database=Lab_TAD;Integrated Security=SSPI;";
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
//                SqlCommand objComando = new SqlCommand();
                objComando.CommandText = "Insertar_Producto";
//                objComando.Connection = objConexion;
//                objComando.CommandType = CommandType.StoredProcedure;

                objComando.Parameters.Clear();
                objComando.Parameters.AddWithValue("@PROD_NOMBRE",TxtNombre.Text);
                //objComando.Parameters.Add();
                //objComando.Parameters.AddRange

                objConexion.Open();
                objComando.ExecuteNonQuery(); //¨Para Insertar, Actualizar y Eliminar 
                objConexion.Close();
                //objComando.ExecuteReader(); //¨Para Seleccionar

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
            //finally
            //{
            //    objConexion.Close();
            //}
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

        private void BtnAyuda_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader ObjLector;
                objComando.CommandText = "Ayuda_Producto_LikeNombre";
                objComando.Parameters.Clear();
                objComando.Parameters.AddWithValue("@PROD_NOMBRE",TxtNombre.Text);
                objConexion.Open();
                ObjLector = objComando.ExecuteReader(); 

                FrmBusqueda objAyuda = new FrmBusqueda();
                
                objAyuda.objDR = ObjLector;

                objAyuda.ShowDialog(this);

                if (objAyuda.objRow != null)
                {
                    objComando.CommandText = "Seleccionar_UnProducto";
                    objComando.Parameters.Clear();
                    objComando.Parameters.AddWithValue("@PROD_ID", objAyuda.objRow.Cells[0].Value);
                    ObjLector = objComando.ExecuteReader();
                    ObjLector.Read();
                    //TxtID.Text = ObjLector.GetValue(0).ToString();
                    //TxtNombre.Text = ObjLector.GetValue(1).ToString(); 
                    TxtID.Text = ObjLector.GetValue(ObjLector.GetOrdinal("PROD_ID")).ToString();
                    TxtNombre.Text = ObjLector.GetValue(ObjLector.GetOrdinal("PROD_NOMBRE")).ToString();
                }

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
