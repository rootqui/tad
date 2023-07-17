using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

// Creando una conexion por medio de la clase SqlConnectionStringBuilder
SqlConnection objconexion = new SqlConnection();

SqlConnectionStringBuilder objConstructorConexion = new SqlConnectionStringBuilder();
objConstructorConexion.DataSource = ".";
objConstructorConexion.InitialCatalog = "NombreBaseDeDatos";
objConstructorConexion.IntegratedSecurity = true;
objconexion.ConnectionString = objConstructorConexion.ConnectionString;

// Creando una conexion por medio del archivo app.xonfig
// Agregar referncias System.Configuration

SqlConnection objCon = new SqlConnection();

try
{
    //Recuperar la cadena de conexión del archivo app.config y utilizarla para configurar el objeto de conexión
    //Creando lista de Conexiones
    Dictionary<String, String> listaConexiones = CrearListaConexiones();
    objCon.ConnectionString = listaConexiones["MiCadenaConexion"];
    objCon.Open();
    MessageBox.Show(objCon.State.ToString());
}
catch (Exception ex)
{
    MessageBox.Show(ex.Message);
}finally
{
    objCon.Close();
    MessageBox.Show(objCon.State.ToString());
}


