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
    public class searchesController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: api/searches
        public IQueryable<search> Getsearch()
        {
            return db.search;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/searches/5
        [ResponseType(typeof(search))]
        public IHttpActionResult Getsearch(int id)
        {
            search search = db.search.Find(id);
            if (search == null)
            {
                return NotFound();
            }

            return Ok(search);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        // PUT: api/searches/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsearch(int id, search search)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != search.SearchID)
            {
                return BadRequest();
            }

            db.Entry(search).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!searchExists(id))
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        // POST: api/searches
        [ResponseType(typeof(search))]
        public IHttpActionResult Postsearch(search search)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.search.Add(search);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = search.SearchID }, search);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/searches/5
        [ResponseType(typeof(search))]
        public IHttpActionResult Deletesearch(int id)
        {
            search search = db.search.Find(id);
            if (search == null)
            {
                return NotFound();
            }

            db.search.Remove(search);
            db.SaveChanges();

            return Ok(search);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool searchExists(int id)
        {
            return db.search.Count(e => e.SearchID == id) > 0;
        }
    }
}