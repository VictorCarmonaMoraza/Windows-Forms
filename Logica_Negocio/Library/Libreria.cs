using Capa_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_Negocio.Library
{
    public class Libreria : Conexion
    {
        public UploadImage uploadImage = new UploadImage();
        public TextBoxEvent textBoxEvent = new TextBoxEvent();
    }
}
