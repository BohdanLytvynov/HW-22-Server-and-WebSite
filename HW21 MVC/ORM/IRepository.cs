using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORM
{
    //Interface that holds methods for working with DB (CRUD)
    //Will be used to perform DI in Startup class
    public interface IRepository
    {       
        IQueryable<Notes> GetNotes();

        Notes GetNoteById(Guid id);

        void AddNote(Notes note);
        
        void RemoveNote(Guid id);

        void EditNote(Guid id, Notes newNote);               
    }
}
