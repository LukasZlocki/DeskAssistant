using DeskAssistant.Models.StickyNote;

namespace DeskAssistant.Services.Note_Service
{
    public interface INoteService
    {
        // CREATE 
        public void CreateNote(NoteCard note);
        
        // READ
        public IEnumerable<NoteCard> GetAllNotes();


        // UPDATE
        public void UpdateNote(NoteCard note);

        // DELETE
        public void DeleteNote(NoteCard note);

    }
}
