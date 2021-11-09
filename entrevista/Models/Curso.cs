using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entrevista.Models
{
    public enum enumMod
    {
        Virtual, Presencial
    }
    public class Curso
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public enumMod modalidad { get; set; }
        public ICollection<Fecha> fechas { get; set; }
        public int empresaId { get; set; }
        public Empresa empresa { get; set; }
        public int contactoId { get; set; }
        public Persona contacto { get; set; }

        public static Curso ObtenerCursoPorId(DataContext context, int i)
        {
            return context.Curso.Where(x => x.id == i).FirstOrDefault();
        }
    }
}
