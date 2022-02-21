using DeskAssistant.Models.StickyNote;

namespace DeskAssistant.Services.Note_Service
{
    public interface INoteService
    {
        // CREATE / UPDATE
        public void UpdateNote(NoteCard note);
        
        // READ
        public IEnumerable<NoteCard> GetAllNotes();

        // DELETE
        public void DeleteNote(NoteCard note);

    }
}
