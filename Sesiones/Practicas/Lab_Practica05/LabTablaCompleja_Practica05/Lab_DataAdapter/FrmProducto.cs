﻿using System;
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
    public partial class FrmProducto : Form
    {
        SqlConnection objConexion = new SqlConnection();
        SqlDataAdapter objAdaptador = new SqlDataAdapter();
        DataSet objDataSet = new DataSet();

        public FrmProducto()
        {
            InitializeComponent();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
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

                objAdaptador.InsertCommand = new SqlCommand("Insertar_Producto", objConexion);
                objAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                objAdaptador.InsertCommand.Parameters.Add("@PROD_NOMBRE", SqlDbType.VarChar, 200, "PROD_NOMBRE");

                objAdaptador.UpdateCommand = new SqlCommand("Actualizar_Producto", objConexion);
                objAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                objAdaptador.UpdateCommand.Parameters.Add("@PROD_ID", SqlDbType.Int, 0, "PROD_ID");
                objAdaptador.UpdateCommand.Parameters.Add("@PROD_NOMBRE", SqlDbType.VarChar, 200, "PROD_NOMBRE");

                objAdaptador.DeleteCommand = new SqlCommand("Eliminar_Producto", objConexion);
                objAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                objAdaptador.DeleteCommand.Parameters.Add("@PROD_ID", SqlDbType.Int, 0, "PROD_ID");

                objAdaptador.Fill(objDataSet, "Prod");
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
