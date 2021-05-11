using Microsoft.AspNet.Identity;
using SmartDoor.Models;
using SmartDoor.Models.SmartKey;
using SmartDoor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartDoorManagmentSystem.MVC.Controllers
{
    [Authorize]
    public class SmartKeyController : Controller
    {

        // GET: SmartKey
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SmartKeyService(userId);
            var model = service.GetSmartKeys();
            //var model = new SmartKeyListItem[0];

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
        public ActionResult Create(SmartKeyCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateKeyService();
            if (service.CreateSmartKey(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Note could not be created.");
            return View(model);
        }
        //Get Details
        public ActionResult Details(int id)
        {
            var svc = CreateKeyService();
            var model = svc.GetKeyById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateKeyService();
            var detail = service.GetKeyById(id);
            var model =
                new SmartKeyEdit
                {
                    KeyId=detail.KeyId,
                    Name=detail.Name,
                    KeyRecived=detail.KeyRecived,
                    DoorId=detail.Doors.DoorId,
                    PersonId = detail.Persons.PersonId
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SmartKeyEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.KeyId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateKeyService();

            if (service.UpdateKey(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateKeyService();
            var model = svc.GetKeyById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateKeyService();

            service.DeleteNote(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

        private SmartKeyService CreateKeyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SmartKeyService(userId);
            return service;
        }
    }
}