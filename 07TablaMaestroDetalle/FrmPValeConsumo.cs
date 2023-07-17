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

namespace Lab_MaestroDetalle
{
    public partial class FrmPValeConsumo : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader loDataReader;

        public FrmPValeConsumo()
        {
            InitializeComponent();
        }

        private void FrmPValeConsumo_Load(object sender, EventArgs e)
        {
            try
            {
                con.ConnectionString = "Server=.;DataBase=Lab_TAD;Integrated Security=true;";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                DgvDetalle.Columns.Clear();
                DgvDetalle.Columns.Add("PROD_ID", "Código Producto");
                DgvDetalle.Columns.Add("PROD_NOMBRE", "Descripción Producto");
                DgvDetalle.Columns.Add("DETC_CANTIDAD", "Cantidad");
                DgvDetalle.Columns.Add("CENT_ID", "Código Centro Costo");
                DgvDetalle.Columns.Add("CENT_NOMBRE", "Descripción Centro Costo");
                DgvDetalle.Rows.Clear();

                //Cargar Almacenes
                cmd.CommandText = "ALMASS_Todos";
                cmd.Parameters.Clear();
                con.Open();
                loDataReader = cmd.ExecuteReader();

                DataTable objTabla = new DataTable();
                objTabla.Load(loDataReader, LoadOption.OverwriteChanges);

                CmbAlm.DataSource = objTabla;
                CmbAlm.ValueMember = "ALMA_ID";
                CmbAlm.DisplayMember = "ALMA_NOMBRE";

                //Cargar Centros de Costo
                cmd.CommandText = "CENTSS_Todos";
                cmd.Parameters.Clear();
                loDataReader = cmd.ExecuteReader();

                DataTable objTabla1 = new DataTable();
                objTabla1.Load(loDataReader, LoadOption.OverwriteChanges);

                CmbCen.DataSource = objTabla1;
                CmbCen.ValueMember = "CENT_ID";
                CmbCen.DisplayMember = "CENT_NOMBRE";
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
                con.Close();
            }
        }

