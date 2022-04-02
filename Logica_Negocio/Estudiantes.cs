using Capa_Data.Entity;
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
        private Bitmap _imagBitMap;
        private PictureBox imagen;
        private DataGridView _dataGridView;
        private NumericUpDown _numericUpDown;
        private Paginador<EstudiantePr2022> _paginador;
        private List<EstudiantePr2022> listEstudiante;

        #endregion Campos

        #region Variables globales

        private  int _num_pagina = 2;
        private  int _reg_por_pagina = 1;

        #endregion Variables globales

        #region Constructor
        public Estudiantes(List<TextBox> listTextBox, List<Label> listLabel, object[] objetos)
        {
            this.listTextBox = listTextBox;
            this.listLabel = listLabel;
            _imagBitMap = (Bitmap)objetos[1];
            this.imagen = (PictureBox)objetos[0];
            this._dataGridView = (DataGridView)objetos[2];
            this._numericUpDown = (NumericUpDown)objetos[3];
            RestablecerControles();
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
            }
        }

        #region Procedimientos para BBDD
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
                RestablecerControles();
            }
            catch (Exception)
            {
                //Revertimos todos los cambios
                RollbackTransaction();
            }
        }
        
        public void SearchEstudiante(string campo)
        {
            List<EstudiantePr2022> query = new List<EstudiantePr2022>();
            //Paginador
            int inicio = (_num_pagina - 1) * _reg_por_pagina;
            //No filtramos ningun estudiante
            if (campo.Equals(""))
            {
                query = _Estudiante.ToList();
            }
            else
            {
                //Buscamos si hay coicidencia de alguno de los campos
                query = _Estudiante.Where(c => c.nid.StartsWith(campo) || c.nombre.StartsWith(campo)
                || c.apellido.StartsWith(campo)).ToList();
            }
            //Verficar si tenemos informacion
            if (query.Count>0)
            {
                //Columna de las cuales obtener datos
                _dataGridView.DataSource = query.Select(c=>new { 
                    c.id,
                    c.nid,
                    c.nombre,
                    c.apellido,
                    c.email,
                }).Skip(inicio).Take(_reg_por_pagina).ToList();
                //Con esto solo muestra todos los registros
                //.ToList();

                //Ocultar una columna
                _dataGridView.Columns[0].Visible = false;

                //Darle estilos a las columnas
                _dataGridView.Columns[1].DefaultCellStyle.BackColor = Color.Aquamarine;
                _dataGridView.Columns[3].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            }
            else
            {
                _dataGridView.DataSource = query.Select(c => new
                {
                    c.nid,
                    c.nombre,
                    c.apellido,
                    c.email,
                }).ToList();

                //Darle estilos a las columnas
                _dataGridView.Columns[1].DefaultCellStyle.BackColor = Color.Aquamarine;
                _dataGridView.Columns[3].DefaultCellStyle.BackColor = Color.WhiteSmoke;
            }
        }

        #endregion Procedimientos para BBDD

        /// <summary>
        /// Metodo para restablecer los controles despues de hacer la transaccion
        /// </summary>
        private void RestablecerControles()
        {
            imagen.Image = _imagBitMap;
            listLabel[0].Text = "Nid";
            listLabel[1].Text = "Nombre";
            listLabel[2].Text = "Apellido";
            listLabel[3].Text = "Email";

            //Le damos color a las label
            listLabel[0].ForeColor = Color.LightSlateGray;
            listLabel[1].ForeColor = Color.LightSlateGray;
            listLabel[2].ForeColor = Color.LightSlateGray;
            listLabel[3].ForeColor = Color.LightSlateGray;

            listTextBox[0].Text="";
            listTextBox[1].Text="";
            listTextBox[2].Text="";
            listTextBox[3].Text="";
            listEstudiante = _Estudiante.ToList();
            //Comporbamos si tiene datos
            if (listEstudiante.Count>0)
            {
                _paginador = new Paginador<EstudiantePr2022>(listEstudiante, listLabel[4], _reg_por_pagina);
            }
            SearchEstudiante("");

        }

        public void Paginador(string metodo)
        {
            switch (metodo)
            {
                case "Primero":
                    _num_pagina = _paginador.primero();
                    break;
                case "Anterior":
                    _num_pagina = _paginador.anterior();
                    break;
                case "Siguiente":
                    _num_pagina = _paginador.siguiente();
                    break;
                case "Ultimo":
                    _num_pagina = _paginador.ultimo();
                    break;
            }
            SearchEstudiante("");
        }

        #region procedemientos anulados

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

        /// <summary>
        /// Limpiar todos los controles
        /// </summary>
        /// <param name="c"></param>
        //public void limpiarControles(bool boolControles)
        //{
        //    if (boolControles)
        //    {
        //        for (int i = 0; i < listTextBox.Count; i++)
        //        {
        //            listTextBox[i].Text = string.Empty;
        //        }
        //    }
        //}

        #endregion procedemientos anulados
    }
    #endregion Procedimientos
}

