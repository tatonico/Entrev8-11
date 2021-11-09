using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entrevista.Models
{
    public class Empresa
    {
        public int id { get; set; }
        public string razonSocial { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public string web { get; set; }
        public string email { get; set; }
        public ICollection<Persona> contactos { get; set; }

        public static Empresa ObtenerEmpresaPorId(DataContext context, int i)
        {
            return context.Empresa.Where(x => x.id == i).FirstOrDefault();
        }

        public static bool trabajaPersona(DataContext context, int persona)
        {
            return context.Empresa.Any(x=>x.contactos.Any(x => x.id == persona));
        }

    }
}
