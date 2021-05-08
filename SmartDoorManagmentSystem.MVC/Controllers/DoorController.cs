using SmartDoor.Models;
using SmartDoor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartDoorManagmentSystem.MVC.Controllers
{
    public class DoorController : Controller
    {
        private DoorService _door = new DoorService();
        // GET: Door
        public ActionResult Index()
        {
            var model = _door.GetDoors();
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
        public ActionResult Create(DoorCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            // var service = CreatePersonService();
            if (_door.CreateDoor(model))
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
            var model = _door.GetDoorById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            // var service = CreatePersonService();
            var detail = _door.GetDoorById(id);
            var model =
                new DoorEdit
                {
                    DoorId = detail.DoorId,
                    DoorName = detail.DoorName,
                    FloorNumber=detail.FloorNumber,
                    IsRoomInRoom =detail.IsRoomInRoom
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DoorEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.DoorId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            //var service = CreatePersonService();

            if (_door.UpdateDoor(model))
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
            var model = _door.GetDoorById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            // var service = CreatePersonService();

            _door.DeleteDoor(id);

            TempData["SaveResult"] = " Deleted";

            return RedirectToAction("Index");
        }
    }
}