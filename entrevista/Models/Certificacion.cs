using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entrevista.Models
{
    public enum enumCertif
    {
        Producto, Sistemas, Alimentos, CompetenciasPersonales
    }
    public class Certificacion
    {
        public int id { get; set; }
        public enumCertif certificacion { get; set; }
        public string descripcion { get; set; }
        public DateTime emision { get; set; }
        public DateTime vencimiento { get; set; }
        public static Certificacion ObtenerCertificacionPorId(DataContext context, int i)
        {
            return context.Certificacion.Where(x => x.id == i).FirstOrDefault();
        }
    }
}
