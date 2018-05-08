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
        [Route("Review/New/{id}")]
        public ActionResult New(int id)
        {
            ViewData["restId"] = id;
            return View();
        }


        // GET: Review/Create
        [HttpPost]
        public ActionResult Create(RestaurantReviews.Library.Reviews rev)
        {
            int restId = Int32.Parse(Request.Form["restId"]);
            rev.RestaurantId = restId;
            MethodCalls.AddReviewToDb(rev);
            return View("Restaurant/Details");
        }

        // POST: Review/Create

        // GET: Review/Edit/5
        [HttpGet]
        [Route("Review/Update/{id}")]
        public ActionResult Edit(Reviews rev)
        {
            MethodCalls.UpdateRev(rev);
            return View();
        }

        // POST: Review/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            // TODO: Add update logic here

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            MethodCalls.DeleteRev(id);
            return RedirectToAction("All");
        }
        // GET: Review/Delete/5

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
