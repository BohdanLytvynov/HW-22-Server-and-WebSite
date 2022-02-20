using System;
using System.Linq;

namespace ORM
{
    public class EFRepository : IRepository
    {
        //Data base context
        private DataContext m_context;

        public EFRepository(DataContext context)
        {
            m_context = context;
        }
       
        //Add Note to Data Base
        public void AddNote(Notes note)
        {
            m_context.Add(note);
            m_context.SaveChanges();
        }

        //Edit Note in Data Base
        //Also controlls the State of an editable note, in case if context will be used 
        //in different parts of the project
        public void EditNote(Guid id, Notes newNote)
        {
            Notes res = m_context.Notes.FirstOrDefault(n => n.Id == id);

            res.SetNewValues(newNote);

            m_context.Entry(res).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            m_context.SaveChanges();
        }
        //Gets Note from Db according to Id
        public Notes GetNoteById(Guid id) =>
            m_context.Notes.FirstOrDefault(n=>n.Id.Equals(id));
        
        //Gets Notes from DB
        public IQueryable<Notes> GetNotes()=>
            m_context.Notes;
               
        //Removes Note from DB
        public void RemoveNote(Guid id)
        {            
            m_context.Notes.Remove(new Notes() { Id = id });
            m_context.SaveChanges();
        }

        
    }
}
