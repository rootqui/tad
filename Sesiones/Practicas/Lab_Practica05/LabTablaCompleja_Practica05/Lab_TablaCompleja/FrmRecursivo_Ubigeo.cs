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

namespace Lab_TablaCompleja
{
    public partial class FrmRecursivo_Ubigeo : Form
    {
        SqlConnection objConexion = new SqlConnection();
        SqlDataAdapter objDA_Ubigeo = new SqlDataAdapter();
        DataSet DS_Ubigeo = new DataSet();
        String idActualizar = null;

        public FrmRecursivo_Ubigeo()
        {
            InitializeComponent();
        }

        private void FrmRecursivo_Ubigeo_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnectionStringBuilder objConstructorCadenaConexion = new SqlConnectionStringBuilder();
                objConstructorCadenaConexion.DataSource = ".";
                objConstructorCadenaConexion.InitialCatalog = "Lab_TAD";
                objConstructorCadenaConexion.IntegratedSecurity = true;
                objConexion.ConnectionString = objConstructorCadenaConexion.ConnectionString;

                objDA_Ubigeo.SelectCommand = new SqlCommand("SELECT UBIG_ID, COALESCE(UBIG_ID_FK, 0) AS UBIG_ID_FK, UBIG_NOMBRE, UBIG_CODIGO FROM UBIGEO", objConexion);
                objDA_Ubigeo.SelectCommand.CommandType = CommandType.Text;

                objDA_Ubigeo.InsertCommand = new SqlCommand("Insertar_Ubigeo", objConexion);
                objDA_Ubigeo.InsertCommand.CommandType = CommandType.StoredProcedure;
                objDA_Ubigeo.InsertCommand.Parameters.Add("@UBIG_ID_FK", SqlDbType.Int, 0, "UBIG_ID_FK");
                objDA_Ubigeo.InsertCommand.Parameters.Add("@UBIG_NOMBRE", SqlDbType.VarChar, 100, "UBIG_NOMBRE");
                objDA_Ubigeo.InsertCommand.Parameters.Add("@UBIG_CODIGO", SqlDbType.VarChar, 10, "UBIG_CODIGO");

                objDA_Ubigeo.UpdateCommand = new SqlCommand("Actualizar_Ubigeo", objConexion);
                objDA_Ubigeo.UpdateCommand.CommandType = CommandType.StoredProcedure;
                objDA_Ubigeo.UpdateCommand.Parameters.Add("@UBIG_ID", SqlDbType.Int, 0, "UBIG_ID");
                objDA_Ubigeo.UpdateCommand.Parameters.Add("@UBIG_ID_FK", SqlDbType.Int, 0, "UBIG_ID_FK");
                objDA_Ubigeo.UpdateCommand.Parameters.Add("@UBIG_NOMBRE", SqlDbType.VarChar, 100, "UBIG_NOMBRE");
                objDA_Ubigeo.UpdateCommand.Parameters.Add("@UBIG_CODIGO ", SqlDbType.VarChar, 10, "UBIG_CODIGO");

                objDA_Ubigeo.DeleteCommand = new SqlCommand("Eliminar_Ubigeo", objConexion);
                objDA_Ubigeo.DeleteCommand.CommandType = CommandType.StoredProcedure;
                objDA_Ubigeo.DeleteCommand.Parameters.Add("@UBIG_ID", SqlDbType.Int, 0, "UBIG_ID");



                //SqlCommandBuilder objConstructor = new SqlCommandBuilder(objDA_Ubigeo);

                objDA_Ubigeo.Fill(DS_Ubigeo, "ubigeo");

                CargarArbolUbigeo();

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

