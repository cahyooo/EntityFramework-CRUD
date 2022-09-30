using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIBKMNET_WebApplication.Context;
using SIBKMNET_WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_WebApplication.Controllers
{
    public class RegionController : Controller
    {
        MyContext myContext;

        public RegionController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public IActionResult Index()
        {
            var data = myContext.Regions.ToList();

            return View(data);
        }

        public IActionResult Details(int id)
        {
            var data = myContext.Regions.Find(id);

            return View(data);
        }

        //create
        [HttpGet]
        public IActionResult Create()
        {
            

            return View();
        }


        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Region regions)
        {
            if (ModelState.IsValid)
            {

                myContext.Regions.Add(regions);
                var result = myContext.SaveChanges();

                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        [HttpGet, ActionName("Edit")]
        public IActionResult Edit(int? id)
        {
            
            var data = myContext.Regions.Find(id);
            return View(data);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Region regions)
        {

            if (ModelState.IsValid)
            {

                myContext.Regions.Update(regions);
                var result = myContext.SaveChanges();

                if (result > 0)
                {
                    return RedirectToAction("Index");
                }

            }

            return View();
        }

        //delete
        public IActionResult Delete(Region regions)
        {


            if (ModelState.IsValid)
            {
                myContext.Regions.Remove(regions);
                var result = myContext.SaveChanges();

                if (result > 0)
                {
                    return RedirectToAction("Index");
                }


            }

            return View();
        }

    }
}
