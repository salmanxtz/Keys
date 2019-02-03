﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Keys.DAL;
using Keys.Models;

namespace Keys.Controllers
{
    public class ProductSoldsController : Controller
    {
        private KeysContext db = new KeysContext();

        // GET: ProductSolds
        public ActionResult Index()
        {
            var productsSolds = db.ProductsSolds.Include(p => p.Customer).Include(p => p.Product).Include(p => p.Store);
            return View(productsSolds.ToList());
        }

        // GET: ProductSolds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSold productSold = db.ProductsSolds.Find(id);
            if (productSold == null)
            {
                return HttpNotFound();
            }
            return View(productSold);
        }

        // GET: ProductSolds/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "StoreName");
            return View();
        }

        // POST: ProductSolds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductSoldId,ProductId,CustomerId,StoreId,DateSold")] ProductSold productSold)
        {
            if (ModelState.IsValid)
            {
                db.ProductsSolds.Add(productSold);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", productSold.CustomerId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", productSold.ProductId);
            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "StoreName", productSold.StoreId);
            return View(productSold);
        }

        // GET: ProductSolds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSold productSold = db.ProductsSolds.Find(id);
            if (productSold == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", productSold.CustomerId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", productSold.ProductId);
            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "StoreName", productSold.StoreId);
            return View(productSold);
        }

        // POST: ProductSolds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductSoldId,ProductId,CustomerId,StoreId,DateSold")] ProductSold productSold)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productSold).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", productSold.CustomerId);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", productSold.ProductId);
            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "StoreName", productSold.StoreId);
            return View(productSold);
        }

        // GET: ProductSolds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSold productSold = db.ProductsSolds.Find(id);
            if (productSold == null)
            {
                return HttpNotFound();
            }
            return View(productSold);
        }

        // POST: ProductSolds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductSold productSold = db.ProductsSolds.Find(id);
            db.ProductsSolds.Remove(productSold);
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
