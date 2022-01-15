using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica_Negocio.Library
{
    public class UploadImage
    {
        private OpenFileDialog fd = new OpenFileDialog();

        /// <summary>
        /// Metodo para cargar una imagen
        /// </summary>
        /// <param name="pictureBox">imagen que le pasamos</param>
        public void CargarImagen(PictureBox pictureBox)
        {
            //Establecer la propiedad a WaitOnLoad a true significa que la imagen 
            //se carga de forma sincrónica
            pictureBox.WaitOnLoad = true;
            //Filtrar los archivos que recibimos por extension
            fd.Filter = "Imagenes|*.jpg;*.gif;*.png;*.bmp";
            //Mostramos la ventana 
            fd.ShowDialog();
            //Si el nombre del archivo esta vacio
            if (fd.FileName != string.Empty)
            {
                //Les pasamos el nombre de la imagen 
                pictureBox.ImageLocation = fd.FileName;
            }
        }
    }
}
