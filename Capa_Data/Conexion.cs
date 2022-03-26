using Capa_Data.Entity;
using LinqToDB;
using LinqToDB.Data;

namespace Capa_Data
{
    public class Conexion:DataConnection
    {
        public Conexion() : base("VictorCursoNetCore") { }

        public ITable<EstudiantePr2022> _Estudiante { get { return GetTable<EstudiantePr2022>(); } }
    }
}
