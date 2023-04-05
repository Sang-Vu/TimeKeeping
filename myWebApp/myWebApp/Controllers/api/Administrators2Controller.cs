using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace myWebApp.Controllers.api
{
    public class Administrators2Controller : ApiController
    {
        private myappEntities db = new myappEntities();

        // GET: api/Administrators2
        [System.Web.Http.HttpGet]
        public IQueryable<administrator> Getadministrator()
        {
            return db.administrator;
        }

        // GET: api/Administrators2/5
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(administrator))]
        public IHttpActionResult Getadministrator(string id)
        {
            administrator administrator = db.administrator.Find(id);
            if (administrator == null)
            {
                return NotFound();
            }

            return Ok(administrator);
        }

        // PUT: api/Administrators2/5
        [System.Web.Http.HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult Putadministrator(string id, administrator administrator)
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
                db.SaveChanges();
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

        // POST: api/Administrators2
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(administrator))]
        public IHttpActionResult Postadministrator(administrator administrator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.administrator.Add(administrator);

            try
            {
                db.SaveChanges();
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

        // DELETE: api/Administrators2/5
        [System.Web.Http.HttpDelete]
        [ResponseType(typeof(administrator))]
        public IHttpActionResult Deleteadministrator(string id)
        {
            administrator administrator = db.administrator.Find(id);
            if (administrator == null)
            {
                return NotFound();
            }

            db.administrator.Remove(administrator);
            db.SaveChanges();

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