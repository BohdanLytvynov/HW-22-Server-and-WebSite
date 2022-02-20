using HW21_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW21_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using HW21_MVC.Functions;

namespace HW21_MVC.Areas.User
{
    [Area("User")]
    public class UserController : Controller
    {
        string title = "Note viewer";//title of web page

        string action = String.Empty; //name of function

        private IRepository m_rep; //repository will be used after DI

        List<string> m_errors;//Erros List


        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="rep"></param>
        public UserController(IRepository rep)
        {
            m_rep = rep;

            m_errors = new List<string>();
        }

        /// <summary>
        /// Will send html representation of init page,
        /// in case if user has User role
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            title = "Note viewer";

            action = "Notes Viewer(User Version)";

            ViewData.Add("NotesCol", m_rep.GetNotes());

            ViewData.Add("ActionType", action);

            ViewData.Add("Model", title);

            ViewData.Add("User", TransferData.Username);

            return View();
        }

        /// <summary>
        /// Will send add page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddUserForm()///User
        {
            title = "Add Note";

            action = "Add Note Function";

            ViewData["ActionType"] = action;

            return View("Add", title);
        }

        /// <summary>
        /// Will add note to db and send result page
        /// </summary>
        /// <param name="noteVm"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddNote(NoteVM noteVm)//user
        {
            title = "Add Result";

            action = "Add Result Info";

            ViewData["ActionType"] = action;

            ViewData.Add("operType", 1);

            ViewData.Add("OperRes", null);

            if (ModelState.IsValid)
            {
                m_rep.AddNote(
                new Notes(Guid.NewGuid(), noteVm.Surename,
                noteVm.Name,
                noteVm.Lastname,
                noteVm.Phone,
                noteVm.Adress,
                noteVm.Description)
                );

                ViewData["OperRes"] = true;
            }
            else
            {
                ViewData["OperRes"] = false;

                CommonFunctions.ParseErrors(ModelState.Values.ToList(), m_errors);

                ViewData.Add("Errors", m_errors);

                
            }

            return View("AddNoteResult", title);

        }

        
    }


}
