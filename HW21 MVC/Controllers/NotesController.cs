using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ORM;
using Microsoft.AspNetCore.Identity;
using HW21_MVC.Models;


namespace HW21_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : Controller
    {
        IRepository m_rep; //Repository

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="rep"></param>
        public NotesController(IRepository rep,
            UserManager<IdentityUser> userManager)
        {
            m_rep = rep;
        }


        [HttpGet]
        public IEnumerable<Notes> GetNotes() =>
            m_rep.GetNotes();

        [HttpPost]
        [Route("AddNotes")]
        public async Task AddNotes([FromBody] List<Notes> notes)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < notes.Count; i++)
                {
                    m_rep.AddNote(notes[i]);
                }
            });
        }

        [HttpPost]
        [Route("Edit")]
        public async Task EditNotes([FromBody] List<Notes> notes)
        {
            await Task.Run(() =>
            {
                foreach (var item in notes)
                {
                    m_rep.EditNote(item.Id, item);
                }
            });
        }


        [HttpPost]
        [Route("RemoveNotes")]
        public async Task RemoveNotes([FromBody] List<Guid> notesId)
        {
            await Task.Run(() =>
            {
                foreach (var item in notesId)
                {
                    m_rep.RemoveNote(item);
                }
            });
        }

    }
}
