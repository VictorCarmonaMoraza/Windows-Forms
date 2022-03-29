using LinqToDB;
using Logica_Negocio.Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
                                //Obtenemos toda la informacion de la tabla estudiante
                                var user = _Estudiante.Where(u => u.email.Equals(listTextBox[3].Text)).ToList();
                                if (user.Count.Equals(0))
                                {
                                    //imagen.Image : Obtiene el objeto imagen
                                    var imagenArray = uploadImage.ImageToByte(imagen.Image);
                                    Insertar(imagenArray);
                                }
                                else
                                {
                                    listLabel[3].Text = "Email ya registrado";
                                    listLabel[3].ForeColor = Color.Red;
                                    listTextBox[3].Focus();
                                }
                            }
                            //En caso de que el email no sea valido
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
                //limpiarControles(boolControles);
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
            BeginTransactionAsync();
            try
            {
                _Estudiante.Value(e => e.nid, listTextBox[0].Text)
                                                   .Value(e => e.nombre, listTextBox[1].Text)
                                                   .Value(e => e.apellido, listTextBox[2].Text)
                                                   .Value(e => e.email, listTextBox[3].Text)
                                                   .Value(e => e.image, imagen)
                                                   .Insert();

                //int data = Convert.ToInt16("k");

                //Metodo de insertado satisfactoriamente
                CommitTransaction();
            }
            catch (Exception  )
            {
                //Revertimos todos los cambios
                RollbackTransaction();
            }
        }

        /// <summary>
        /// Comporbamos si tenemos el email en la base de datos
        /// </summary>
        /// <param name="elementoLista">Email a comporbar</param>
        //public bool comprobarEmailRepetido(string elementoLista)
        //{
        //    bool emailRepetido = false;
        //    //Obtenemos toda la informacion de la tabla estudiante
        //    var user = _Estudiante.Where(u => u.email.Equals(elementoLista)).ToList();
        //    if (user.Count.Equals(0))
        //    {
        //        emailRepetido = false;
        //    }
        //    else
        //    {
        //        listTextBox[3].Text = "Email ya registtrado";
        //        listTextBox[3].ForeColor = Color.Red;
        //        listTextBox[3].Focus();
        //        emailRepetido = true;
        //    }
        //    return emailRepetido;
        //}


    }
    #endregion Procedimientos
}

