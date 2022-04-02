using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Logica_Negocio.Library
{
	public class Paginador<T>
	{
		private List<T> _dataList;
		private Label _label;
        private static int maxReg;
        private static int _reg_por_pagina;
        private static int pageCount;
        private static int numPagi = 1;
        

        public Paginador(List<T> dataList, Label label, int reg_por_pagina)
        {
            _dataList = dataList;
            _label = label;
            _reg_por_pagina = reg_por_pagina;
            cargarDatos();
        }
        private void cargarDatos()
        {
            numPagi = 1;
            maxReg = _dataList.Count;
            pageCount = (maxReg / _reg_por_pagina);
            //Ajuste el numero de la página si la ultima pagina contiene
            //Una parte de la pagina
            if ((maxReg % _reg_por_pagina) > 0)
            {
                //Creamos una pagina nueva
                pageCount += 1;
            }
            _label.Text = $"Pagina 1/ {pageCount}";
        }
        public int primero()
        {
            numPagi = 1;
            _label.Text = $"Paginas {numPagi}/{pageCount}";
            return numPagi;
        }

        public int anterior()
        {
            if (numPagi>1)
            {
                numPagi -= 1;
                _label.Text = $"Paginas {numPagi}/{pageCount}";
            }
            return numPagi;
        }

        /// <summary>
        /// Metodo para navegar a las siguientes paginas
        /// </summary>
        /// <returns></returns>
        public int siguiente()
        {
            if (numPagi == pageCount)
            {
                numPagi -= 1;
            }


            if (numPagi < pageCount)
            {
                numPagi += 1;
                _label.Text = $"Paginas{numPagi}/{pageCount}";
            }

            return numPagi;
        }

        public int ultimo()
        {
            numPagi = pageCount;
            _label.Text = $"Paginas {numPagi}/{pageCount}";
            return numPagi;
        }
            
    }
}

 