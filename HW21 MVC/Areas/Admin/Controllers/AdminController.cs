using HW21_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW21_MVC.ViewModel;
using HW21_MVC.Functions;

namespace HW21_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        string title = "Note viewer_Admin";//title of web page

        string action = String.Empty; //name of function

        private IRepository m_rep; //repository will be used after DI

        List<string> m_errors;//Erros List

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="rep"></param>
        public AdminController(IRepository rep)
        {
            m_rep = rep;

            m_errors = new List<string>();
        }

        /// <summary>
        /// Will send index page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            title = "Note viewer";

            action = "Notes Viewer (Admin Version)";

            ViewData.Add("NotesCol", m_rep.GetNotes());

            ViewData.Add("ActionType", action);

            ViewData.Add("Model", title);

            ViewData.Add("User", TransferData.Username);

            return View();            
        }

        /// <summary>
        /// Will send info page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Info()//user
        {
            Guid id = GetIdFromRequest();

            Notes note = m_rep.GetNoteById(id);

            ViewData.Add("sNote", note);

            title = "Aditional Info";

            ViewData["ActionType"] = title;

            return View("Info", title);
        }
        /// <summary>
        /// Removes Note
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RemoveNote()//admin
        {
            title = "Operation result";

            action = "Operation {Remove Note} Result:";
            ViewData.Add("ActionType", action);
            Guid Id = GetIdFromRequest();

            ViewData.Add("OperRes", null);
            try
            {
                m_rep.RemoveNote(Id);
                ViewData["OperRes"] = true;
            }
            catch (Exception)
            {
                ViewData["OperRes"] = false;
            }

            ViewData.Add("operType", 3);

            return View("AddNoteResult", title);
        }

        /// <summary>
        /// Edit Note 
        /// </summary>
        /// <param name="newNote"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditNote(NoteVM newNote)//admin
        {
            title = "Operation Result";

            action = "Operation Edit Note Result:";
            ViewData.Add("ActionType", action);

            ViewData.Add("operType", 2);

            ViewData.Add("OperRes", null);

            Guid id = GetIdFromRequest();

            try
            {
                m_rep.EditNote(id, new Notes(
                    id, newNote.Surename, newNote.Name,
                    newNote.Lastname, newNote.Phone, newNote.Adress,
                    newNote.Description
                    ));

                ViewData["OperRes"] = true;
            }
            catch (Exception)
            {
                ViewData["OperRes"] = false;
            }

            return View("AddNoteResult", title);
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

        /// <summary>
        /// Gets Id from request
        /// </summary>
        /// <returns></returns>
        private Guid GetIdFromRequest() =>
            Guid.Parse(HttpContext.Request.Path.Value.Split('=')[1]);
    }
}
