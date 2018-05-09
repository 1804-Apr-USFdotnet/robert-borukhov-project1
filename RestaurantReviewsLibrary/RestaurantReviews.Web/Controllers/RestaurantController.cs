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
            if (TempData["search"] != null)
            {
                ViewBag.restaurants = TempData["search"];
            }

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
        [HttpPost]
        [Route("Restaurant/Search")]
        public ActionResult SearchBox(FormCollection form)
        {
            List<Restaurant> searchList = MethodCalls.SearchRestName(Request.Form["Search_Info"]);
            TempData["search"] = searchList;
            return RedirectToAction("All");
        }
        [Required]
        [HttpGet]
        [Route("Restaurant/Details/{id}")]
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
            //try
            {
                // TODO: Add insert logic here
                RestaurantReviews.Library.MethodCalls.AddRestaurantToDb(rest);
                return RedirectToAction("All");
            }
            /*catch
            {
                return View();
            }*/
        }
        [HttpGet]
        [Route("Restaurant/Update/{id}")]
        public ActionResult Edit(int id)
        {
            Restaurant rest = MethodCalls.GetRestById(id);
            ViewBag.rest = rest;
            return View("Update");
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        [Route("Restaurant/Update/{id}")]
        public ActionResult Edit(Restaurant rest)
        {
                // TODO: Add update logic here
                MethodCalls.UpdateRest(rest);
                return RedirectToAction("All");

        }

        // GET: Restaurant/Delete/5
        [HttpPost]
        [Route("Restaurant/Delete")]
        public ActionResult Delete(int id)
        {
            MethodCalls.DeleteRest(id);
            return RedirectToAction("All");
        }
        [HttpGet]
        [Route("Restaurant/Confirmation/{id}")]
        public ActionResult DeleteMessage(int id)
        {
            Restaurant rest = MethodCalls.GetRestById(id);
            ViewBag.restaurant = rest;
            return PartialView("_DeleteMessage",rest);
        }
        [HttpGet]
        [Route("Restaurant/Search/{sub}")]
        public ActionResult SearchString(string sub)
        {
            List<Restaurant> newList = MethodCalls.SearchRestName(sub);
            ViewBag.restList = newList;
            return RedirectToAction("All");
        }

    }
}
