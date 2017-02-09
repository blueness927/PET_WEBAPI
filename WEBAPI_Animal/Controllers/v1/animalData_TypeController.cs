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
using System.Web.Http.Cors;

namespace WEBAPI_Animal.Controllers.v1
{
    public class animalData_TypeController : BaseController
    {

        /// <summary>
        /// 取得全部
        /// </summary>
        /// <returns></returns>
        // GET: api/animalData_Type
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IQueryable<animalData_Type> GetanimalData_Type()
        {
            return db.animalData_Type;
        }

        /// <summary>
        /// 取得單一筆資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

       
        /// <summary>
        /// 新增單筆
        /// </summary>
        /// <param name="animalData_Type"></param>
        /// <returns></returns>
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

            return CreatedAtRoute("Apiv1", new { id = animalData_Type.animalTypeID }, animalData_Type);
        }

        /// <summary>
        /// 刪除單筆
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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