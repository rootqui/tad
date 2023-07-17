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

/*
El objeto DataSet es esencial para la compatibilidad con situaciones de datos distribuidos desconectados con ADO.NET. 
*/


namespace LabDataSet
{
    public partial class FrmUsuario : Form
    {
        SqlConnection objConexion = new SqlConnection();
        SqlDataAdapter objDA_Usuario_Correo = new SqlDataAdapter();
        SqlDataAdapter objDA_Sexo = new SqlDataAdapter();
        SqlDataAdapter objDA_Pais = new SqlDataAdapter();
        DataSet objDS = new DataSet();

        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void FrmPregunta2_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder objConstructorCadenaConexion = new SqlConnectionStringBuilder();
                objConstructorCadenaConexion.DataSource = ".";
                objConstructorCadenaConexion.InitialCatalog = "TAD2020II";
                objConstructorCadenaConexion.IntegratedSecurity = true;
                objConexion.ConnectionString = objConstructorCadenaConexion.ConnectionString;

                objDA_Usuario_Correo.SelectCommand = new SqlCommand("Seleccionar_Usuarios_Correo", objConexion);
                objDA_Usuario_Correo.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Para generar instrucciones INSERT, UPDATE o DELETE, SqlCommandBuilder usa la propiedad SelectCommand para recuperar automáticamente un conjunto requerido de metadatos.
                SqlCommandBuilder objConstructorCmdUsuarioCorreo = new SqlCommandBuilder(objDA_Usuario_Correo);

                objDA_Usuario_Correo.Fill(objDS, "usuariocorreo");

                objDA_Pais.SelectCommand = new SqlCommand("Seleccionar_Paises", objConexion);
                objDA_Pais.SelectCommand.CommandType = CommandType.StoredProcedure;

                objDA_Pais.Fill(objDS, "pais");

                objDA_Sexo.SelectCommand = new SqlCommand("Seleccionar_Sexos", objConexion);
                objDA_Sexo.SelectCommand.CommandType = CommandType.StoredProcedure;

                objDA_Sexo.Fill(objDS, "sexo");

                CmbPai.DataSource = objDS.Tables["pais"];
                CmbPai.ValueMember = "PAIS_ID";
                CmbPai.DisplayMember = "PAIS_NOMBRE";

                CmbSex.DataSource = objDS.Tables["sexo"];
                CmbSex.ValueMember = "SEXO_ID";
                CmbSex.DisplayMember = "SEXO_NOMBRE";

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

        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow DataRow_Usuario_Correo = objDS.Tables["usuariocorreo"].NewRow();
                DataRow_Usuario_Correo["USUA_ID"] = Convert.ToInt32(objDS.Tables["usuariocorreo"].Compute("max(USUA_ID)", string.Empty)) + 1;
                DataRow_Usuario_Correo["USUA_NOMBRE"] = TxtNom.Text;
                DataRow_Usuario_Correo["USUA_APELLIDO"] = TxtApe.Text;
                DataRow_Usuario_Correo["USUA_CORREO"] = TxtUsr.Text;
                DataRow_Usuario_Correo["USUA_CONTRASENA"] = TxtCon.Text;
                DataRow_Usuario_Correo["PAIS_ID"] = CmbPai.SelectedValue;
                DataRow_Usuario_Correo["USUA_CELULAR"] = TxtCel.Text;
                DataRow_Usuario_Correo["USUA_CORREO_RECUPERACION"] = TxtCor.Text;
                DataRow_Usuario_Correo["USUA_FECHA_NACIMIENTO"] = DtpNac.Text;
                DataRow_Usuario_Correo["SEXO_ID"] = CmbSex.SelectedValue;

                objDS.Tables["usuariocorreo"].Rows.Add(DataRow_Usuario_Correo);

                MessageBox.Show("El registro se insertó", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information );

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow DataRow_Usuario_Correo = objDS.Tables["usuariocorreo"].Select("USUA_ID = " + TxtId.Text)[0];
                DataRow_Usuario_Correo["USUA_NOMBRE"] = TxtNom.Text;
                DataRow_Usuario_Correo["USUA_APELLIDO"] = TxtApe.Text;
                DataRow_Usuario_Correo["USUA_CORREO"] = TxtUsr.Text;
                DataRow_Usuario_Correo["USUA_CONTRASENA"] = TxtCon.Text;
                DataRow_Usuario_Correo["PAIS_ID"] = CmbPai.SelectedValue;
                DataRow_Usuario_Correo["USUA_CELULAR"] = TxtCel.Text;
                DataRow_Usuario_Correo["USUA_CORREO_RECUPERACION"] = TxtCor.Text;
                DataRow_Usuario_Correo["USUA_FECHA_NACIMIENTO"] = DtpNac.Text;
                DataRow_Usuario_Correo["SEXO_ID"] = CmbSex.SelectedValue;

