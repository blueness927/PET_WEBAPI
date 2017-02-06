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
    public class followAnisController : BaseController
    {
      
        // GET: api/followAnis
        public IQueryable<followAni> GetfollowAni()
        {
            return db.followAni;
        }

        // GET: api/followAnis/5
        [ResponseType(typeof(followAni))]
        public IHttpActionResult GetfollowAni(string id)
        {
            var followAni = db.followAni.Where(x => x.follow_userId.Equals(id)).ToList();
            if (followAni == null)
            {
                return NotFound();
            }

            return Ok(followAni);
        }

        // PUT: api/follows/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putfollow(string id, follow follow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != follow.follow_userId)
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

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (followExists(follow.follow_userId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("Apiv1", new { id = follow.follow_userId }, follow);
        }

        //// DELETE: api/followsAni/5
        //[ResponseType(typeof(follow))]
        //public IHttpActionResult Deletefollow(int id)
        //{
        //    var follow = db.follow.Where(x => x.follow_animalID==id).ToList();
        //    if (follow == null)
        //    {
        //        return NotFound();
        //    }

        //    db.follow.Remove(follow);
        //    db.SaveChanges();

        //    return Ok(follow);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool followExists(string id)
        {
            return db.follow.Count(e => e.follow_userId == id) > 0;
        }
    }
}