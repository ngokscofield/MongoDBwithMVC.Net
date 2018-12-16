using MongoDB.Bson;
using MongoDB.Driver;
using MVCwithMongodbCRUD.App_Start;
using MVCwithMongodbCRUD.Models;
using MongoDB.Driver.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.Mvc;

namespace MVCwithMongodbCRUD.Controllers
{
    public class ProductController : Controller
    {
		private MongoDBContext dbcontext;
		private IMongoCollection<Product> productCollection;

		public ProductController()
		{
			dbcontext = new MongoDBContext();
			productCollection = dbcontext.database.GetCollection<Product>("product");
		}

		// GET: Product
		public ActionResult Index()
        {
			List<Product> products = productCollection.AsQueryable<Product>().ToList();
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(string id)
        {
			var productId = new ObjectId(id);
			var product = productCollection.AsQueryable<Product>().SingleOrDefault(x => x.Id == productId);
            return View(product);
        }

        // GET: Product/Create		
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
				// TODO: Add insert logic here
				productCollection.InsertOne(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(string id)
        {
			var productId = new ObjectId(id);
			var product = productCollection.AsQueryable<Product>().SingleOrDefault(x => x.Id == productId);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Product product)
        {
            try
            {
				var filter = Builders<Product>.Filter.Eq("_id", ObjectId.Parse(id));
				var update = Builders<Product>.Update
					.Set("ProductName", product.ProductName)
					.Set("ProductDescription", product.Description)
					.Set("Quantity", product.Quantity);
				var result = productCollection.UpdateOne(filter, update);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(string id)
        {
			var productId = new ObjectId(id);
			var product = productCollection.AsQueryable<Product>().SingleOrDefault(x=>x.Id == productId);
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
				// TODO: Add delete logic here
				productCollection.DeleteOne(Builders<Product>.Filter.Eq("_id", ObjectId.Parse(id)));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
