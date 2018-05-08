using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantReviews.Library;
using RestaurantReviews.Web.Views.Models;
using NLog;

namespace RestaurantReviews.Web.Controllers
{
    public class ReviewController : Controller
    {
        public Logger log;
        private List<Reviews> reviews;

        public ReviewController()
        {

            log = LogManager.GetCurrentClassLogger();
        }
        // GET: Review/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: Review
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        [Route("Review/New")]
        public ActionResult New()
        {
            return View();
        }


        // GET: Review/Create
        [HttpPost]
        public ActionResult Create(RestaurantReviews.Library.Reviews rev)
        {
            MethodCalls.AddReviewToDb(rev);
            return RedirectToAction("All");
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Review/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Review/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            // TODO: Add update logic here

            return RedirectToAction("Index");

        }

        // GET: Review/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            MethodCalls.DeleteRev(id);
            return View();
        }

        // POST: Review/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
