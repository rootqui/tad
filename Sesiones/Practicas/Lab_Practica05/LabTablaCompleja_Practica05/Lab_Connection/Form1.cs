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

namespace Lab_Connection
{
    public partial class Form1 : Form
    {
        SqlConnection objConexion = new SqlConnection();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ////Cadena de conexion con autenticacion windows
                //objConexion.ConnectionString = "Data Source=.;DataBase=TAD_2021_I;Integrated Security=true";
                //MessageBox.Show(objConexion.State.ToString());
                //objConexion.Open();
                //MessageBox.Show(objConexion.State.ToString());

                ////Cadena de conexion con sql autentication
                //objConexion.ConnectionString = "Data Source=.;DataBase=TAD_2021_I;User ID=tad;Pwd=123456";
                //MessageBox.Show(objConexion.State.ToString());
                //objConexion.Open();
                //MessageBox.Show(objConexion.State.ToString());

                ////Cadena de conexion con sql autentication y Connectiontimeout
                //objConexion.ConnectionString = "Data Source=.;DataBase=TAD_2021_I;User ID=tad;Pwd=123456;Connection Timeout=20";
                //MessageBox.Show(objConexion.State.ToString());
                //MessageBox.Show(objConexion.ConnectionTimeout.ToString());
                //objConexion.Open();
                //MessageBox.Show(objConexion.State.ToString());

                //Cadena de conexion con sql autentication y coneccion encriptada
                objConexion.ConnectionString = "Data Source=.;DataBase=TAD_2021_I;User ID=tad;Pwd=123456;Encrypt=true";
                MessageBox.Show(objConexion.State.ToString());
                objConexion.Open();
                MessageBox.Show(objConexion.State.ToString());
                objConexion.Close();

                //SqlConnectionStringBuilder
                //app.config

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
