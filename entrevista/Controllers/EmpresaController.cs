using entrevista.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entrevista.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly DataContext context;
        // GET: Empresa

        public EmpresaController(DataContext cont)
        {
            this.context = cont;
        }
        public ActionResult Index()
        {
            return View();
        }        

        [HttpPost]
        [Route("EditarEmpresa")]
        public ActionResult EditarEmpresa(int id, string raz, string dir, int tel, string web, string ema, List<int> contactos)
        {
            Empresa emp = Empresa.ObtenerEmpresaPorId(context, id);
            emp.razonSocial = raz;
            emp.direccion = dir;
            emp.telefono = tel;
            emp.web = web;
            emp.email = ema;
            List<Persona> lstPersonas = new List<Persona>();
            foreach (int i in contactos)
            {
                var persona = Persona.ObtenerPersonaPorId(context, i);
                if (persona != null)
                    lstPersonas.Add(persona);
            }
            emp.contactos = lstPersonas;
            context.Update(emp);
            context.SaveChanges();
            return Json(new { msg = "Editada correctamente", id});
        }
        [HttpPost]
        [Route("NuevaEmpresa")]
        public ActionResult NuevaEmpresa(string raz, string dir, int tel, string web, string ema, List<int> contactos)
        {
            Empresa emp = new Empresa();
            emp.razonSocial = raz;
            emp.direccion = dir;
            emp.telefono = tel;
            emp.web = web;
            emp.email = ema;
            List<Persona> lstPersonas = new List<Persona>();
            foreach (int i in contactos)
            {
                var persona = Persona.ObtenerPersonaPorId(context, i);
                if (persona != null)
                    lstPersonas.Add(persona);
            }
            emp.contactos = lstPersonas;
            context.Empresa.Add(emp);
            context.SaveChanges();
            return Json(new { msg = "Creada correctamente", emp});
        }

        [HttpPost]
        [Route("EliminarEmpresa")]
        public ActionResult EliminarEmpresa(int id)
        {
            Empresa emp = Empresa.ObtenerEmpresaPorId(context, id);
            context.Empresa.Remove(emp);
            context.SaveChanges();
            return Json(new { msg = "Eliminada correctamente", emp });
        }

        [Route("ObtenerEmpresa")]
        public ActionResult ObtenerEmpresaPorId(int id)
        {
            return Json(new {emp = Empresa.ObtenerEmpresaPorId(context, id) });
        }       
    }
}
