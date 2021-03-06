﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo1.Models;

namespace Demo1.Controllers
{
    public class UsersController : Controller
    {
        private StudyEntities3 db = new StudyEntities3();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.User.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,username,password,type,email,phone,imagePath,school,registime")] User user)
        {
            if (ModelState.IsValid)
            {
                if(user.username == null)
                {
                    TempData["changeMessage"] = "新建用户失败";
                    TempData["jump"] = "/Users/Create";
                    return RedirectToAction("Index", "Admin");
                }
                var res = db.User.ToList();
                var result = db.User.Where(o => o.username == user.username).FirstOrDefault();
                if (result != null) 
                {
                    TempData["changeMessage"] = "用户已存在";
                    TempData["jump"] = "/Users/Create";
                    return RedirectToAction("Index", "Admin");
                }
                user.registime = DateTime.Now;
                db.User.Add(user);
                db.SaveChanges();
                TempData["changeMessage"] = "新建用户成功";
                TempData["jump"] = "/Users/Index";
                return RedirectToAction("Index", "Admin");
            }

            TempData["changeMessage"] = "新建用户失败";
            TempData["jump"] = "/Users/Create";
            return RedirectToAction("Index", "Admin");
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,username,password,type,email,phone,imagePath,school,registime")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                TempData["changeMessage"] = "修改用户信息成功";
                TempData["jump"] = "/Users/Index";
                return RedirectToAction("Index","Admin");
            }
            TempData["changeMessage"] = "修改用户信息失败";
            return View("Index", "Admin");
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
