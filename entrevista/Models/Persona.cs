using entrevista.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entrevista.Models
{
    public class Persona
    {
        public int id { get; set; }
        public string mail { get; set; }
        public ICollection<Curso> cursos { get; set; }


        public static Persona ObtenerPersonaPorId(DataContext context, int i)
        {
            return context.Persona.Where(x => x.id == i).FirstOrDefault();
        }
    }    
}
