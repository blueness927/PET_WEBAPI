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
    public class animalData_PicController : BaseController
    {

        /// <summary>
        /// 取得所有PIC資料(不含動物資料)
        /// </summary>
        /// <returns></returns>
        // GET: api/animalData_Pic
        public IQueryable<animalData_Pic> GetanimalData_Pic()
        {
            return db.animalData_Pic;
        }


        /// <summary>
        /// 以animalPic_animalID為主要搜尋ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/animalData_Pic/5
        [ResponseType(typeof(animalData_Pic))]
        public IHttpActionResult GetanimalData_Pic(int id)
        {
            var animalDataPic = db.animalData_Pic.Where(x => x.animalPic_animalID == id).ToList();

            if (animalDataPic == null)
            {
                return NotFound();
            }

            return Ok(animalDataPic);
        }


        /// <summary>
        /// 以animalPicID為主要修改ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="animalData_Pic"></param>
        /// <returns></returns>
        // PUT: api/animalData_Pic/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutanimalData_Pic(int id, animalData_Pic animalData_Pic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != animalData_Pic.animalPicID)
            {
                return BadRequest();
            }

            db.Entry(animalData_Pic).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!animalData_PicExists(id))
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
        /// 新增資料時，animalPic_animalID需自行將ID帶入
        /// </summary>
        /// <param name="animalData_Pic"></param>
        /// <returns></returns>
        // POST: api/animalData_Pic
        [ResponseType(typeof(animalData_Pic))]
        public IHttpActionResult PostanimalData_Pic(animalData_Pic animalData_Pic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.animalData_Pic.Add(animalData_Pic);
            db.SaveChanges();

            return CreatedAtRoute("Apiv1", new { id = animalData_Pic.animalPicID }, animalData_Pic);
        }


        /// <summary>
        /// 以animalPicID為主要ID
        /// 要刪除資料時，請先紀錄該動物的id去做對應刪除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/animalData_Pic/5
        [ResponseType(typeof(animalData_Pic))]
        public IHttpActionResult DeleteanimalData_Pic(int id)
        {
            animalData_Pic animalData_Pic = db.animalData_Pic.Find(id);
            if (animalData_Pic == null)
            {
                return NotFound();
            }

            db.animalData_Pic.Remove(animalData_Pic);
            db.SaveChanges();

            return Ok(animalData_Pic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool animalData_PicExists(int id)
        {
            return db.animalData_Pic.Count(e => e.animalPicID == id) > 0;
        }
    }
}