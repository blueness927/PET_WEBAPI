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
using WEBAPI_Animal.Models;

namespace WEBAPI_Animal.Controllers.v1
{
    public class followsController : ApiController
    {
        private petstationEntities db = new petstationEntities();

        // GET: api/follows
        public IQueryable<follow> Getfollow()
        {
            return db.follow;
        }

        // GET: api/follows/5
        [ResponseType(typeof(follow))]
        public IHttpActionResult Getfollow(int id)
        {
            follow follow = db.follow.Find(id);
            if (follow == null)
            {
                return NotFound();
            }

            return Ok(follow);
        }

        // PUT: api/follows/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putfollow(int id, follow follow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != follow.followID)
            {
                return BadRequest();
            }

            db.Entry(follow).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!followExists(id))
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

        // POST: api/follows
        [ResponseType(typeof(follow))]
        public IHttpActionResult Postfollow(follow follow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.follow.Add(follow);
            db.SaveChanges();

            return CreatedAtRoute("Apiv1", new { id = follow.followID }, follow);
        }

        // DELETE: api/follows/5
        [ResponseType(typeof(follow))]
        public IHttpActionResult Deletefollow(int id)
        {
            follow follow = db.follow.Find(id);
            if (follow == null)
            {
                return NotFound();
            }

            db.follow.Remove(follow);
            db.SaveChanges();

            return Ok(follow);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool followExists(int id)
        {
            return db.follow.Count(e => e.followID == id) > 0;
        }
    }
}