        private void BtnAyudaTrab_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.CommandText = "TRABSS_Ayuda";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@TRAB_NOMBRE", TxtNomTrab.Text);
                con.Open();
                loDataReader = cmd.ExecuteReader();
                FrmBusqueda objayuda = new FrmBusqueda(loDataReader,"Busqueda de Trabajadores");
                objayuda.ShowDialog(this);
                if (objayuda.objRow != null)
                {
                    cmd.CommandText = "TRABSS_UNO";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@TRAB_ID", objayuda.objRow.Cells[0].Value);
                    loDataReader = cmd.ExecuteReader();
                    if (loDataReader.HasRows)
                    {
                        loDataReader.Read();
                        TxtIDTrab.Text = loDataReader.GetValue(loDataReader.GetOrdinal("TRAB_ID")).ToString();
                        TxtNomTrab.Text = loDataReader.GetValue(loDataReader.GetOrdinal("TRAB_NOMBRE")).ToString();
                    }

                }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                con.Close();
            }

        }

        private void BtnAyudaProd_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.CommandText = "PRODSS_Ayuda";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@PROD_NOMBRE", TxtNomProd.Text);
                con.Open();
                loDataReader = cmd.ExecuteReader();
                FrmBusqueda objayuda = new FrmBusqueda(loDataReader, "Busqueda de Productos");
                objayuda.ShowDialog(this);
                if (objayuda.objRow != null)
                {
                    cmd.CommandText = "PRODSS_UNO";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@PROD_ID", objayuda.objRow.Cells[0].Value);
                    loDataReader = cmd.ExecuteReader();
                    if (loDataReader.HasRows)
                    {
                        loDataReader.Read();
                        TxtIDProd.Text = loDataReader.GetValue(loDataReader.GetOrdinal("PROD_ID")).ToString();
                        TxtNomProd.Text = loDataReader.GetValue(loDataReader.GetOrdinal("PROD_NOMBRE")).ToString();
                    }

                }

            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                con.Close();
            }

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                //Insercion de Cabecera
                cmd.CommandText = "CABCSI_UNO";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CABC_FECHA", DtpFec.Value); 
                cmd.Parameters.AddWithValue("@ALMA_ID", CmbAlm.SelectedValue);
                cmd.Parameters.AddWithValue("@TRAB_ID", TxtIDTrab.Text);
                cmd.Parameters.AddWithValue("@CABC_ID", 0);
                // El procedimiento almacenado retorna CABC_ID (SCOPE_IDENTITY()) 
                cmd.Parameters["@CABC_ID"].Direction = ParameterDirection.InputOutput;
                con.Open();
                cmd.ExecuteNonQuery();
                int CABC_ID;

                // Recuperamos el valor del procedimiento almacenado para tabla de detalles
                CABC_ID = (int)cmd.Parameters["@CABC_ID"].Value;

                //Insercion de Detalles
                foreach (DataGridViewRow fila in DgvDetalle.Rows)
                {
                    cmd.CommandText = "DETCSI_UNO";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CABC_ID", CABC_ID);
                    cmd.Parameters.AddWithValue("@DETC_ID", fila.Index+1);
                    cmd.Parameters.AddWithValue("@PROD_ID", fila.Cells["PROD_ID"].Value);
                    cmd.Parameters.AddWithValue("@DETC_CANTIDAD", fila.Cells["DETC_CANTIDAD"].Value);
                    cmd.Parameters.AddWithValue("@CENT_ID", fila.Cells["CENT_ID"].Value);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("El registro se insertó satisfactóriamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                con.Close();
            }
        }

        private void BtnProdInsertar_Click(object sender, EventArgs e)
        {
            DgvDetalle.Rows.Add(
                TxtIDProd.Text, 
                TxtNomProd.Text, 
                TxtCant.Text, 
                CmbCen.SelectedValue, 
                CmbCen.Text);
        }

        private void BtnProdEliminar_Click(object sender, EventArgs e)
        {
            DgvDetalle.Rows.Remove(DgvDetalle.CurrentRow);
        }

        private void DgvDetalle_DoubleClick(object sender, EventArgs e)
        {
            TxtIDProd.Text = DgvDetalle.CurrentRow.Cells["PROD_ID"].Value.ToString();
            TxtNomProd.Text = DgvDetalle.CurrentRow.Cells["PROD_NOMBRE"].Value.ToString();
            TxtCant.Text = DgvDetalle.CurrentRow.Cells["DETC_CANTIDAD"].Value.ToString();
            CmbCen.SelectedValue = DgvDetalle.CurrentRow.Cells["CENT_ID"].Value;
        }

        private void BtnProdActualizar_Click(object sender, EventArgs e)
        {
            DgvDetalle.CurrentRow.Cells["PROD_ID"].Value = TxtIDProd.Text;
            DgvDetalle.CurrentRow.Cells["PROD_NOMBRE"].Value = TxtNomProd.Text;
            DgvDetalle.CurrentRow.Cells["DETC_CANTIDAD"].Value = TxtCant.Text;
            DgvDetalle.CurrentRow.Cells["CENT_ID"].Value = CmbCen.SelectedValue;
            DgvDetalle.CurrentRow.Cells["CENT_NOMBRE"].Value = CmbCen.Text;
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            String lsXML = "";
            try
            {
                //Insercion de Cabecera
                cmd.CommandText = "CABCSU_UNO";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CABC_ID", TxtID.Text);
                cmd.Parameters.AddWithValue("@CABC_FECHA", DtpFec.Value);
                cmd.Parameters.AddWithValue("@ALMA_ID", CmbAlm.SelectedValue);
                cmd.Parameters.AddWithValue("@TRAB_ID", TxtIDTrab.Text);
                con.Open();
                cmd.ExecuteNonQuery();

                cmd.CommandText = "DETCSD_TODOS";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CABC_ID", TxtID.Text);
                cmd.ExecuteNonQuery();

                //Insercion de Detalles
                foreach (DataGridViewRow fila in DgvDetalle.Rows)
                {
                    cmd.CommandText = "DETCSI_UNO";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CABC_ID", TxtID.Text);
                    cmd.Parameters.AddWithValue("@DETC_ID", fila.Index + 1);
                    cmd.Parameters.AddWithValue("@PROD_ID", fila.Cells["PROD_ID"].Value);
                    cmd.Parameters.AddWithValue("@DETC_CANTIDAD", fila.Cells["DETC_CANTIDAD"].Value);
                    cmd.Parameters.AddWithValue("@CENT_ID", fila.Cells["CENT_ID"].Value);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("El registro se grabó satisfactóriamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                con.Close();
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                MessageBox.Show("El registro se eliminó satisfactóriamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                con.Close();
            }
        }

        private void BtnAyudaCon_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.CommandText = "CABCSS_Ayuda";
                cmd.Parameters.Clear();
                con.Open();
                loDataReader = cmd.ExecuteReader();
                FrmBusqueda objayuda = new FrmBusqueda(loDataReader, "Busqueda de Vales de Consumo");
                objayuda.ShowDialog(this);
                if (objayuda.objRow != null)
                {
                    cmd.CommandText = "CABCSS_Uno";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CABC_ID", objayuda.objRow.Cells[0].Value);
                    loDataReader = cmd.ExecuteReader();
                    if (loDataReader.HasRows)
                    {
                        loDataReader.Read();
                        TxtID.Text = loDataReader.GetValue(loDataReader.GetOrdinal("CABC_ID")).ToString();
                        DtpFec.Value = Convert.ToDateTime(loDataReader.GetValue(loDataReader.GetOrdinal("CABC_FECHA")));
                        TxtIDTrab.Text = loDataReader.GetValue(loDataReader.GetOrdinal("TRAB_ID")).ToString();
                        TxtNomTrab.Text = loDataReader.GetValue(loDataReader.GetOrdinal("TRAB_NOMBRE")).ToString();
                        CmbAlm.SelectedValue = loDataReader.GetValue(loDataReader.GetOrdinal("ALMA_ID")).ToString();
                    }

                }
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(sqlex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                con.Close();
            }

        }

        private void DgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
