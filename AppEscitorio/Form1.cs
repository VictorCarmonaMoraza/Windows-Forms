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
            estudiantes.uploadImage.CargarImagen(pictureBoxImage);
        }

        private void textBoxDNI_TextChanged(object sender, EventArgs e)
        {
            //Si la propiedad es igual a vacio
            if (textBoxDNI.Text.Equals(""))
            {
                labelDNI.ForeColor = Color.LightSlateGray;
            }
            else
            {
                labelDNI.ForeColor = Color.Green;
                labelDNI.Text = "DNI";
            }
        }

        private void textBoxDNI_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            //Si la propiedad es igual a vacio
            if (textBoxNombre.Text.Equals(""))
            {
                labelNombre.ForeColor = Color.LightSlateGray;
            }
            else
            {
                labelNombre.ForeColor = Color.Green;
                labelNombre.Text = "Nombre";
            }
        }

        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            estudiantes.textBoxEvent.textKeyPress(e);
        }

        private void textBoxApellido_TextChanged(object sender, EventArgs e)
        {
            //Si la propiedad es igual a vacio
            if (textBoxApellido.Text.Equals(""))
            {
                labelApellido.ForeColor = Color.LightSlateGray;
            }
            else
            {
                labelApellido.ForeColor = Color.Green;
                labelApellido.Text = "Apellido";
            }
        }

        private void textBoxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBoxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            //Si la propiedad es igual a vacio
            if (textBoxEmail.Text.Equals(""))
            {
                labelEmail.ForeColor = Color.LightSlateGray;
            }
            else
            {
                labelEmail.ForeColor = Color.Green;
                labelEmail.Text = "Email";
            }
        }
    }
}
