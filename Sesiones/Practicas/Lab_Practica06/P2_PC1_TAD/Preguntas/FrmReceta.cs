using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PracticaCalificada
{
    public partial class FrmReceta : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader loDataReader;

        public FrmReceta()
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
                Busqueda objayuda = new Busqueda(loDataReader, "Busqueda de Medico");
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            String lsXML = "";
            con.Open();
            try
            {
                //Creacion del string xml de detalle de receta
                int item = 1;
                foreach (DataGridViewRow row in DgvDetalle.Rows)
                {
                    XElement objXml = new XElement(
                            "row",
                            new XAttribute("DREC_ID", item.ToString()),
                            new XAttribute("PROD_ID", row.Cells["PROD_ID"].Value.ToString()),
                            new XAttribute("DREC_CANTIDAD", row.Cells["DREC_CANTIDAD"].Value.ToString()),
                            new XAttribute("DREC_INDICACION", row.Cells["DREC_INDICACION"].Value.ToString())
                        );
                    lsXML = lsXML + objXml.ToString();
                    item = item + 1;
                }

                cmd.CommandText = "INSERTA_RECETA";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CREC_FECHA", Convert.ToDateTime(DtpFec.Value));
                cmd.Parameters.AddWithValue("@MEDI_ID", TxtIDMed.Text);
                cmd.Parameters.AddWithValue("@PACI_ID", TxtIDPac.Text);
                cmd.Parameters.AddWithValue("@XML", lsXML);
                cmd.ExecuteNonQuery();


                //MessageBox.Show(lsXML);
                LimpiarControles(this.Controls);
                LimpiarControles(groupBox1.Controls);

                MessageBox.Show("El registro se insertó satisfactóriamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
            con.Open();
            try
            {
                int item = 1;
                foreach (DataGridViewRow row in DgvDetalle.Rows)
                {
                    XElement objXml = new XElement(
                            "row",
                            new XAttribute("DREC_ID", item.ToString()),
                            new XAttribute("PROD_ID", row.Cells["PROD_ID"].Value.ToString()),
                            new XAttribute("DREC_CANTIDAD", row.Cells["DREC_CANTIDAD"].Value.ToString()),
                            new XAttribute("DREC_INDICACION", row.Cells["DREC_INDICACION"].Value.ToString())
                        );
                    lsXML = lsXML + objXml.ToString();
                    item = item + 1;
                }

                cmd.CommandText = "ACTUALIZA_RECETA";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CREC_ID", TxtID.Text);
                cmd.Parameters.AddWithValue("@CREC_FECHA", Convert.ToDateTime(DtpFec.Value));
                cmd.Parameters.AddWithValue("@MEDI_ID", TxtIDMed.Text);
                cmd.Parameters.AddWithValue("@PACI_ID", TxtIDPac.Text);
                cmd.Parameters.AddWithValue("@XML", lsXML);
                cmd.ExecuteNonQuery();


                //MessageBox.Show(lsXML);
                LimpiarControles(this.Controls);
                LimpiarControles(groupBox1.Controls);
                MessageBox.Show("El registro se actualizó satisfactóriamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
                Busqueda objayuda = new Busqueda(loDataReader, "Busqueda de Recetas");
                objayuda.ShowDialog(this);

                if (objayuda.objRow != null)
                {
                    cmd.CommandText = "SELECCIONA_RECETA";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CREC_ID", objayuda.objRow.Cells[0].Value);
                    loDataReader = cmd.ExecuteReader();
                    if (loDataReader.HasRows)
                    {
                        // Carga de los datos de cabecera de la receta
                        loDataReader.Read();
                        TxtID.Text = loDataReader.GetValue(loDataReader.GetOrdinal("CREC_ID")).ToString();
                        DtpFec.Value = Convert.ToDateTime(loDataReader.GetValue(loDataReader.GetOrdinal("CREC_FECHA")));
                        TxtIDMed.Text = loDataReader.GetValue(loDataReader.GetOrdinal("MEDI_ID")).ToString();
                        TxtIDPac.Text = loDataReader.GetValue(loDataReader.GetOrdinal("PACI_ID")).ToString();
                        TxtNomMed.Text = loDataReader.GetValue(loDataReader.GetOrdinal("MEDI_APE_NOM")).ToString();
                        TxtNomPac.Text = loDataReader.GetValue(loDataReader.GetOrdinal("PACI_APE_NOM")).ToString();
                        
                    }

                    //Carga de detalle de la receta
                    loDataReader.NextResult();
                    while (loDataReader.Read())
                    {
                        DgvDetalle.Rows.Add
                            (
                                loDataReader.GetValue(loDataReader.GetOrdinal("PROD_ID")),
                                loDataReader.GetValue(loDataReader.GetOrdinal("PROD_DESC")),
                                loDataReader.GetValue(loDataReader.GetOrdinal("DREC_CANTIDAD")),
                                loDataReader.GetValue(loDataReader.GetOrdinal("DREC_INDICACION"))
                            );
                    }

                }
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

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.CommandText = "ELIMINA_UN_RECETA";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CREC_ID", TxtID.Text);
                con.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("El registro se eliminó satisfactóriamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                LimpiarControlesv2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
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
            DgvDetalle.Columns.Clear();
            DgvDetalle.Columns.Add("PROD_ID", "Cod. Producto");
            DgvDetalle.Columns.Add("PROD_DESC", "Desc. Producto");
            DgvDetalle.Columns.Add("DREC_CANTIDAD", "Cantidad");
            DgvDetalle.Columns.Add("DREC_INDICACION", "Indicaciones");
            DgvDetalle.Rows.Clear();

            SqlConnectionStringBuilder objConstructorCadenaConexion = new SqlConnectionStringBuilder();
            objConstructorCadenaConexion.DataSource = ".";
            objConstructorCadenaConexion.InitialCatalog = "P2_PC1_TAD";
            objConstructorCadenaConexion.IntegratedSecurity = true;
            con.ConnectionString = objConstructorCadenaConexion.ConnectionString;

            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;



        }

        private void BtnAyudaPac_Click(object sender, EventArgs e)
        {
            
            try
            {
                cmd.CommandText = "AYUDA_PACIENTE";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@PACI_APE_NOM ", TxtNomPac.Text);
                con.Open();
                loDataReader = cmd.ExecuteReader();
                Busqueda objayuda = new Busqueda(loDataReader, "Busqueda de Medico");
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                Busqueda objayuda = new Busqueda(loDataReader, "Busqueda de Productos");
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void LimpiarControles(Control.ControlCollection cc)
        {
            foreach (Control ctrl in cc)
            {
                //Para TextBox
                if (ctrl is TextBox)
                {
                    TextBox tb = ctrl as TextBox;
                    if (tb != null)
                    {
                        tb.Text = "";
                    }
                }

                DataGridView dgv = ctrl as DataGridView;
                if (dgv != null)
                {
                    dgv.Rows.Clear();
                }

                if (ctrl is DateTimePicker)
                {
                    DateTimePicker dtp = ctrl as DateTimePicker;
                    if(dtp.Value != DateTime.Now)
                    {
                        dtp.Value = DateTime.Now;   
                    }
                }

            }
        }

        private void LimpiarControlesv2()
        {
            TxtID.Text = "";
            TxtIDMed.Text = "";
            TxtIDPac.Text = "";
            TxtIdProd.Text = "";
            TxtNomMed.Text = "";
            TxtNomPac.Text = "";
            TxtNomProd.Text = "";
            TxtCant.Text = "";
            TxtInd.Text = "";

            DtpFec.Value = DateTime.Now;
            DgvDetalle.Rows.Clear();
        }

    }
}
