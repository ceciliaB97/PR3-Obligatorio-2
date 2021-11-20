using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Routing;
using System.Net.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using ClubDeportivo.Data;
using Dominio;

namespace ClubDeportivo.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using Dominio;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Actividad>("ActividadWebApi");
    builder.EntitySet<Horario>("Horarios"); 
    builder.EntitySet<Membresia>("Membresias"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ActividadWebApiController : ODataController
    {
        private ClubDeportivoContext db = new ClubDeportivoContext();

        // GET: odata/ActividadWebApi/texto
        //buscar actividad por texto incluido en el nombre
        [Route("api/ActividadWebApiController/GetActividadNombre/{texto}")]
        [AcceptVerbs("GET")]
        [EnableQuery]
        public IHttpActionResult GetActividadNombre(string texto)
        {
            var actvidades = db.Actividads.Where(c => c.Nombre.Contains(texto)).ToList();

            if (actvidades.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(actvidades);
            }
        }

        // GET: odata/ActividadWebApi/minEdad
        //buscar actividad por cota minima de edad
        [Route("api/ActividadWebApiController/GetActividadMinEdad/{minEdad}")]
        [AcceptVerbs("GET")]
        [EnableQuery]
        public IHttpActionResult GetActividadMinEdad(int minEdad)
        {
            var actvidades = db.Actividads.Where(c => c.EdadMinima == minEdad).ToList();

            if (actvidades.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(actvidades);
            }
        }

        // GET: odata/ActividadWebApi(5)/ActividadHorarios/diaHora
        //buscar actividad por cota minima de edad
        [Route("api/ActividadWebApiController/GetActividadHorariosDiaHora/{dia}{hora}")]
        [AcceptVerbs("GET")]
        [EnableQuery]
        public IHttpActionResult GetActividadHorariosDiaHora(DayOfWeek dia, int hora)
        {
            var actvidades = db.Actividads.Where(a => a.ActividadHorarios.Any(ah => ah.DiaSemana == dia && ah.Hora == hora)).ToList();

            if (actvidades.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(actvidades);
            }
        }

        // GET: odata/ActividadWebApi
        [EnableQuery]
        public List<Actividad> GetActividadWebApi()
        {
            return db.Actividads.ToList();
        }

        // GET: odata/ActividadWebApi(5)
        [EnableQuery]
        public SingleResult<Actividad> GetActividad([FromODataUri] int key)
        {
            return SingleResult.Create(db.Actividads.Where(actividad => actividad.Id == key));
        }

        // PUT: odata/ActividadWebApi(5)
        //put: MODIFICAR ACTIVIDAD
        public IHttpActionResult Put([FromODataUri] int key, Delta<Actividad> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Actividad actividad = db.Actividads.Find(key);
            if (actividad == null)
            {
                return NotFound();
            }

            //se modifica la actividad
            patch.Put(actividad);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(actividad);
        }

        // POST: odata/ActividadWebApi
        //CREACION DE NUEVA ACTIVIDAD
        public IHttpActionResult Post(Actividad actividad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Actividads.Add(actividad);
            db.SaveChanges();

            return Created(actividad);
        }

        // PATCH: odata/ActividadWebApi(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Actividad> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Actividad actividad = db.Actividads.Find(key);
            if (actividad == null)
            {
                return NotFound();
            }

            patch.Patch(actividad);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(actividad);
        }

        // DELETE: odata/ActividadWebApi(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Actividad actividad = db.Actividads.Find(key);
            if (actividad == null)
            {
                return NotFound();
            }

            db.Actividads.Remove(actividad);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ActividadWebApi(5)/ActividadHorarios
        [EnableQuery]
        public IQueryable<Horario> GetActividadHorarios([FromODataUri] int key)
        {
            return db.Actividads.Where(m => m.Id == key).SelectMany(m => m.ActividadHorarios);
        }

        // GET: odata/ActividadWebApi(5)/Membresia
        [EnableQuery]
        public SingleResult<Membresia> GetMembresia([FromODataUri] int key)
        {
            return SingleResult.Create(db.Actividads.Where(m => m.Id == key).Select(m => m.Membresia));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActividadExists(int key)
        {
            return db.Actividads.Count(e => e.Id == key) > 0;
        }
    }
}
