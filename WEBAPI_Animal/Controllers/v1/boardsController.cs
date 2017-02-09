﻿using System;
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
    public class boardsController : BaseController
    {
       

        // GET: api/boards
        public IQueryable<board> Getboard()
        {
            return db.board;
        }

        // GET: api/boards/5
        [ResponseType(typeof(board))]
        public IHttpActionResult Getboard(int id)
        {
            board board = db.board.Find(id);
            if (board == null)
            {
                return NotFound();
            }

            return Ok(board);
        }

        // PUT: api/boards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putboard(int id, board board)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != board.boardID)
            {
                return BadRequest();
            }

            db.Entry(board).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!boardExists(id))
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

        // POST: api/boards
        [ResponseType(typeof(board))]
        public IHttpActionResult Postboard(board board)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.board.Add(board);
            db.SaveChanges();

            return CreatedAtRoute("Apiv1", new { id = board.boardID }, board);
        }

        // DELETE: api/boards/5
        [ResponseType(typeof(board))]
        public IHttpActionResult Deleteboard(int id)
        {
            board board = db.board.Find(id);
            if (board == null)
            {
                return NotFound();
            }

            db.board.Remove(board);
            db.SaveChanges();

            return Ok(board);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool boardExists(int id)
        {
            return db.board.Count(e => e.boardID == id) > 0;
        }
    }
}