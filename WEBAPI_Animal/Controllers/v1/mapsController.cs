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
    public class mapsController : ApiController
    {
        private petstationEntities db = new petstationEntities();
        /// <summary>
        /// 取得全部動物醫院詳細位置資料
        /// </summary>
        /// <returns></returns>
        // GET: api/maps
        public IQueryable<map> Getmap()
        {
            return db.map;
        }
        /// <summary>
        /// 取得一筆動物醫院詳細位置資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/maps/5
        [ResponseType(typeof(map))]
        public IHttpActionResult Getmap(int id)
        {
            map map = db.map.Find(id);
            if (map == null)
            {
                return NotFound();
            }

            return Ok(map);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool mapExists(int id)
        {
            return db.map.Count(e => e.mapID == id) > 0;
        }
    }
}