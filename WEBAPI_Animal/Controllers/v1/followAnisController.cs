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
        /// <summary>
        /// 一次取得所有會員的追蹤清單
        /// PS.請無視testid的欄位值
        /// </summary>
        /// <returns></returns>
        // GET: api/followAnis
        public IQueryable<followAni> GetfollowAni()
        {
            return db.followAni;
        }

        /// <summary>
        /// 取得單一會員的追蹤清單
        /// 範例：api/v1/followAnis/0cee9178-0b2d-42e9-859d-cf061e4750f3
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/followAnis/userid
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

        /// <summary>
        /// 新增一筆要追蹤的動物，userid及animalid已綁fk,若填入的值無法對應，則無法做新增
        /// </summary>
        /// <param name="follow"></param>
        /// <returns></returns>
        // POST: api/follows
        //[Authorize]
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

        /// <summary>
        /// 刪除一筆追蹤的資料，以follow ID為主鍵，故刪除時須先取得對應的id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/followsAni/5
        [Authorize]
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

        private bool followExists(string id)
        {
            return db.follow.Count(e => e.follow_userId == id) > 0;
        }
    }
}