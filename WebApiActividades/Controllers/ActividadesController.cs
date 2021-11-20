using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Dominio;
using Repositorios;

namespace WebApiActividades.Controllers
{
    public class ActividadesController : ApiController
    {
        private ClubContext db = new ClubContext();


        // GET: odata/ActividadWebApi/texto
        //buscar actividad por texto incluido en el nombre
        [Route("api/Actividades/GetByName/{texto}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByName(string texto)
        {
            var actvidades = db.Actividades.Where(c => c.Nombre.Contains(texto))
                .OrderBy(a => a.Nombre)
                .ThenBy(a => a.ActividadHorarios.OrderBy(h => h.DiaSemana)
                .ThenBy(h => h.Hora)).ToList();

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
        [Route("api/Actividades/GetByMinAge/{minEdad}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByMinAge(int minEdad)
        {
            var actvidades = db.Actividades.Where(c => c.EdadMinima == minEdad)
                .OrderBy(a => a.Nombre)
                .ThenBy(a => a.ActividadHorarios.OrderBy(h => h.DiaSemana)
                .ThenBy(h => h.Hora)).ToList();

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
        [Route("api/Actividades/GetBySchedule/{dia}/{hora}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetBySchedule(DayOfWeek dia, int hora)
        {
            var actvidades = db.Actividades.Where(a => a.ActividadHorarios.Any(ah => ah.DiaSemana == dia && ah.Hora == hora))
                .OrderBy(a => a.Nombre)
                .ThenBy(a => a.ActividadHorarios.OrderBy(h => h.DiaSemana)
                .ThenBy(h => h.Hora)).ToList();

            if (actvidades.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(actvidades);
            }
        }



        // GET: api/Actividades
        public IQueryable<Actividad> GetActividades()
        {
            return db.Actividades;
        }

        // GET: api/Actividades/5
        [ResponseType(typeof(Actividad))]
        public IHttpActionResult GetActividad(int id)
        {
            Actividad actividad = db.Actividades.Find(id);
            if (actividad == null)
            {
                return NotFound();
            }

            return Ok(actividad);
        }

        // PUT: api/Actividades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutActividad(int id, Actividad actividad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != actividad.Id)
            {
                return BadRequest();
            }

            db.Entry(actividad).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Actividades
        [ResponseType(typeof(Actividad))]
        public IHttpActionResult PostActividad(Actividad actividad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Actividades.Add(actividad);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = actividad.Id }, actividad);
        }

        // DELETE: api/Actividades/5
        [ResponseType(typeof(Actividad))]
        public IHttpActionResult DeleteActividad(int id)
        {
            Actividad actividad = db.Actividades.Find(id);
            if (actividad == null)
            {
                return NotFound();
            }

            db.Actividades.Remove(actividad);
            db.SaveChanges();

            return Ok(actividad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ActividadExists(int id)
        {
            return db.Actividades.Count(e => e.Id == id) > 0;
        }
    }
}