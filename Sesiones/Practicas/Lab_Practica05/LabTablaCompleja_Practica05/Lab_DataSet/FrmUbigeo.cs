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
    public partial class FrmUbigeo : Form
    {
        SqlConnection objConexion = new SqlConnection();
        DataSet DS_Ubigeo = new DataSet();
        public FrmUbigeo()
        {
            InitializeComponent();
        }

        private void FrmUbigeo_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder objConstructorCadenaConexion = new SqlConnectionStringBuilder();
                objConstructorCadenaConexion.DataSource = ".";
                objConstructorCadenaConexion.InitialCatalog = "Lab_TAD";
                objConstructorCadenaConexion.IntegratedSecurity = true;
                objConexion.ConnectionString = objConstructorCadenaConexion.ConnectionString;

                SqlDataAdapter DA_Dep = new SqlDataAdapter();
                DA_Dep.SelectCommand = new SqlCommand("Seleccionar_Departamentos", objConexion);
                DA_Dep.SelectCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter DA_Pro = new SqlDataAdapter();
                DA_Pro.SelectCommand = new SqlCommand("Seleccionar_Provincias", objConexion);
                DA_Pro.SelectCommand.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter DA_Dis = new SqlDataAdapter();
                DA_Dis.SelectCommand = new SqlCommand("Seleccionar_Distritos", objConexion);
                DA_Dis.SelectCommand.CommandType = CommandType.StoredProcedure;

                DA_Dep.Fill(DS_Ubigeo, "Dep");
                DA_Pro.Fill(DS_Ubigeo, "Pro");
                DA_Dis.Fill(DS_Ubigeo, "Dis");

                CmbDepartamento.DataSource = DS_Ubigeo.Tables["Dep"];
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
        }

        private void CmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbProvincia.SelectedValue is Int32)
            {
                //DataView DV_Dis = DS_Ubigeo.Tables["Dis"].DefaultView;
                //DV_Dis.RowFilter = "PROV_ID = " + CmbProvincia.SelectedValue;

                //CmbDistrito.DataSource = DV_Dis;
                //CmbDistrito.ValueMember = "DIST_ID";
                //CmbDistrito.DisplayMember = "DIST_NOMBRE";
                CargarDistritos();
            }

        }

        private void CargarDistritos()
        {
            DataView DV_Dis = DS_Ubigeo.Tables["Dis"].DefaultView;
            DV_Dis.RowFilter = "PROV_ID = " + CmbProvincia.SelectedValue;

            CmbDistrito.DataSource = DV_Dis;
            CmbDistrito.ValueMember = "DIST_ID";
            CmbDistrito.DisplayMember = "DIST_NOMBRE";
        }
        private void CmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbDepartamento.SelectedValue is Int32)
            {
                DataView DV_Pro = DS_Ubigeo.Tables["Pro"].DefaultView;
                DV_Pro.RowFilter = "DEPA_ID = " + CmbDepartamento.SelectedValue;

                CmbProvincia.DataSource = DV_Pro;
                CmbProvincia.ValueMember = "PROV_ID";
                CmbProvincia.DisplayMember = "PROV_NOMBRE";
                CargarDistritos();
            }
        }

        private void CmbDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbDistrito.SelectedValue is Int32)
            {

            }
        }
    }
}
