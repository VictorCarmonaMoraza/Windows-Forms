using Logica_Negocio.Library;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Logica_Negocio
{
    public class Estudiantes : Libreria
    {
        private List<TextBox> listTextBox;

        public Estudiantes(List<TextBox> listTextBox)
        {
            this.listTextBox = listTextBox;
        }
    }
}
