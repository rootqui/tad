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
using System.Data.Linq.SqlClient;


/*
LinQ
-----
Sobre el proyecto -> Agregar Nuevo Elemento -> Mostrar todas las plantillas
Clases LINQ to SQL
Explorador de Servidores -> Conexiones de datos -> Agregar conexion ... 
Elegir origen de datos -> MS SQL Server 
Agregar conexion -> Origen de datos: MS SQL Server -> Nombre del servidor: . -> Autenticacion Windows -> Seleccionar la base de datos : NombreDeLaBaseDeDatos 

De la pestaña Conexiones de datos -> Nombre Base de datos ->  Tablas (arrastrar y soltar a DataClasses1.dbml) 

*/


namespace PracticaCalificada
{
    public partial class FrmReceta : Form
    {
        DataClasses1DataContext objDC = new DataClasses1DataContext();

        public FrmReceta()
        {
            InitializeComponent();
        }

        private void BtnAyudaTrab_Click(object sender, EventArgs e)
        {
            try
            {
                
                var query = from t in objDC.MEDICO
                            where t.MEDI_NOMBRE.Contains(TxtNomMed.Text) ||
                            t.MEDI_APE_PATERNO.Contains(TxtNomMed.Text) || 
                            t.MEDI_APE_MATERNO.Contains(TxtNomMed.Text)
                           select t;
                FrmBusqueda objayuda = new FrmBusqueda(query, "Busqueda de Médicos");
                objayuda.ShowDialog(this);
                if (objayuda.objRow != null)
                {
                    int ID = Convert.ToInt32(objayuda.objRow.Cells["MEDI_ID"].Value);
                    var queryDatosMedico = (from t in objDC.MEDICO where t.MEDI_ID == ID select new { t.MEDI_ID, t.MEDI_NOMBRE, t.MEDI_APE_PATERNO, t.MEDI_APE_MATERNO }).FirstOrDefault();

                    TxtIDMed.Text = queryDatosMedico.MEDI_ID.ToString();
                    TxtNomMed.Text = queryDatosMedico.MEDI_APE_PATERNO.ToString() + " " + 
                                     queryDatosMedico.MEDI_APE_MATERNO.ToString() + ", " +
                                     queryDatosMedico.MEDI_NOMBRE.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
            }

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                using (TransactionScope tr = new TransactionScope())
                {
                    //Insercion Cabecera Receta
                    CAB_RECETA objCab = new CAB_RECETA();
                    objCab.CREC_FECHA = DtpFec.Value;
                    objCab.MEDI_ID = Convert.ToInt32(TxtIDMed.Text);
                    objCab.PACI_ID = Convert.ToInt32(TxtIDPac.Text);

                    objDC.CAB_RECETA.InsertOnSubmit(objCab);
                    objDC.SubmitChanges();

                    //Insercion Detalle de Receta
                    foreach (DataGridViewRow fila in DgvDetalle.Rows)
                    {
                        DET_RECETA objDet = new DET_RECETA();
                        objDet.CREC_ID = objCab.CREC_ID;
                        objDet.DREC_ID = fila.Index + 1;
                        objDet.PROD_ID = Convert.ToInt32(fila.Cells["PROD_ID"].Value);
                        objDet.DREC_CANTIDAD = Convert.ToDecimal(fila.Cells["DREC_CANTIDAD"].Value);
                        objDet.DREC_INDICACION = fila.Cells["DREC_INDICACION"].Value.ToString();
                        objDC.DET_RECETA.InsertOnSubmit(objDet);
                    }
                    objDC.SubmitChanges();

                    tr.Complete();
                }
                MessageBox.Show("El registro se insertó satisfactóriamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
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
            try
            {
                using (TransactionScope tr = new TransactionScope())
                {
                    // Actualizacion de la Cabecera Receta
                    int ID = Convert.ToInt32(TxtID.Text);
                    var queryCab = (from c in objDC.CAB_RECETA 
                                    where c.CREC_ID == ID
                                    select c).FirstOrDefault();
                    queryCab.CREC_FECHA = DtpFec.Value;

                    queryCab.MEDICO = objDC.MEDICO.Single(m => m.MEDI_ID == Convert.ToInt32(TxtIDMed.Text));
                    queryCab.PACIENTE = objDC.PACIENTE.Single(p => p.PACI_ID == Convert.ToInt32(TxtIDPac.Text));
             

                    var queryDet = from d in objDC.DET_RECETA where d.CREC_ID == ID select d;
                    objDC.DET_RECETA.DeleteAllOnSubmit(queryDet);
                    objDC.SubmitChanges();

                    // Insercion de los Detalles Receta
                    foreach (DataGridViewRow fila in DgvDetalle.Rows)
                    {
                        DET_RECETA objDet = new DET_RECETA();
                        objDet.CREC_ID = queryCab.CREC_ID;
                        objDet.DREC_ID = fila.Index + 1;
                        objDet.PROD_ID = Convert.ToInt32(fila.Cells["PROD_ID"].Value);
                        objDet.DREC_CANTIDAD = Convert.ToDecimal(fila.Cells["DREC_CANTIDAD"].Value);
                        objDet.DREC_INDICACION = fila.Cells["DREC_INDICACION"].Value.ToString();
                        objDC.DET_RECETA.InsertOnSubmit(objDet);
                    }

                    objDC.SubmitChanges();
                    tr.Complete();
                }


                MessageBox.Show("El registro se actualizó satisfactóriamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
            }
        }

        private void BtnAyudaCon_Click(object sender, EventArgs e)
        {
            try
            {
                var query = from c in objDC.CAB_RECETA select new {c.CREC_ID, c.CREC_FECHA, c.MEDI_ID, c.PACI_ID};
                FrmBusqueda objayuda = new FrmBusqueda(query, "Busqueda de Receta");
                objayuda.ShowDialog(this);
                if (objayuda.objRow != null)
                {
                    int ID = Convert.ToInt32(objayuda.objRow.Cells["CREC_ID"].Value);
                    var queryCab = (from c in objDC.CAB_RECETA where c.CREC_ID == ID select c).FirstOrDefault();
                    TxtID.Text = queryCab.CREC_ID.ToString();
                    DtpFec.Value = queryCab.CREC_FECHA;
                    TxtIDMed.Text = queryCab.MEDI_ID.ToString();
                    TxtNomMed.Text = queryCab.MEDICO.MEDI_NOMBRE.ToString() + " " + queryCab.MEDICO.MEDI_APE_PATERNO.ToString() + " " + queryCab.MEDICO.MEDI_APE_MATERNO.ToString();                  
                    TxtIDPac.Text = queryCab.PACI_ID.ToString();
                    TxtNomPac.Text = queryCab.PACIENTE.PACI_NOMBRE.ToString() + " " + queryCab.PACIENTE.PACI_APE_PATERNO.ToString() + " " + queryCab.PACIENTE.PACI_APE_MATERNO.ToString();

                    var queryDet = (from d in objDC.DET_RECETA where d.CREC_ID == ID select d);

                    foreach( var fila in queryDet)
                    {
                        DgvDetalle.Rows.Add(
                            fila.PROD_ID,
                            fila.PRODUCTO.PROD_DESC,
                            fila.DREC_CANTIDAD,
                            fila.DREC_INDICACION
                            );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                using (TransactionScope tr = new TransactionScope())
                {
                    int ID = Convert.ToInt32(TxtID.Text);
                    var queryCab = from c in objDC.CAB_RECETA where c.CREC_ID == ID select c;
                    var queryDet = from d in objDC.DET_RECETA where d.CREC_ID == ID select d;

                    objDC.DET_RECETA.DeleteAllOnSubmit(queryDet);
                    objDC.CAB_RECETA.DeleteAllOnSubmit(queryCab);

                    objDC.SubmitChanges();

                    tr.Complete();
                }
                MessageBox.Show("El registro se eliminó satisfactóriamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
            try
            {
                DgvDetalle.Columns.Clear();
                DgvDetalle.Columns.Add("PROD_ID", "Cod. Producto");
                DgvDetalle.Columns.Add("PROD_DESC", "Desc. Producto");
                DgvDetalle.Columns.Add("DREC_CANTIDAD", "Cantidad");
                DgvDetalle.Columns.Add("DREC_INDICACION", "Indicaciones");
                DgvDetalle.Rows.Clear();
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
                var query = from p in objDC.PACIENTE
                            where p.PACI_NOMBRE.Contains(TxtNomPac.Text) ||
                             p.PACI_APE_PATERNO.Contains(TxtNomPac.Text) ||
                             p.PACI_APE_MATERNO.Contains(TxtNomPac.Text)
                            select p;
                FrmBusqueda objayuda = new FrmBusqueda(query, "Busqueda de Pacientes");
                objayuda.ShowDialog(this);
                if (objayuda.objRow != null)
                {
                    int ID = Convert.ToInt32(objayuda.objRow.Cells["PACI_ID"].Value);
                    var queryPaciente = (from p in objDC.PACIENTE where p.PACI_ID == ID select new{ p.PACI_ID, p.PACI_NOMBRE, p.PACI_APE_PATERNO, p.PACI_APE_MATERNO}).FirstOrDefault();
                    TxtIDPac.Text = queryPaciente.PACI_ID.ToString();
                    TxtNomPac.Text = queryPaciente.PACI_NOMBRE.ToString() + " " + queryPaciente.PACI_APE_PATERNO.ToString() + " " + queryPaciente.PACI_APE_MATERNO.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
            }

        }

        private void BtnAyudaProd_Click(object sender, EventArgs e)
        {
            try
            {
                var query = from pr in objDC.PRODUCTO 
                            where pr.PROD_DESC.Contains(TxtNomProd.Text)
                            select pr;
                FrmBusqueda objayuda = new FrmBusqueda(query, "Busqueda de Productos");
                objayuda.ShowDialog(this);
                if (objayuda.objRow != null)
                {
                    int ID = Convert.ToInt32(objayuda.objRow.Cells["PROD_ID"].Value);
                    var queryProductos = (from pr in objDC.PRODUCTO where pr.PROD_ID == ID select pr).FirstOrDefault();
                    
                    TxtIdProd.Text = queryProductos.PROD_ID.ToString();
                    TxtNomProd.Text = queryProductos.PROD_DESC.ToString();
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
            }

        }
    }
}
