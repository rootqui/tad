using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticaCalificada
{
    public static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        
        /// </summary>
         
        //static class Globales
        //{
        //}

        [STAThread]
        static void Main()
        {
    
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmReceta_TransacionLocal());
        }
    }
    }
