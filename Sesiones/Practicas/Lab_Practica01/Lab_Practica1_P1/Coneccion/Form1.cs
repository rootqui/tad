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
using System.Configuration;

namespace Coneccion
{
    public partial class Form1 : Form
    {
        SqlConnection objCon = new SqlConnection();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
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
        }

        private Dictionary<String, String> CrearListaConexiones() 
        {
            ConnectionStringSettingsCollection conexiones = ConfigurationManager.ConnectionStrings;
            
            Dictionary<String, String> listaConexiones = new Dictionary<String, String>();

            foreach (ConnectionStringSettings cs in conexiones)
            {
                listaConexiones.Add(cs.Name, cs.ConnectionString);
            }

            return listaConexiones;
        }
    }

}
