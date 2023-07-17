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
using System.Transactions;

/*
Transacciones Distribuidas
Agregar Referencias -> Transactions
Iniciar el servicio de Coordinador de transacciones distribuidas

*/


namespace PracticaCalificada
{
    public partial class FrmReceta_TransacionDistribuida : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader loDataReader;

        public FrmReceta_TransacionDistribuida()
        {
            InitializeComponent();
        }

        private void BtnAyudaTrab_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.CommandText = "AYUDA_MEDICO";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@MEDI_APE_NOM", TxtNomMed.Text);
                con.Open();
                loDataReader = cmd.ExecuteReader();
                FrmBusqueda objayuda = new FrmBusqueda(loDataReader, "Busqueda de Médicos");
                objayuda.ShowDialog(this);
                if (objayuda.objRow != null)
                {
                    cmd.CommandText = "SELECCIONA_MEDICO";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@MEDI_ID", objayuda.objRow.Cells[0].Value);
                    loDataReader = cmd.ExecuteReader();
                    if (loDataReader.HasRows)
                    {
                        loDataReader.Read();
                        TxtIDMed.Text = loDataReader.GetValue(loDataReader.GetOrdinal("MEDI_ID")).ToString();
                        TxtNomMed.Text = loDataReader.GetValue(loDataReader.GetOrdinal("MEDI_APE_NOM")).ToString();
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
                    String lsXML = "";
                    foreach (DataGridViewRow loRow in DgvDetalle.Rows)
                    {
                        lsXML = lsXML + "<row DREC_ID=\"" + loRow.Index +
                            "\" PROD_ID=\"" + loRow.Cells["PROD_ID"].Value +
                            "\" DREC_CANTIDAD=\"" + loRow.Cells["DREC_CANTIDAD"].Value +
                            "\" DREC_INDICACION=\"" + loRow.Cells["DREC_INDICACION"].Value + "\"></row>\n";
                    }

                    // Para las transacciones distribuidas se utiliza una instancia de la clase TransactionScope
                    using (TransactionScope ts = new TransactionScope())
                    {
                        cmd.CommandText = "INSERTA_RECETA";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@CREC_FECHA", DtpFec.Value);
                        cmd.Parameters.AddWithValue("@MEDI_ID", Convert.ToInt32(TxtIDMed.Text));
                        cmd.Parameters.AddWithValue("@PACI_ID", Convert.ToInt32(TxtIDPac.Text));
                        cmd.Parameters.AddWithValue("@XML", lsXML);

                        con.Open();
                        cmd.ExecuteNonQuery();

                        ts.Complete();
                    }



                MessageBox.Show("El registro se insertó satisfactóriamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (SqlException sqlex)
            {
                //MessageBox.Show();
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

        private void DgvDetalle_DoubleClick(object sender, EventArgs e)
        {
            TxtIdProd.Text = DgvDetalle.CurrentRow.Cells["PROD_ID"].Value.ToString();
            TxtNomProd.Text = DgvDetalle.CurrentRow.Cells["PROD_DESC"].Value.ToString();
            TxtCant.Text = DgvDetalle.CurrentRow.Cells["DREC_CANTIDAD"].Value.ToString();
            TxtInd.Text = DgvDetalle.CurrentRow.Cells["DREC_INDICACION"].Value.ToString();
        }

        private void BtnGrabar_Click(object sender, EventArgs e)
        {
            
            String lsXML = "";
            try
            {
                
                foreach (DataGridViewRow loRow in DgvDetalle.Rows)
                {
                    lsXML = lsXML + "<row DREC_ID=\"" + loRow.Index +
                        "\" PROD_ID=\"" + loRow.Cells["PROD_ID"].Value +
                        "\" DREC_CANTIDAD=\"" + loRow.Cells["DREC_CANTIDAD"].Value +
                        "\" DREC_INDICACION=\"" + loRow.Cells["DREC_INDICACION"].Value + "\"></row>\n";
                }

                using (TransactionScope ts = new TransactionScope())
                {
                    cmd.CommandText = "ACTUALIZA_RECETA";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CREC_ID", TxtID.Text);
                    cmd.Parameters.AddWithValue("@CREC_FECHA", DtpFec.Value);
                    cmd.Parameters.AddWithValue("@MEDI_ID", Convert.ToInt32(TxtIDMed.Text));
                    cmd.Parameters.AddWithValue("@PACI_ID", Convert.ToInt32(TxtIDPac.Text));
                    cmd.Parameters.AddWithValue("@XML", lsXML);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    ts.Complete();
                }

                

                MessageBox.Show("El registro se actualizó satisfactóriamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                cmd.CommandText = "AYUDA_RECETA";
                cmd.Parameters.Clear();
                con.Open();
                loDataReader = cmd.ExecuteReader();
                FrmBusqueda objayuda = new FrmBusqueda(loDataReader, "Busqueda de Receta");
                objayuda.ShowDialog(this);
                if (objayuda.objRow != null)
                {
                    DgvDetalle.Rows.Clear(); 
                    cmd.CommandText = "SELECCIONA_RECETA";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CREC_ID", objayuda.objRow.Cells[0].Value);
                    loDataReader = cmd.ExecuteReader();
                    if (loDataReader.HasRows)
                    {
                        loDataReader.Read();
                        TxtID.Text = loDataReader.GetValue(loDataReader.GetOrdinal("CREC_ID")).ToString();
                        DtpFec.Value = Convert.ToDateTime(loDataReader.GetValue(loDataReader.GetOrdinal("CREC_FECHA")));
                        TxtIDMed.Text = loDataReader.GetValue(loDataReader.GetOrdinal("MEDI_ID")).ToString();
                        TxtNomMed.Text = loDataReader.GetValue(loDataReader.GetOrdinal("MEDI_APE_NOM")).ToString();
                        TxtIDPac.Text = loDataReader.GetValue(loDataReader.GetOrdinal("PACI_ID")).ToString();
                        TxtNomPac.Text = loDataReader.GetValue(loDataReader.GetOrdinal("PACI_APE_NOM")).ToString();
                    }
                    loDataReader.NextResult();

                    DataTable loDataTable = new DataTable();
                    loDataTable.Load(loDataReader, LoadOption.OverwriteChanges);
                    foreach (DataRow loRow in loDataTable.Rows)
                    {
                        DgvDetalle.Rows.Add(
                            loRow["PROD_ID"],
                            loRow["PROD_DESC"],
                            loRow["DREC_CANTIDAD"],
                            loRow["DREC_INDICACION"]);
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

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope()) 
                {
                    cmd.CommandText = "ELIMINA_UN_RECETA";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CREC_ID", TxtID.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    ts.Complete();
                }
                

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

        private void BtnItemInsertar_Click(object sender, EventArgs e)
        {
            DgvDetalle.Rows.Add(
                TxtIdProd.Text,
                TxtNomProd.Text,
                TxtCant.Text,
                TxtInd.Text 
                );
        }

        private void BtnItemActualizar_Click(object sender, EventArgs e)
        {
            DgvDetalle.CurrentRow.Cells["PROD_ID"].Value = TxtIdProd.Text;
            DgvDetalle.CurrentRow.Cells["PROD_DESC"].Value = TxtNomProd.Text;
            DgvDetalle.CurrentRow.Cells["DREC_CANTIDAD"].Value = TxtCant.Text;
            DgvDetalle.CurrentRow.Cells["DREC_INDICACION"].Value = TxtInd.Text;

        }

        private void BtnItemEliminar_Click(object sender, EventArgs e)
        {
            DgvDetalle.Rows.Remove(DgvDetalle.CurrentRow);
        }

        private void FrmPregunta1_Load(object sender, EventArgs e)
        {
            try
            {
                con.ConnectionString = "Server=.;DataBase=P2_PC1_TAD_2020I;Integrated Security=SSPI;";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                DgvDetalle.Columns.Clear();
                DgvDetalle.Columns.Add("PROD_ID", "Cod. Producto");
                DgvDetalle.Columns.Add("PROD_DESC", "Desc. Producto");
                DgvDetalle.Columns.Add("DREC_CANTIDAD", "Cantidad");
                DgvDetalle.Columns.Add("DREC_INDICACION", "Indicaciones");
                DgvDetalle.Rows.Clear();
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
            }
        }

        private void BtnAyudaPac_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.CommandText = "AYUDA_PACIENTE";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@PACI_APE_NOM", TxtNomPac.Text);
                con.Open();
                loDataReader = cmd.ExecuteReader();
                FrmBusqueda objayuda = new FrmBusqueda(loDataReader, "Busqueda de Pacientes");
                objayuda.ShowDialog(this);
                if (objayuda.objRow != null)
                {
                    cmd.CommandText = "SELECCIONA_PACIENTE";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@PACI_ID", objayuda.objRow.Cells[0].Value);
                    loDataReader = cmd.ExecuteReader();
                    if (loDataReader.HasRows)
                    {
                        loDataReader.Read();
                        TxtIDPac.Text = loDataReader.GetValue(loDataReader.GetOrdinal("PACI_ID")).ToString();
                        TxtNomPac.Text = loDataReader.GetValue(loDataReader.GetOrdinal("PACI_APE_NOM")).ToString();
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
                cmd.CommandText = "AYUDA_PRODUCTO";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@PROD_DESC", TxtNomProd.Text);
                con.Open();
                loDataReader = cmd.ExecuteReader();
                FrmBusqueda objayuda = new FrmBusqueda(loDataReader, "Busqueda de Productos");
                objayuda.ShowDialog(this);
                if (objayuda.objRow != null)
                {
                    cmd.CommandText = "SELECCIONA_PRODUCTO";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@PROD_ID", objayuda.objRow.Cells[0].Value);
                    loDataReader = cmd.ExecuteReader();
                    if (loDataReader.HasRows)
                    {
                        loDataReader.Read();
                        TxtIdProd.Text = loDataReader.GetValue(loDataReader.GetOrdinal("PROD_ID")).ToString();
                        TxtNomProd.Text = loDataReader.GetValue(loDataReader.GetOrdinal("PROD_DESC")).ToString();
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
    }
}
