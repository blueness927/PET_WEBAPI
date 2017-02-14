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
    public class animalData_ConditionController : BaseController
    {
       /// <summary>
        /// 取得所有動物資料
        /// </summary>
        /// <returns>IQueryable &lt; Animal&gt;.</returns>
        ///GET: api/v1/AnimalDatas

        // GET: api/animalData_Condition
        public IQueryable<animalData_Condition> GetanimalData_Condition()
        {
            return db.animalData_Condition;
        }

        // GET: api/animalData_Condition/5

        [ResponseType(typeof(animalData_Condition))]
        public IHttpActionResult GetanimalData_Condition(int id)
        {
            animalData_Condition animalData_Condition = db.animalData_Condition.Find(id);
            if (animalData_Condition == null)
            {
                return NotFound();
            }

            return Ok(animalData_Condition);
        }

        // PUT: api/animalData_Condition/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutanimalData_Condition(int id, animalData_Condition animalData_Condition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != animalData_Condition.conditionID)
            {
                return BadRequest();
            }

            db.Entry(animalData_Condition).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!animalData_ConditionExists(id))
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

        // POST: api/animalData_Condition
        [Authorize]
        [ResponseType(typeof(animalData_Condition))]
        public IHttpActionResult PostanimalData_Condition(animalData_Condition animalData_Condition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.animalData_Condition.Add(animalData_Condition);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = animalData_Condition.conditionID }, animalData_Condition);
        }

        // DELETE: api/animalData_Condition/5
        [Authorize]
        [ResponseType(typeof(animalData_Condition))]
        public IHttpActionResult DeleteanimalData_Condition(int id)
        {
            animalData_Condition animalData_Condition = db.animalData_Condition.Find(id);
            if (animalData_Condition == null)
            {
                return NotFound();
            }

            db.animalData_Condition.Remove(animalData_Condition);
            db.SaveChanges();

            return Ok(animalData_Condition);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool animalData_ConditionExists(int id)
        {
            return db.animalData_Condition.Count(e => e.conditionID == id) > 0;
        }
    }
}