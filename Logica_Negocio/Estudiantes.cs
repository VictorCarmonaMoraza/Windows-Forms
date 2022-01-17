using Logica_Negocio.Library;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Logica_Negocio
{
    public class Estudiantes : Libreria
    {
        private List<TextBox> listTextBox;
        private List<Label> listLabel;


        public Estudiantes(List<TextBox> listTextBox, List<Label> listLabel)
        {
            this.listTextBox = listTextBox;
            this.listLabel = listLabel;
        }

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

                        }
                    }
                }
            }
        }
    }
}