        private void CargarArbolUbigeo()
        {
            try
            {
                DataTable loDataTable = new DataTable();
                loDataTable = DS_Ubigeo.Tables["ubigeo"];

                TvwUbigeo.Nodes.Clear();
                TreeNode loNodoPadre = new TreeNode();
                loNodoPadre.Name = "0";
                loNodoPadre.Text = "Ubigeos";
                TvwUbigeo.Nodes.Add(loNodoPadre);

                CargarNodosHijos(loNodoPadre, loDataTable);
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                objConexion.Close();
            }
        }

        
        private void CargarNodosHijos(TreeNode loNodoPadre, DataTable loDataTable)
        {
            TreeNode loNodoHijo;
            
            foreach (DataRow loRow in loDataTable.Select(string.Concat("UBIG_ID_FK = ", loNodoPadre.Name)))
            {
                loNodoHijo = new TreeNode();
                loNodoHijo.Name = loRow["UBIG_ID"].ToString();
                loNodoHijo.Text = loRow["UBIG_NOMBRE"].ToString();
                loNodoPadre.Nodes.Add(loNodoHijo);
                CargarNodosHijos(loNodoHijo, loDataTable);
            }
        }

        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TvwUbigeo.SelectedNode != null)
                {
                    DataRow DataRow_Ubigeo = DS_Ubigeo.Tables["ubigeo"].NewRow();

                    if (TvwUbigeo.SelectedNode.Name == "0")
                    {
                        DataRow_Ubigeo["UBIG_ID_FK"] = "0";
                    }
                    else 
                    {
                        DataRow_Ubigeo["UBIG_ID_FK"] = TvwUbigeo.SelectedNode.Name.ToString();
                    }


                    DataRow_Ubigeo["UBIG_ID"] = Convert.ToInt32(DS_Ubigeo.Tables["ubigeo"].Compute("Max(UBIG_ID)", string.Empty)) + 1;
                    
                    DataRow_Ubigeo["UBIG_NOMBRE"] = TxtNom.Text;
                    DataRow_Ubigeo["UBIG_CODIGO"] = TxtCod.Text;

                    DS_Ubigeo.Tables["ubigeo"].Rows.Add(DataRow_Ubigeo);

                    
                    MessageBox.Show("El registro se insertó satisfactóriamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                    CargarArbolUbigeo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (TvwUbigeo.SelectedNode != null)
                {
                    DataRow DataRow_Ubigeo = DS_Ubigeo.Tables["ubigeo"].Select("UBIG_ID = " + idActualizar)[0];

                    if (TvwUbigeo.SelectedNode.Name == "0")
                    {
                        DataRow_Ubigeo["UBIG_ID_FK"] = "0";
                    }
                    else
                    {
                        DataRow_Ubigeo["UBIG_ID_FK"] = TvwUbigeo.SelectedNode.Name;
                    }

                    DataRow_Ubigeo["UBIG_NOMBRE"] = TxtNom.Text;
                    DataRow_Ubigeo["UBIG_CODIGO"] = TxtCod.Text;

                    MessageBox.Show("El registro se actualizó satisfactóriamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    CargarArbolUbigeo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (MessageBox.Show("Desea eliminar el registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                DataRow DatRow_Ubigeo = DS_Ubigeo.Tables["ubigeo"].Select("UBIG_ID = " + TxtId.Text)[0];
                DatRow_Ubigeo.Delete();


                MessageBox.Show("El registro se eliminó satisfactóriamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                CargarArbolUbigeo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                objConexion.Close();
            }

        }

        private void TvwUbigeo_DoubleClick(object sender, EventArgs e)
        {

            if (Convert.ToInt32(TvwUbigeo.SelectedNode.Name) != 0)
            {
                
                DataRow DataRow_Ubigeo = DS_Ubigeo.Tables["ubigeo"].Select("UBIG_ID = " + TvwUbigeo.SelectedNode.Name)[0];

                idActualizar = DataRow_Ubigeo["UBIG_ID"].ToString();

                TxtId.Text = DataRow_Ubigeo["UBIG_ID"].ToString();
                TxtNom.Text = DataRow_Ubigeo["UBIG_NOMBRE"].ToString();
                TxtCod.Text = DataRow_Ubigeo["UBIG_CODIGO"].ToString();
                SeleccionarPadre(TvwUbigeo.Nodes[0], DataRow_Ubigeo["UBIG_ID_FK"].ToString());
                
            }

        }

        private void SeleccionarPadre(TreeNode objNodo, string ID)
        {
            try
            {
                foreach (TreeNode nodo in objNodo.Nodes)
                {
                    if (ID == "0")
                    {
                        TvwUbigeo.SelectedNode = TvwUbigeo.TopNode;
                        break;
                    }

                    if (nodo.Name == ID)
                    {
                        TvwUbigeo.SelectedNode = nodo;
                        break;
                    }
                    SeleccionarPadre(nodo, ID);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void btnSincronizar_Click(object sender, EventArgs e)
        {
            try
            {


                DataRow[] rows = DS_Ubigeo.Tables["ubigeo"].Select("UBIG_ID_FK = 0");
                for(int i = 0; i < rows.Length; i++) 
                {
                    rows[i]["UBIG_ID_FK"] = DBNull.Value;
                }

                
                objDA_Ubigeo.Update(DS_Ubigeo.Tables["ubigeo"]);

                for (int i = 0; i < rows.Length; i++)
                {
                    rows[i]["UBIG_ID_FK"] = "0";
                }

                MessageBox.Show("La sincronización se realizó satisfactoriamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarArbolUbigeo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
