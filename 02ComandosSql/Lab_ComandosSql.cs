// Variables globales de conexion y comando
SqlConnection objConexion = new SqlConnection();
SqlCommand objComando = new SqlCommand();
Dictionary<string,string> accion = new Dictionary<string,string>();


//Evento Load
objConexion.ConnectionString = "Server=.;Database=TAD2020II;Integrated Security=SSPI;";
objComando.Connection = objConexion;
objComando.CommandType = CommandType.StoredProcedure;
accion.Add("insertar", "Insertar_Usuario");
accion.Add("actualizar", "Actualizar_Usuario");
accion.Add("eliminar", "Eliminar_Usuario");

private void FrmText_Load(object sender, EventArgs e)
{
    try
    {
        objConexion.ConnectionString = "Server=.;Database=TAD2020II;Integrated Security=SSPI;";
        objComando.Connection = objConexion;
        objComando.CommandType = CommandType.StoredProcedure;
        accion.Add("insertar", "Insertar_Usuario");
        accion.Add("actualizar", "Actualizar_Usuario");
        accion.Add("eliminar", "Eliminar_Usuario");
    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}

private void BtnInsertar_Click(object sender, EventArgs e)
{
    try
    {
        //Uso del método Add para agregar parámetros al comando
        
        objComando.CommandText = accion["insertar"];
        objComando.Parameters.Clear();
        objComando.Parameters.Add("@USUA_CORREO", SqlDbType.VarChar, 1000);
        objComando.Parameters["@USUA_CORREO"].Value = TxtCorreo.Text;
        objComando.Parameters.Add("@USUA_CLAVE", SqlDbType.VarChar,1000);
        objComando.Parameters["@USUA_CLAVE"].Value = TxtClave.Text;
        objComando.Parameters.Add("@USUA_NOMBRE", SqlDbType.VarChar, 2000);
        objComando.Parameters["@USUA_NOMBRE"].Value = TxtNombre.Text;
        objConexion.Open();
        objComando.ExecuteNonQuery();
        MessageBox.Show("El registro se insertó", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

private void BtnActualizar_Click(object sender, EventArgs e)
{
    try
    {
        //Utilizar método "AddRange" para agregar parámetros al comando

        SqlParameter[] listaParametros = new SqlParameter[] {
            new SqlParameter("@USUA_ID",SqlDbType.BigInt),
            new SqlParameter("@USUA_CORREO", SqlDbType.VarChar, 1000),
            new SqlParameter("@USUA_CLAVE", SqlDbType.VarChar, 1000),
            new SqlParameter("@USUA_NOMBRE", SqlDbType.VarChar, 2000)
        };
        objComando.CommandText = accion["actualizar"];
        objComando.Parameters.Clear();
        objComando.Parameters.AddRange(listaParametros);
        objComando.Parameters["@USUA_ID"].Value = TxtID.Text;
        objComando.Parameters["@USUA_CORREO"].Value = TxtCorreo.Text;
        objComando.Parameters["@USUA_CLAVE"].Value = TxtClave.Text;
        objComando.Parameters["@USUA_NOMBRE"].Value = TxtNombre.Text;
        objConexion.Open();
        objComando.ExecuteNonQuery();
        MessageBox.Show("El registro se actualizó", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

private void BtnEliminar_Click(object sender, EventArgs e)
{
    try
    {
        //Utilizar método "AddWithValue" para agregar parámetros al comando
        objComando.CommandText = accion["eliminar"];
        objComando.Parameters.Clear();
        objComando.Parameters.AddWithValue("@USUA_ID", Convert.ToInt64(TxtID.Text));
        objConexion.Open();
        objComando.ExecuteNonQuery();
        MessageBox.Show("El registro se eliminó", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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