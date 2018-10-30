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
using To_DoPapukaija.Models;

namespace To_DoPapukaija.Controllers
{
    public class TehtavatController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Tehtavat
        public IQueryable<Tehtava> GetTehtava()
        {
            return db.Tehtava;
        }

        // GET: api/Tehtavat/5
        [ResponseType(typeof(Tehtava))]
        public IHttpActionResult GetTehtava(int id)
        {
            Tehtava tehtava = db.Tehtava.Find(id);
            if (tehtava == null)
            {
                return NotFound();
            }

            return Ok(tehtava);
        }

        // PUT: api/Tehtavat/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTehtava(int id, Tehtava tehtava)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tehtava.TehtavaID)
            {
                return BadRequest();
            }

            db.Entry(tehtava).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TehtavaExists(id))
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

        // POST: api/Tehtavat
        [ResponseType(typeof(Tehtava))]
        public IHttpActionResult PostTehtava(Tehtava tehtava)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tehtava.Add(tehtava);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tehtava.TehtavaID }, tehtava);
        }

        // DELETE: api/Tehtavat/5
        [ResponseType(typeof(Tehtava))]
        public IHttpActionResult DeleteTehtava(int id)
        {
            Tehtava tehtava = db.Tehtava.Find(id);
            if (tehtava == null)
            {
                return NotFound();
            }

            db.Tehtava.Remove(tehtava);
            db.SaveChanges();

            return Ok(tehtava);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TehtavaExists(int id)
        {
            return db.Tehtava.Count(e => e.TehtavaID == id) > 0;
        }
    }
}