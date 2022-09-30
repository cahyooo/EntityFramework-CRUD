using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIBKMNET_WebApplication.Context;
using SIBKMNET_WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;

namespace SIBKMNET_WebApplication.Controllers
{
    public class ProvinceController : Controller
    {
        MyContext myContext;

        public ProvinceController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public IActionResult Index()
        {
            var data = myContext.Provinces.Include(x => x.Region).ToList();

            return View(data);
        }


        //getid / detail
        public IActionResult Details(int id)
        {
            var data = myContext.Provinces.Include(x => x.Region).FirstOrDefault(x => x.Id.Equals(id));

            return View(data);
        }

        //create
        //[HttpGet]
        public IActionResult Create()
        {
            //var data = myContext.Provinces.Include(x => x.Region).FirstOrDefault(x => x.Id.Equals(id));
            //var data = myContext.Provinces.Find(id);
            return View();
        }


        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Province province)
        {
            if (ModelState.IsValid)
            {

                myContext.Provinces.Add(province);
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
            //var data = myContext.Provinces.Include(x => x.Region).FirstOrDefault(x => x.Id.Equals(id));
            var data = myContext.Provinces.Find(id);
            return View(data);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Province country)
        {
            
            if (ModelState.IsValid)
            {
                
                myContext.Provinces.Update(country);
                var result = myContext.SaveChanges();
                
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }

            }

            return View();
        }

        //delete
        public IActionResult Delete(Province country)
        {

            
                if (ModelState.IsValid)
                {
                    myContext.Provinces.Remove(country);
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
