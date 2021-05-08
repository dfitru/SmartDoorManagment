using Microsoft.AspNet.Identity;
using SmartDoor.Data;
using SmartDoor.Models;
using SmartDoor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartDoorManagmentSystem.MVC.Controllers
{
    public class PersonController : Controller
    {
        

        private PersonService _personService = new PersonService();
        // GET: Person
        public ActionResult Index()
        {
            
            var model = _personService.GetPerson();
            return View(model);
        }
        // Add method here 
        //Get
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonCreate model)
        {
            if (!ModelState.IsValid) return View(model);
           // var service = CreatePersonService();
            if (_personService.CreatePerson(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");

            }
            ModelState.AddModelError("", "could not be created.");
            return View(model);
        }
        //Get Details
        public ActionResult Details(int id)
        {
            //var svc = CreatePersonService();
            var model = _personService.GetPersonById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
           // var service = CreatePersonService();
            var detail = _personService.GetPersonById(id);
            var model =
                new PersonEdit
                {
                    PersonId = detail.PersonId,
                    FirstName = detail.FirstName,
                    Company = detail.Company
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PersonEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PersonId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            //var service = CreatePersonService();

            if (_personService.UpdatePersone(model))
            {
                TempData["SaveResult"] = " Updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", " could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            //var svc = CreatePersonService();
            var model = _personService.GetPersonById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
           // var service = CreatePersonService();

            _personService.DeletePerson(id);

            TempData["SaveResult"] = " Deleted";

            return RedirectToAction("Index");
        }
        //private PersonService CreatePersonService()
        //{
        //    var userId = Guid.Parse(User.Identity.GetUserId());
        //    var service = new PersonService(userId);
        //    return service;
        //}
    }
}