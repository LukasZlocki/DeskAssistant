using DeskAssistant.Models.StickyNote;

namespace DeskAssistant.Services.Note_Service
{
    public interface INoteService
    {
        // CREATE 
        public void CreateNote(NoteCard note);
        
        // READ
        public List<NoteCard> GetAllNotes();
        public List<int> GetAllNoteIds();

        // UPDATE
        public void UpdateNote(NoteCard note);

        // DELETE
        public void DeleteNote(int id);

    }
}
