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
            var msgUser = db.MsgUser.Where(x => x.msgTo_userID.Equals(id));
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