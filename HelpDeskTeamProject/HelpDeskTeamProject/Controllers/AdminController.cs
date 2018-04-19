using HelpDeskTeamProject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDeskTeamProject.Controllers
{
    public class AdminController : Controller
    {
        AppContext dbContext = new AppContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        //View list of all registered users
        public ActionResult ListOfUsers()
        {
            return View(dbContext.Users.ToList());
        }
    }
}