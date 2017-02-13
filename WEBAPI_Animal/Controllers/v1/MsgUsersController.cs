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
    public class MsgUsersController : BaseController
    {
       
        /// <summary>
        /// 取得所有訊息資訊
        /// </summary>
        /// <returns></returns>
        // GET: api/MsgUsers
        public IQueryable<MsgUser> GetMsgUser()
        {
            return db.MsgUser;
        }
        /// <summary>
        /// 取得寄信人資訊
        /// 範例：api/v1/MsgUsers/01d7f07d-9676-4de8-bc5f-44faf3ab0551
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/MsgUsers/ToID
        [ResponseType(typeof(MsgUser))]
        public IHttpActionResult GetMsgUser(string id)
        {
            var msgUser = db.MsgUser.Where(x => x.msgTo_userID.Equals(id)).ToList();
            if (msgUser == null)
            {
                return NotFound();
            }

            return Ok(msgUser);
        }
        /// <summary>
        /// 新增一筆訊息，將收信者(To)跟寄信者(Form)的ID請用變數自行帶入參數
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        // POST: api/MsgUsers
        [Authorize]
        [ResponseType(typeof(Msg))]
        public IHttpActionResult PostMsg(Msg msg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Msg.Add(msg);
            db.SaveChanges();

            return CreatedAtRoute("Apiv1", new { id = msg.msgID }, msg);
        }
        /// <summary>
        /// 刪除一筆訊息，以Msgid為主要刪除主鍵，故刪除時請先取得要刪除訊息的msgid
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/MsgUsers/5
        [Authorize]
        [ResponseType(typeof(Msg))]
        public IHttpActionResult DeleteMsgUser(int id)
        {
            Msg msg = db.Msg.Find(id);
            if (msg == null)
            {
                return NotFound();
            }

            db.Msg.Remove(msg);
            db.SaveChanges();

            return Ok(msg);
        }

        /// <summary>
        /// 用來修改已讀未讀
        /// </summary>
        /// <param name="id"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        // PUT: api/Msgs/5

        [ResponseType(typeof(void))]
        public IHttpActionResult PutMsg(int id, Msg msg)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != msg.msgID)
            {
                return BadRequest();
            }

            db.Entry(msg).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MsgUserExists(id))
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MsgUserExists(int id)
        {
            return db.Msg.Count(e => e.msgID == id) > 0;
        }
    }
}