using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        /// <summary>
        /// Comvertir una imagen en byte
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public byte[] ImageToByte(Image imagenATransformar)
        {
            //Creamos el objeto de tipo ImageConverter
            var converter = new ImageConverter();
            //Convierte la imagen y la guarda en un array de byte
            byte[] imagenConvertida = (byte[])converter.ConvertTo(imagenATransformar, typeof(byte[]));
            ImagenString(imagenConvertida);
            //Convierte el objeto en el tipo que especificamos
            return imagenConvertida;
        }

        public string ImagenString(byte[] arrayImagen)
        {
            string ImagenStringConvertido = Encoding.Default.GetString(arrayImagen);
            return ImagenStringConvertido;
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            //MemoryStream ms = new MemoryStream(byteArrayIn);
            //Image _returnImage = Image.FromStream(ms);
            //return _returnImage;

            //Simplificado
            return Image.FromStream(new MemoryStream(byteArrayIn));
        }



    }
}
