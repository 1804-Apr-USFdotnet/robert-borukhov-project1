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
    public class RestaurantController : Controller
    {
        private List<Restaurant> restaurants;
        private RestaurantProperties rp;
        private Logger log;

        public RestaurantController()
        {
            MethodCalls.SetLibRest();
            restaurants = MethodCalls.rest;
            log = LogManager.GetCurrentClassLogger();
        }
        // GET: ~/Restaurant/Index
        [Route("Restaurant/Index")]
        public ActionResult Index()
        {
            List<Restaurant> topThree = MethodCalls.TopThree();
            ViewBag.topThree = topThree;    
            return View();
        }

        // GET: Restaurant ==> Display Restaurants
        // ~/Resturant/DisplayRestaurants
        
        [HttpGet]
        [Route("Restaurant/All")]
        public ActionResult All()
        {
            restaurants = Sort.AlphabeticalSort(restaurants);
            ViewBag.restaurants = restaurants;
            if (TempData["nameAscendingList"] != null)
                ViewBag.restaurants = TempData["nameAscendingList"];
            if (TempData["nameDescList"] != null)
                ViewBag.restaurants = TempData["nameDescList"];
            if (TempData["stringSizeList"] != null)
                ViewBag.restaurants = TempData["stringSizeList"];
            if (TempData["avgRatingList"] != null)
                ViewBag.restaurants = TempData["avgRatingList"];
            return View();
        }

        [HttpGet]
        [Route("Restaurant/AscSort")]
        public ActionResult AlphabeticalSort()
        {
            List<Restaurant> displaySorted = Sort.AlphabeticalSort(restaurants);
            TempData["nameAscendingList"] = displaySorted;
            return RedirectToAction("All");
        }
        [HttpGet]
        [Route("Restaurant/DescSort")]
        public ActionResult AlphRevSort()
        {
            List<Restaurant> displaySorted = Sort.AlphabeticalReverseSort(restaurants);
            TempData["nameDescList"] = displaySorted;
            return RedirectToAction("All");
        }
        [HttpGet]
        [Route("Restaurant/StringSize")]
        public ActionResult StringSize()
        {
            List<Restaurant> displaySorted = Sort.StringSizeSort(restaurants);
            TempData["stringSizeList"] = displaySorted;
            return RedirectToAction("All");
        }
        [HttpGet]
        [Route("Restaurant/AvgRating")]
        public ActionResult AvgRatingSort()
        {
            List<Restaurant> displaySorted = Sort.AvgRatingSort(restaurants);
            TempData["avgRatingList"] = displaySorted;
            return RedirectToAction("All");
        }
        
        // GET: Restaurant/Details/5
        public ActionResult Details(int id)
        {
            RestaurantProperties rp = new RestaurantProperties(id);
            return View(rp);
        }

        // GET: Restaurant/Create
        [HttpGet]
        [Route("Restaurant/New")]
        public ActionResult New()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        public ActionResult Create(RestaurantReviews.Library.Restaurant rest)
        {
            try
            {
                // TODO: Add insert logic here
                RestaurantReviews.Library.MethodCalls.AddRestaurantToDb(rest);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/Edit/5
        /*public ActionResult Edit(int id)
        {

            return View();
        }*/

        public ActionResult Edit(Restaurant rest)
        {
            MethodCalls.UpdateRest(rest);
            return RedirectToAction("Index");
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/Delete/5
        public ActionResult Delete(int id)
        {
            MethodCalls.DeleteRest(id);
             return RedirectToAction("Index");
        }

        public ActionResult DeleteMessage(int id)
        {
            Restaurant rest = MethodCalls.GetRestById(id);
            ViewBag.restaurant = rest;
            return PartialView("_DeleteMessage");
        }
        // POST: Restaurant/Delete/5
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
