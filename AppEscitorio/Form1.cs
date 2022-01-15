using Logica_Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppEscitorio
{
    public partial class Form1 : Form
    {
        private Estudiantes estudiantes = new Estudiantes();

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBoxImage_Click(object sender, EventArgs e)
        {
            //pictureBoxImage : es el nombre que tiene la imagen 
            estudiantes.CargarImagen(pictureBoxImage);
        }
    }
}
