using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ecommercepharma.Models;
using ecommercepharma.Models.DBmodels;

namespace ecommercepharma.Controllers
{
    public class PaqueteController : Controller
    {
        private readonly DALPackages dbPaquete = new DALPackages();
        // GET: Paquete
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult GetPackages()
        {
            var packages = dbPaquete.ListarPaquetes();
            return Json(new { paquetes = packages });
        }

        [HttpPost]
        public ActionResult Post([FromBody]PaqueteModel paquete)
        {
            var insertResult = dbPaquete.InsertarPaquete(paquete);
            if (insertResult.ToLower().Contains("error"))
            {
                return Json(new { status = 400, message = insertResult });
            }
            return Json(new { status = 200, message = insertResult });
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var deleteResult = dbPaquete.EliminarPaquete(id);
            if (deleteResult <= 0)
            {
                return Json(new { status = 400, message = "Error, no se pudo eliminar el registro" });
            }
            return Json(new 
                        { status = 200, 
                          message = "El paquete ha sido eliminado de manera correcta" 
                         });
        }

    }
}