using SmartDoor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartDoorManagmentSystem.MVC.Controllers
{
    public class SmartKeyController : Controller
    {
        // GET: SmartKey
        public ActionResult Index()
        {
            var model =new  SmartKeyListItem[0];
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