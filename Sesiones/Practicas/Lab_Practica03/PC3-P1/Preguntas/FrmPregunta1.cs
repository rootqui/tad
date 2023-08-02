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
namespace PC3_P1
{
    public partial class FrmPregunta1 : Form
    {
        SqlConnection objConexion = new SqlConnection();
        SqlCommand objComando = new SqlCommand();
        SqlDataReader objDataReader;

        public FrmPregunta1()
        {
            InitializeComponent();
        }

        private void FrmPregunta1_Load(object sender, EventArgs e)
        {
            try
            {
                objConexion.ConnectionString = "Server=.;Database=PC3_P1;Integrated Security=SSPI;";
                objComando.Connection = objConexion;
                objComando.CommandType = CommandType.StoredProcedure;
            }catch(Exception ex)
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

                
                if (TxtCon.Text.Equals(TxtVer.Text))
                {
                    objComando.Parameters.AddWithValue("@USUA_NOMBRE", TxtNom.Text);
                    objComando.Parameters.AddWithValue("@USUA_APELLIDO", TxtApe.Text);
                    objComando.Parameters.AddWithValue("@USUA_CORREO", TxtUsr.Text + "@isur.edu.pe");
                    objComando.Parameters.AddWithValue("@USUA_CONTRASENA", TxtCon.Text);
                    objComando.Parameters.AddWithValue("@USUA_CELULAR", TxtCel.Text);
                    objComando.Parameters.AddWithValue("@USUA_CORREO_RECUPERACION", TxtCor.Text);
                    objConexion.Open();
                    objComando.ExecuteNonQuery();
                    MessageBox.Show("El registro se insertó", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                objComando.CommandText = "Actualizar_Usuario";
                objComando.Parameters.Clear();

                if (TxtCon.Text.Equals(TxtVer.Text))
                {
                    objComando.Parameters.AddWithValue("@USUA_ID", TxtId.Text);
                    objComando.Parameters.AddWithValue("@USUA_NOMBRE", TxtNom.Text);
                    objComando.Parameters.AddWithValue("@USUA_APELLIDO", TxtApe.Text);
                    objComando.Parameters.AddWithValue("@USUA_CORREO", TxtUsr.Text + "@isur.edu.pe");
                    objComando.Parameters.AddWithValue("@USUA_CONTRASENA", TxtCon.Text);
                    objComando.Parameters.AddWithValue("@USUA_CELULAR", TxtCel.Text);
                    objComando.Parameters.AddWithValue("@USUA_CORREO_RECUPERACION", TxtCor.Text);
                    objConexion.Open();
                    objComando.ExecuteNonQuery();

                    MessageBox.Show("El registro se actualizó.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                objComando.CommandText = "Eliminar_Usuario";
                objComando.Parameters.Clear();
                objComando.Parameters.AddWithValue("@USUA_ID", TxtId.Text);
                objConexion.Open();
                objComando.ExecuteNonQuery();

                MessageBox.Show("El registro se eliminó.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void BtnAyudaApe_Click(object sender, EventArgs e)
        {
            try
            {
                objComando.CommandText = "Ayuda_UsuarioCorreo_Apellido";
                objComando.Parameters.Clear();
                objComando.Parameters.AddWithValue("@USUA_APELLIDO",TxtApe.Text);
                objConexion.Open();
                objDataReader = objComando.ExecuteReader();
                FrmBusqueda objAyuda = new FrmBusqueda(objDataReader, "Busqueda por Apellidos");
                objAyuda.objDR = objDataReader;
                objAyuda.ShowDialog(this);

                if (objAyuda.objRow != null)
                {
                    int id = Convert.ToInt32(objAyuda.objRow.Cells["USUA_ID"].Value);
                    objComando.CommandText = "Seleccionar_Usuario";
                    objComando.Parameters.Clear();
                    objComando.Parameters.AddWithValue("@USUA_ID",id);
                    objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {
                        objDataReader.Read();
                        TxtId.Text = objDataReader.GetValue(objDataReader.GetOrdinal("USUA_ID")).ToString();
                        TxtNom.Text = objDataReader.GetValue(objDataReader.GetOrdinal("USUA_NOMBRE")).ToString();
                        TxtApe.Text = objDataReader.GetValue(objDataReader.GetOrdinal("USUA_APELLIDO")).ToString();
                        TxtUsr.Text = objDataReader.GetValue(objDataReader.GetOrdinal("USUA_CORREO")).ToString().Split('@')[0];
                        TxtCel.Text = objDataReader.GetValue(objDataReader.GetOrdinal("USUA_CELULAR")).ToString();
                        TxtCor.Text = objDataReader.GetValue(objDataReader.GetOrdinal("USUA_CORREO_RECUPERACION")).ToString();

                    }

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

        private void BtnAyudaNom_Click(object sender, EventArgs e)
        {
            try
            {
                objComando.CommandText = "Ayuda_UsuarioCorreo_Nombre";
                objComando.Parameters.Clear();
                objComando.Parameters.AddWithValue("@USUA_NOMBRE",TxtNom.Text);
                objConexion.Open();
                objDataReader = objComando.ExecuteReader();
                FrmBusqueda objAyuda = new FrmBusqueda(objDataReader, "Busqueda por Nombres");
                objAyuda.objDR = objDataReader;
                objAyuda.ShowDialog(this);

                if (objAyuda.objRow != null)
                {
                    int id = Convert.ToInt32(objAyuda.objRow.Cells["USUA_ID"].Value);
                    objComando.CommandText = "Seleccionar_Usuario";
                    objComando.Parameters.Clear();
                    objComando.Parameters.AddWithValue("@USUA_ID", id);
                    objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {
                        objDataReader.Read();
                        TxtId.Text = objDataReader.GetValue(objDataReader.GetOrdinal("USUA_ID")).ToString();
                        TxtNom.Text = objDataReader.GetValue(objDataReader.GetOrdinal("USUA_NOMBRE")).ToString();
                        TxtApe.Text = objDataReader.GetValue(objDataReader.GetOrdinal("USUA_APELLIDO")).ToString();
                        TxtUsr.Text = objDataReader.GetValue(objDataReader.GetOrdinal("USUA_CORREO")).ToString().Split('@')[0];
                        TxtCel.Text = objDataReader.GetValue(objDataReader.GetOrdinal("USUA_CELULAR")).ToString();
                        TxtCor.Text = objDataReader.GetValue(objDataReader.GetOrdinal("USUA_CORREO_RECUPERACION")).ToString();

                    }

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
