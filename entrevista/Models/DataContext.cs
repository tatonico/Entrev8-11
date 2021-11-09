using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static entrevista.Models.DataContext;

namespace entrevista.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public  DbSet<Empresa> Empresa { get; set; }
        public  DbSet<Curso> Curso { get; set; }
        public  DbSet<Persona> Persona { get; set; }
        public  DbSet<Certificacion> Certificacion { get; set; }
        public  DbSet<Fecha> Fecha { get; set; }

    }

        

        

        

        

        

}

