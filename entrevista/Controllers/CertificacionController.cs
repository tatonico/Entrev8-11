using entrevista.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entrevista.Controllers
{
    public class CertificacionController : Controller
    {
        private readonly DataContext context;
        // GET: Empresa
        public CertificacionController(DataContext cont)
        {
            this.context = cont;
        }
        public ActionResult Index()
        {
            return View();
        }        

        [HttpPost]
        [Route("EditarCertificacion")]
        public ActionResult EditarCertificacion([FromBody] int id, enumCertif cert, string desc, DateTime emi, DateTime vencimiento)
        {
            Certificacion cer = Certificacion.ObtenerCertificacionPorId(context,id);
            cer.certificacion = cert;
            cer.descripcion = desc;
            cer.emision = emi;
            cer.vencimiento = vencimiento;                      
            context.Update(cer);
            context.SaveChanges();
            return Json(new { msg = "Editada Correctamente", cer });
        }
        [HttpPost]
        [Route("NuevaCertificacion")]
        public ActionResult NuevaCertificacion([FromBody] enumCertif cert, string desc, DateTime emi, DateTime vencimiento)
        {
            Certificacion cer = new Certificacion();
            cer.certificacion = cert;
            cer.descripcion = desc;
            cer.emision = emi;
            cer.vencimiento = vencimiento;
            context.Add(cer);
            context.SaveChanges();
            return Json(new { msg = "Creada Correctamente", cer });
        }
       

        
        [HttpPost]
        [Route ("EliminarCertificacion")]
        public ActionResult EliminarCertificacion([FromBody] int id)
        {
            Certificacion cer = Certificacion.ObtenerCertificacionPorId(context, id);
            context.Certificacion.Remove(cer);
            context.SaveChanges();
            return Json(new { msg = "Eliminada Correctamente" });
        }

        [Route("ObtenerEmpresa")]
        public ActionResult ObtenerEmpresaPorId(int id)
        {
            return Json(new { emp = Empresa.ObtenerEmpresaPorId(context, id) });            
        }       
    }
}
