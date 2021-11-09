using entrevista.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entrevista.Controllers
{
    public class CursoController : Controller
    {
        private readonly DataContext context;

        public CursoController(DataContext cont)
        {
            this.context = cont;
        }
       
        public ActionResult Index()
        {
            return View();
        }        

        [HttpPost]
        [Route("EditarCurso")]
        public ActionResult EditarCurso([FromBody] int id, string tit, string desc, enumMod mod, List<DateTime> fec, int emp, int cont)
        {
            Curso curs = Curso.ObtenerCursoPorId(context,id);
            curs.titulo = tit;
            curs.descripcion = desc;
            curs.modalidad = mod;
            curs.empresa = Empresa.ObtenerEmpresaPorId(context,emp);
            curs.empresaId = emp;
            curs.contacto = Persona.ObtenerPersonaPorId(context, cont);
            curs.contactoId = cont;           
            List<Fecha> lstFechas = new List<Fecha>();
            foreach (DateTime i in fec)
            {
                var fechaFor = new Fecha();
                fechaFor.Value = i;
                if (fec != null)
                {
                    lstFechas.Add(fechaFor);
                    context.Add(fechaFor);
                }             
            }
            curs.fechas = lstFechas;
            context.Update(curs);
            context.SaveChanges();
            return Json(new { msg = "Editado correctamente", curs });
        }
        [HttpPost]
        [Route("NuevoCurso")]
        public ActionResult NuevoCurso([FromBody] string tit, string desc, enumMod mod, List<DateTime> fec, int emp, int cont)
        {
            Curso curs = new Curso();
            curs.titulo = tit;
            curs.descripcion = desc;
            curs.modalidad = mod;
            curs.empresa = Empresa.ObtenerEmpresaPorId(context, emp);
            curs.empresaId = emp;
            curs.contacto = Persona.ObtenerPersonaPorId(context, cont);
            curs.contactoId = cont;
            List<Persona> lstPersonas = new List<Persona>();
            List<Fecha> lstFechas = new List<Fecha>();
            foreach (DateTime i in fec)
            {
                var fechaFor = new Fecha();
                fechaFor.Value = i;
                if (fec != null)
                {
                    lstFechas.Add(fechaFor);
                    context.Add(fechaFor);
                }
            }
            curs.fechas = lstFechas;
            context.Curso.Add(curs);
            context.SaveChanges();
            return Json(new { msg = "Creado correctamente", curs });
        }

        [HttpPost]
        [Route("EliminarCurso")]
        public ActionResult EliminarCurso([FromBody] int id)
        {
            Curso emp = Curso.ObtenerCursoPorId(context, id);
            context.Curso.Remove(emp);
            context.SaveChanges();
            return Json(new { msg = "Eliminado correctamente"});
        }
        [Route("ObtenerCurso")]
        public ActionResult ObtenerCursoPorId([FromBody] int id)
        {
            return Json(new { curso = Curso.ObtenerCursoPorId(context, id) });
        }       
    }
}