                MessageBox.Show("El registro se actualizó.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow DataRow_Usuario_Correo = objDS.Tables["usuariocorreo"].Select("USUA_ID = " + TxtId.Text)[0];
                DataRow_Usuario_Correo.Delete();
                MessageBox.Show("El registro se eliminó.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }
        }

        private void BtnAyudaApe_Click(object sender, EventArgs e)
        {
            try
            {
                DataView objDataView_Usuario_Correo = objDS.Tables["usuariocorreo"].DefaultView;
                objDataView_Usuario_Correo.RowFilter = "USUA_APELLIDO LIKE '%" + TxtApe.Text + "%'";
                FrmBusqueda objAyuda = new FrmBusqueda(objDataView_Usuario_Correo, "Ayuda Apellido");
                objAyuda.ShowDialog(this);
                if (objAyuda.objRow != null)
                {
                    int ID = Convert.ToInt32(objAyuda.objRow.Cells["USUA_ID"].Value);
                    DataRow DataRow_Usuario_Correo = objDS.Tables["usuariocorreo"].Select("USUA_ID = " + ID.ToString())[0];
                    TxtId.Text = DataRow_Usuario_Correo["USUA_ID"].ToString();
                    TxtNom.Text = DataRow_Usuario_Correo["USUA_NOMBRE"].ToString();
                    TxtApe.Text = DataRow_Usuario_Correo["USUA_APELLIDO"].ToString();
                    TxtUsr.Text = DataRow_Usuario_Correo["USUA_CORREO"].ToString();
                    TxtCon.Text = DataRow_Usuario_Correo["USUA_CONTRASENA"].ToString();
                    TxtVer.Text = DataRow_Usuario_Correo["USUA_CONTRASENA"].ToString();
                    CmbPai.SelectedValue = DataRow_Usuario_Correo["PAIS_ID"];
                    TxtCel.Text = DataRow_Usuario_Correo["USUA_CELULAR"].ToString();
                    TxtCor.Text = DataRow_Usuario_Correo["USUA_CORREO_RECUPERACION"].ToString();
                    DtpNac.Text = DataRow_Usuario_Correo["USUA_FECHA_NACIMIENTO"].ToString();
                    CmbSex.SelectedValue = DataRow_Usuario_Correo["SEXO_ID"];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }

        }

        private void BtnAyudaNom_Click(object sender, EventArgs e)
        {
            try
            {
                DataView objDataView_Usuario_Correo = objDS.Tables["usuariocorreo"].DefaultView;
                objDataView_Usuario_Correo.RowFilter = "USUA_NOMBRE LIKE '%" + TxtNom.Text + "%'";
                FrmBusqueda objAyuda = new FrmBusqueda(objDataView_Usuario_Correo, "Ayuda Nombre");
                objAyuda.ShowDialog(this);
                if(objAyuda.objRow != null)
                {
                    int ID = Convert.ToInt32(objAyuda.objRow.Cells["USUA_ID"].Value);
                    DataRow DataRow_Usuario_Correo = objDS.Tables["usuariocorreo"].Select("USUA_ID = " + ID.ToString())[0];
                    TxtId.Text = DataRow_Usuario_Correo["USUA_ID"].ToString();
                    TxtNom.Text = DataRow_Usuario_Correo["USUA_NOMBRE"].ToString();
                    TxtApe.Text = DataRow_Usuario_Correo["USUA_APELLIDO"].ToString();
                    TxtUsr.Text = DataRow_Usuario_Correo["USUA_CORREO"].ToString();
                    TxtCon.Text = DataRow_Usuario_Correo["USUA_CONTRASENA"].ToString();
                    TxtVer.Text = DataRow_Usuario_Correo["USUA_CONTRASENA"].ToString();
                    CmbPai.SelectedValue = DataRow_Usuario_Correo["PAIS_ID"];
                    TxtCel.Text = DataRow_Usuario_Correo["USUA_CELULAR"].ToString();
                    TxtCor.Text = DataRow_Usuario_Correo["USUA_CORREO_RECUPERACION"].ToString();
                    DtpNac.Text = DataRow_Usuario_Correo["USUA_FECHA_NACIMIENTO"].ToString();
                    CmbSex.SelectedValue = DataRow_Usuario_Correo["SEXO_ID"];

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
            }

        }

        private void BtnSincronizar_Click(object sender, EventArgs e)
        {
            try
            {
                objDA_Usuario_Correo.Update(objDS.Tables["usuariocorreo"]);
                MessageBox.Show("La sincronización se realizó satisfactoriamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
