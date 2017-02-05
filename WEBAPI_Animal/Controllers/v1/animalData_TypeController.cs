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
    public class animalData_TypeController : BaseController
    {
      

        // GET: api/animalData_Type
        public IQueryable<animalData_Type> GetanimalData_Type()
        {
            return db.animalData_Type;
        }

        // GET: api/animalData_Type/5
        [ResponseType(typeof(animalData_Type))]
        public IHttpActionResult GetanimalData_Type(int id)
        {
            animalData_Type animalData_Type = db.animalData_Type.Find(id);
            if (animalData_Type == null)
            {
                return NotFound();
            }

            return Ok(animalData_Type);
        }

        // PUT: api/animalData_Type/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutanimalData_Type(int id, animalData_Type animalData_Type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != animalData_Type.animalTypeID)
            {
                return BadRequest();
            }

            db.Entry(animalData_Type).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!animalData_TypeExists(id))
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

        // POST: api/animalData_Type
        [ResponseType(typeof(animalData_Type))]
        public IHttpActionResult PostanimalData_Type(animalData_Type animalData_Type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.animalData_Type.Add(animalData_Type);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = animalData_Type.animalTypeID }, animalData_Type);
        }

        // DELETE: api/animalData_Type/5
        [ResponseType(typeof(animalData_Type))]
        public IHttpActionResult DeleteanimalData_Type(int id)
        {
            animalData_Type animalData_Type = db.animalData_Type.Find(id);
            if (animalData_Type == null)
            {
                return NotFound();
            }

            db.animalData_Type.Remove(animalData_Type);
            db.SaveChanges();

            return Ok(animalData_Type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool animalData_TypeExists(int id)
        {
            return db.animalData_Type.Count(e => e.animalTypeID == id) > 0;
        }
    }
}