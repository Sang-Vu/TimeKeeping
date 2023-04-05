using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using myWebApp;

namespace myWebApp.Controllers.api
{
    public class Administrators1Controller : ApiController
    {
        private myappEntities db = new myappEntities();

        // GET: api/Administrators1
        public IQueryable<administrator> Getadministrator()
        {
            return db.administrator;
        }

        // GET: api/Administrators1/5
        [ResponseType(typeof(administrator))]
        public async Task<IHttpActionResult> Getadministrator(string id)
        {
            administrator administrator = await db.administrator.FindAsync(id);
            if (administrator == null)
            {
                return NotFound();
            }

            return Ok(administrator);
        }

        // PUT: api/Administrators1/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putadministrator(string id, administrator administrator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != administrator.userName)
            {
                return BadRequest();
            }

            db.Entry(administrator).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!administratorExists(id))
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

        // POST: api/Administrators1
        [ResponseType(typeof(administrator))]
        public async Task<IHttpActionResult> Postadministrator(administrator administrator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.administrator.Add(administrator);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (administratorExists(administrator.userName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = administrator.userName }, administrator);
        }

        // DELETE: api/Administrators1/5
        [ResponseType(typeof(administrator))]
        public async Task<IHttpActionResult> Deleteadministrator(string id)
        {
            administrator administrator = await db.administrator.FindAsync(id);
            if (administrator == null)
            {
                return NotFound();
            }

            db.administrator.Remove(administrator);
            await db.SaveChangesAsync();

            return Ok(administrator);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool administratorExists(string id)
        {
            return db.administrator.Count(e => e.userName == id) > 0;
        }
    }
}