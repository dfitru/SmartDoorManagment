using Microsoft.AspNet.Identity;
using SmartDoor.Models;
using SmartDoor.Models.Building;
using SmartDoor.Services;
using SmartDoorManagmentSystem.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartDoorManagmentSystem.MVC.Controllers
{
    public class BuildingController : Controller

    {
        private BuildingService _buildingService = new BuildingService();
        //private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Building
        public ActionResult Index()
        {
            var model = _buildingService.GetBuilding();
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
        public ActionResult Create(BuildingCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            //var service = CreateBuildingService();
            if (_buildingService.CreateBuilding(model))
            {
                TempData["SaveResult"] = "The Building was created.";
                return RedirectToAction("Index");

            }
            ModelState.AddModelError("", "could not be created.");
            return View(model);
        }
        //Get Details
        public ActionResult Details(int id)
        {
            //var svc = CreateBuildingService();
            var model = _buildingService.GetBuildingById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            //var service = CreateBuildingService();
            var detail = _buildingService.GetBuildingById(id);
            var model =
                new BuildingEdit
                {
                    BuildingName=detail.BuildingName

                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BuildingEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.BuildingId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

           // var service = CreateBuildingService();

            if (_buildingService.UpdateBuilding(model))
            {
                TempData["SaveResult"] = " Updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", " could not be updated.");
            return View(model);
        }
        //private BuildingService CreateBuildingService()
        //{
        //    var userId = Guid.Parse(User.Identity.GetUserId());
        //    var service = new BuildingService(userId);
        //    return service;
        //}
    }
}