using Capa_Data;
using Capa_Data.Entity;
using LinqToDB;
using Logica_Negocio.Library;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Logica_Negocio
{
    public class Estudiantes : Libreria
    {
        #region Campos
        private List<TextBox> listTextBox;
        private List<Label> listLabel;
        private bool boolControles;
        private PictureBox imagen;
        //private Libreria librerias;
        #endregion Campos

        #region Constructor
        public Estudiantes(List<TextBox> listTextBox, List<Label> listLabel, object[] objetos)
        {
            this.listTextBox = listTextBox;
            this.listLabel = listLabel;
            boolControles = false;
            //librerias = new Libreria();
            this.imagen = (PictureBox)objetos[0];
        }
        #endregion Constructor

        #region Procedimientos
        /// <summary>
        /// Registra los datos de capturados de los controles
        /// </summary>
        public void Registrar()
        {
            //listTextBox[0] es el dni, si esta vacio
            if (listTextBox[0].Text.Equals(""))
            {
                listLabel[0].Text = "El campo DNI es requerido";
                //Color para el mensaje
                listLabel[0].ForeColor = Color.Red;
                //Ponemos el foco sobre ese campo de texto
                listTextBox[0].Focus();

            }
            else
            {
                //listTextBox[1] es el Nombre, si esta vacio
                if (listTextBox[1].Text.Equals(""))
                {
                    listLabel[1].Text = "El campo Nombre es requerido";
                    //Color para el mensaje
                    listLabel[1].ForeColor = Color.Red;
                    //Ponemos el foco sobre ese campo de texto
                    listTextBox[1].Focus();

                }
                else
                {
                    //listTextBox[2] es el apellido, si esta vacio
                    if (listTextBox[2].Text.Equals(""))
                    {
                        listLabel[2].Text = "El campo Apellido es requerido";
                        //Color para el mensaje
                        listLabel[2].ForeColor = Color.Red;
                        //Ponemos el foco sobre ese campo de texto
                        listTextBox[2].Focus();
                    }
                    else
                    {
                        //listTextBox[3] es el email, si esta vacio
                        if (listTextBox[3].Text.Equals(""))
                        {
                            listLabel[3].Text = "El campo Email es requerido";
                            //Color para el mensaje
                            listLabel[3].ForeColor = Color.Red;
                            //Ponemos el foco sobre ese campo de texto
                            listTextBox[3].Focus();
                        }
                        else
                        {
                            //Si ele amail es valido
                            if (textBoxEvent.comprobarFormatoEmail(listTextBox[3].Text))
                            {
                                //imagen.Image : Obtiene el objeto imagen
                                var imagenArray = uploadImage.ImageToByte(imagen.Image);
                                Insertar(imagenArray);

                            }
                            //En caso de que el amil no sea valido
                            else
                            {
                                listLabel[3].Text = "Email no valido";
                                //Color para el mensaje
                                listLabel[3].ForeColor = Color.Red;
                                //Ponemos el foco sobre ese campo de texto
                                listTextBox[3].Focus();
                            }
                        }
                    }
                }
                boolControles = true;
                limpiarControles(boolControles);
            }
        }

        /// <summary>
        /// Limpiar todos los controles
        /// </summary>
        /// <param name="c"></param>
        public void limpiarControles(bool boolControles)
        {
            if (boolControles)
            {
                for (int i = 0; i < listTextBox.Count; i++)
                {
                    listTextBox[i].Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// Insertar en base de datos
        /// </summary>
        public void Insertar(byte[] imagen)
        {
            //var db = new Conexion();
            //db.Insert(new EstudiantePr2022()
            //{
            //    nid = listTextBox[0].Text,
            //    nombre = listTextBox[1].Text,
            //    apellido = listTextBox[2].Text,
            //    email = listTextBox[3].Text
            //});
            _Estudiante.Value(e => e.nid, listTextBox[0].Text)
                                    .Value(e => e.nombre, listTextBox[1].Text)
                                    .Value(e => e.apellido, listTextBox[2].Text)
                                    .Value(e => e.email, listTextBox[3].Text)
                                    .Value(e => e.image, imagen)
                                    .Insert();
        }
    }
    #endregion Procedimientos
}

