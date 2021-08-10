using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppGenerics.Models;
using WebAppGenerics.Models.Repository;

namespace WebAppGenerics.Controllers
{
    public class ManualController : Controller
    {
        ManualRepository repository = new ManualRepository();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {

            return View(repository.Read(id));
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Manual model)
        {
            try
            {
                repository.Create(model);
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(repository.Read(id));
        }


        [HttpPost]
        public ActionResult Edit(Manual model)
        {
            try
            {
                repository.Update(model);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {

            return View(repository.Read(id));
        }


        [HttpPost]
        public ActionResult Delete(Manual model)
        {
            try
            {
                repository.Delete(model.Id);
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult List()
        {
            return View(repository.Read());
        }
    }
}