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

namespace Lab_DataSet
{
    public partial class FrmProvincia : Form
    {
        SqlConnection objConexion = new SqlConnection();
        SqlDataAdapter DA_Provincia = new SqlDataAdapter();
        DataSet DS_Ubigeo = new DataSet();

        public FrmProvincia()
        {
            InitializeComponent();
        }

        private void FrmProvincia_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder objConstructorCadenaConexion = new SqlConnectionStringBuilder();
                objConstructorCadenaConexion.DataSource = ".";
                objConstructorCadenaConexion.InitialCatalog = "Lab_TAD";
                objConstructorCadenaConexion.IntegratedSecurity = true;
                objConexion.ConnectionString = objConstructorCadenaConexion.ConnectionString;

                DA_Provincia.SelectCommand = new SqlCommand("Seleccionar_Provincias", objConexion);
                DA_Provincia.SelectCommand.CommandType = CommandType.StoredProcedure;

                SqlCommandBuilder objConstructorComando = new SqlCommandBuilder(DA_Provincia);

                DA_Provincia.Fill(DS_Ubigeo, "Prov");

                SqlDataAdapter DA_Departamento = new SqlDataAdapter();
                DA_Departamento.SelectCommand = new SqlCommand("Seleccionar_Departamentos", objConexion);

                DA_Departamento.Fill(DS_Ubigeo, "Depa");

                CmbDepartamento.DataSource = DS_Ubigeo.Tables["Depa"];
                CmbDepartamento.ValueMember = "DEPA_ID";
                CmbDepartamento.DisplayMember = "DEPA_NOMBRE";

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
                DataRow DR_Provincia = DS_Ubigeo.Tables["Prov"].NewRow();
                DR_Provincia["PROV_ID"] = Convert.ToInt16(DS_Ubigeo.Tables["Prov"].Compute("Max(PROV_ID)",string.Empty)) + 1; 
                DR_Provincia["DEPA_ID"] = CmbDepartamento.SelectedValue;
                DR_Provincia["PROV_CODIGO"] = TxtCodigo.Text;
                DR_Provincia["PROV_NOMBRE"] = TxtNombre.Text;
                DS_Ubigeo.Tables["Prov"].Rows.Add(DR_Provincia);

                MessageBox.Show("El registro se insertó", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow DR_Provincia = DS_Ubigeo.Tables["Prov"].Select("PROV_ID = " + TxtID.Text)[0];
                DR_Provincia["DEPA_ID"] = CmbDepartamento.SelectedValue;
                DR_Provincia["PROV_CODIGO"] = TxtCodigo.Text;
                DR_Provincia["PROV_NOMBRE"] = TxtNombre.Text;

                MessageBox.Show("El registro se actualizó.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DataRow DR_Provincia = DS_Ubigeo.Tables["Prov"].Select("PROV_ID = " + TxtID.Text)[0];
                DR_Provincia.Delete();

                MessageBox.Show("El registro se eliminó.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSincronizar_Click(object sender, EventArgs e)
        {
            try
            {
                DA_Provincia.Update(DS_Ubigeo.Tables["Prov"]);
                MessageBox.Show("La sincronización se realizó satisfactoriamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAyudaNombre_Click(object sender, EventArgs e)
        {
            try
            {
                DataView DV_Provincia = DS_Ubigeo.Tables["Prov"].DefaultView;
                DV_Provincia.RowFilter = "PROV_NOMBRE LIKE '%" + TxtNombre.Text + "%'";
                FrmBusqueda objAyuda = new FrmBusqueda(DV_Provincia, "Provincias");
                objAyuda.ShowDialog(this);
                if (objAyuda.objRow != null)
                {
                    //objAyuda.objRow.Cells["PROV_ID"].Value; 
                    DataRow DR_Provincia = DS_Ubigeo.Tables["Prov"].Select("PROV_ID = " + objAyuda.objRow.Cells["PROV_ID"].Value.ToString())[0];
                    TxtID.Text = DR_Provincia["PROV_ID"].ToString();
                    TxtCodigo.Text  = DR_Provincia["PROV_CODIGO"].ToString();
                    TxtNombre.Text = DR_Provincia["PROV_NOMBRE"].ToString();
                    CmbDepartamento.SelectedValue = DR_Provincia["DEPA_ID"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
