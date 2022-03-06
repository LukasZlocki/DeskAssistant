using DeskAssistant.Models.StickyNote;
using DeskAssistant.Services.DataBaseEngine;

namespace DeskAssistant.Services.Note_Service
{

    public class NoteService : INoteService
    {
        private readonly DbEngine _dbEngine = new DbEngine();

        // CREATE
        public void CreateNote(NoteCard note)
        {
            _dbEngine.CreateNoteInDatabase(note);
        }

        // READ
        public List<NoteCard> GetAllNotes()
        {
            var service = _dbEngine.ReadNotesListFromFile();
            return service;
        }

        // UPDATE
        public void UpdateNote(NoteCard note)
        {
            _dbEngine.UpdateNoteInDatabase(note);
        }

        // DELETE
        public void DeleteNote(NoteCard note)
        {
            throw new NotImplementedException();
        }

  
    }
}
