using SmartDoor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartDoorManagmentSystem.MVC.Controllers
{
    public class DoorController : Controller
    {
        // GET: Door
        public ActionResult Index()
        {
            var model = new DoorItemList[0];
            return View(model);
        }
        // Add method here 
        //Get
        public ActionResult Create()
        {
            return View();
        }
    }
}