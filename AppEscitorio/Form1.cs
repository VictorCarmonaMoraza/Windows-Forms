using Logica_Negocio;
using Logica_Negocio.Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AppEscitorio
{
    public partial class Form1 : Form
    {
        private Estudiantes estudiantes;
        //private Libreria librerias;

        public Form1()
        {
            InitializeComponent();

            var listTextBox = new List<TextBox>();
            //librerias = new Libreria();
            listTextBox.Add(textBoxDNI);
            listTextBox.Add(textBoxNombre);
            listTextBox.Add(textBoxApellido);
            listTextBox.Add(textBoxEmail);
            var listLabel = new List<Label>();
            listLabel.Add(labelDNI);
            listLabel.Add(labelNombre);
            listLabel.Add(labelApellido);
            listLabel.Add(labelEmail);
            listLabel.Add(labelPaginas);
            Object[] objetos = { 
                pictureBoxImage,
                Properties.Resources.bbdd,
                dataGridView1,
                numericUpDown1
            };
            estudiantes = new Estudiantes(listTextBox, listLabel, objetos);
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
            estudiantes.textBoxEvent.numberKeyPress(e);
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
            estudiantes.textBoxEvent.textKeyPress(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Insertamos elementos en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            estudiantes.Registrar();
        }

        /// <summary>
        /// Filtramos en datagriew por texto a buscar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            estudiantes.SearchEstudiante(textBoxBuscar.Text);
        }

        private void buttonPrimero_Click(object sender, EventArgs e)
        {
            estudiantes.Paginador("Primero");
        }

        private void buttonAnterior_Click(object sender, EventArgs e)
        {
            estudiantes.Paginador("Anterior");
        }

        private void buttonSiguiente_Click(object sender, EventArgs e)
        {
            estudiantes.Paginador("Siguiente");
        }

        private void buttonUltimo_Click(object sender, EventArgs e)
        {
            estudiantes.Paginador("Ultimo");
        }
    }
}
