using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreVanillaJs3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("permitir")]
    public class PersonaController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            using (Models.CrudVanillaJsContext db = new Models.CrudVanillaJsContext())
            {
                var lst = (from d in db.Personas
                           select d).ToList();
                return Ok(lst);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Models.Request.PersonaRequest model) 
        {

            //conexion a la bd

            using (Models.CrudVanillaJsContext db = new Models.CrudVanillaJsContext())
            {
                //creando un objeto
                Models.Persona oPersona = new Models.Persona();
                oPersona.Nombre = model.Nombre;
                oPersona.Edad = model.Edad;
                db.Personas.Add(oPersona);
                //guardamos los cambios
                db.SaveChanges();
            }
            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Models.Request.PersonaEditRequest model)
        {

            //conexion a la bd

            using (Models.CrudVanillaJsContext db = new Models.CrudVanillaJsContext())
            {
                //creando un objeto
                Models.Persona oPersona = db.Personas.Find(model.Id);
                oPersona.Nombre = model.Nombre;
                oPersona.Edad = model.Edad;
                //inidicamos que se esta actualizando
                db.Entry(oPersona).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                //guardamos los cambios
                db.SaveChanges();
            }
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Models.Request.PersonaEditRequest model)
        {

            //conexion a la bd

            using (Models.CrudVanillaJsContext db = new Models.CrudVanillaJsContext())
            {
                //creando un objeto
                Models.Persona oPersona = db.Personas.Find(model.Id);
                db.Personas.Remove(oPersona);
                //guardamos los cambios
                db.SaveChanges();
            }
            return Ok();
        }


    }


}
