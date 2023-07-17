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

namespace Lab_DataAdapter
{
    public partial class FrmCommandBuilder : Form
    {
        SqlConnection objConexion = new SqlConnection();
        SqlDataAdapter objAdaptador = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        public FrmCommandBuilder()
        {
            InitializeComponent();
        }

        private void BtnSincronizar_Click(object sender, EventArgs e)
        {
            try
            {
                objAdaptador.Update(objDataSet.Tables["Prod"]);
                MessageBox.Show("Los registros se sincronizaron correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder objConstructorCadenaConexion = new SqlConnectionStringBuilder();
                objConstructorCadenaConexion.DataSource = ".";
                objConstructorCadenaConexion.InitialCatalog = "Lab_TAD";
                objConstructorCadenaConexion.IntegratedSecurity = true;
                objConexion.ConnectionString = objConstructorCadenaConexion.ConnectionString;

                objAdaptador.SelectCommand = new SqlCommand("Seleccionar_Productos", objConexion);
                objAdaptador.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Se crea de forma automatizada las otros comandos como  insert, update, delete
                SqlCommandBuilder objConstructorComando = new SqlCommandBuilder(objAdaptador);

                objAdaptador.Fill(objDataSet, "prod");

                dataGridView1.DataSource = objDataSet.Tables["prod"];
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
