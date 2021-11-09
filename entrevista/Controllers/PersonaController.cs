using entrevista.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entrevista.Controllers
{
    public class PersonaController : Controller
    {
        private readonly DataContext context;
        public PersonaController(DataContext cont)
        {
            this.context = cont;
        }
        public ActionResult Index()
        {
            return View();
        }        

        [HttpPost]
        [Route("EditarPersona")]
        public ActionResult EditarPersona(int id, string mail, List<int> cursos)
        {
            Persona pers = Persona.ObtenerPersonaPorId(context,id);
            pers.mail = mail;
            
            List<Curso> lstCursos = new List<Curso>();
            foreach (int i in cursos)
            {
                var curso = Curso.ObtenerCursoPorId(context, i);
                if (curso != null)
                    lstCursos.Add(curso);
            }
            pers.cursos = lstCursos;
            context.Update(pers);
            return Json(new { msg = "Editada correctamente", pers });
        }
        [HttpPost]
        [Route("NuevaPersona")]
        public ActionResult NuevaPersona(string mail, List<int> cursos)
        {
            Persona pers = new Persona();
            pers.mail = mail;
            List<Curso> lstCursos = new List<Curso>();
            foreach (int i in cursos)
            {
                var curso = Curso.ObtenerCursoPorId(context, i);
                if (curso != null)
                    lstCursos.Add(curso);
            }
            pers.cursos = lstCursos;
            context.Persona.Add(pers);
            return Json(new { msg = "Creada correctamente", pers });
        }

        [HttpPost]
        [Route("EliminarPersona")]
        public ActionResult EliminarPersona(int id)
        {
            Persona pers = Persona.ObtenerPersonaPorId(context, id);
            context.Persona.Remove(pers);
            return Json(new { msg = "Eliminada correctamente"});
        }

        [HttpPost]
        [Route("AgregarCurso")]
        public ActionResult AgregarCurso(int persId, int curso)
        {
            Persona pers = Persona.ObtenerPersonaPorId(context, persId);
            Empresa emp = context.Empresa.Where(x => x.contactos.Any(y => y.id == persId)).FirstOrDefault();
            if (emp != null)
            {
                // if (pers.cursos.Any(fechaVencida)){
                //var  msg = "no puede agregarlo";                //
                // }else{
            // persona.cursos(context.Curso.Where(x => x.Id = curso);
            // }
                // ----- NO  SE ACLARA COMO SABER SI ESTA VENCIDO O NO
            }
            context.SaveChanges();
            return Json(new { msg = "Agregado correctamente", emp });
        }


        [Route("ObtenerPersona")]
        public ActionResult ObtenerPersonaPorId(int id)
        {
            return Json(new { emp = Persona.ObtenerPersonaPorId(context, id) });
        }       
    }
}
