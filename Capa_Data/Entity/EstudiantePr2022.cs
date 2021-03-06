using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Data.Entity
{
    public class EstudiantePr2022
    {
        [PrimaryKey, Identity]
        public int id { get; set; }
        public string nid { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        //Array de byte que contendra la imagen
        public byte[] image { get; set; }
    }
}
