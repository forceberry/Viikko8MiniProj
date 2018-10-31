using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using To_DoPapukaija.Models;

namespace To_DoPapukaija.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods:"*")]
    public class KayttajatController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Kayttajat
        public IQueryable<Kayttaja> GetKayttaja()
        {
            return db.Kayttaja;
        }

        // GET: api/Kayttajat/5
        [ResponseType(typeof(Kayttaja))]
        public IHttpActionResult GetKayttaja(int id)
        {
            Kayttaja kayttaja = db.Kayttaja.Find(id);
            if (kayttaja == null)
            {
                return NotFound();
            }

            return Ok(kayttaja);
        }

        // PUT: api/Kayttajat/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKayttaja(int id, Kayttaja kayttaja)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kayttaja.ID)
            {
                return BadRequest();
            }

            db.Entry(kayttaja).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KayttajaExists(id))
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

        // POST: api/Kayttajat
        [ResponseType(typeof(Kayttaja))]
        public IHttpActionResult PostKayttaja(Kayttaja kayttaja)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kayttaja.Add(kayttaja);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kayttaja.ID }, kayttaja);
        }

        // DELETE: api/Kayttajat/5
        [ResponseType(typeof(Kayttaja))]
        public IHttpActionResult DeleteKayttaja(int id)
        {
            Kayttaja kayttaja = db.Kayttaja.Find(id);
            if (kayttaja == null)
            {
                return NotFound();
            }

            db.Kayttaja.Remove(kayttaja);
            db.SaveChanges();

            return Ok(kayttaja);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KayttajaExists(int id)
        {
            return db.Kayttaja.Count(e => e.ID == id) > 0;
        }
    }
}