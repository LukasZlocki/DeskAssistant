using DeskAssistant.Models.StickyNote;
using DeskAssistant.Services.DataBaseEngine;

namespace DeskAssistant.Services.Note_Service
{

    public class NoteService : INoteService
    {
        private readonly DbEngine _dbEngine = new DbEngine();


        public IEnumerable<NoteCard> GetAllNotes()
        {
            throw new NotImplementedException();
        }

        public void UpdateNote(NoteCard note)
        {
            _dbEngine.WriteNoteToFile(note);
        }

        public void DeleteNote(NoteCard note)
        {
            throw new NotImplementedException();
        }


    }
}
