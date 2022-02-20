using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ORM;
using HW21_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using HW21_MVC.Services;

namespace HW21_MVC.Controllers
{
    public class HomeController : Controller
    {        
        string title = "Home";//title of web page

        string action = String.Empty; //name of function

        private IRepository m_rep; //repository will be used after DI
        
        List<string> errors;//Erroe List
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="rep"></param>
        public HomeController(IRepository rep) 
        {
            m_rep = rep;

            errors = new List<string>();
        }
        /// <summary>
        /// Will send html representation of init page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()//Noname
        {            
            title = "Home";

            action = "Notes Viewer";
            
            ViewData.Add("NotesCol", m_rep.GetNotes());

            ViewData.Add("ActionType", action);

            ViewData.Add("Model", title);
           
            return View();
        }                                                       
    }
}
