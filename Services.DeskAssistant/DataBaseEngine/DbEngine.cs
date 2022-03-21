using DeskAssistant.Models.StickyNote;
using System.Xml.Serialization;

namespace DeskAssistant.Services.DataBaseEngine
{
    public class DbEngine
    {
        private static string NOTE_CARD_DB_FILE = "dbNoteCrd.xml";


        public void UpdateNoteInDatabase(NoteCard  _note)
        {
            bool _noteUpdated = false;
            List<NoteCard> _notesList = new List<NoteCard>();
            _notesList = ReadNotesListFromFile();
            foreach (var note in _notesList)
            {
                if (note.Id == _note.Id)
                {
                    note.NoteText = _note.NoteText;
                    note.notePossition = _note.notePossition;
                    note.noteProperty = _note.noteProperty;
                    _noteUpdated = true;
                }
            }

            // if no note with id then add note to lis
            if (_noteUpdated == false)
            {
                _notesList.Add(_note);
            }

            SaveAllNotesToDatabase(_notesList);
        }


        public void CreateNoteInDatabase(NoteCard _note)
        {
            // read all data from db
            List<NoteCard> _notesList = new List<NoteCard>();
            _notesList = ReadNotesListFromFile();

            if (_notesList.Count == 0) // list is empty
            {
                _notesList.Add(_note);
            }
            else // no _noteList exist creating new one and adding _note
            {
                if (_notesList.Find(i => i.Id == _note.Id) is null) // No note with id detected in list
                {
                    _notesList.Add(_note);
                }
                else
                {
                    foreach(var note in _notesList)
                    {
                        if(note.Id == _note.Id)
                        {
                            note.NoteText = _note.NoteText;
                        }
                    }
                }
            }
            SaveAllNotesToDatabase(_notesList);
        }


        public List<NoteCard> ReadNotesListFromFile()
        {
            List<NoteCard> _notelist = new List<NoteCard>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<NoteCard>));
            try
            {
                TextReader tr = new StreamReader(NOTE_CARD_DB_FILE);
                _notelist = (List<NoteCard>)xmlSerializer.Deserialize(tr);
                tr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No data base found. Creating new data base.");
            }
            if (_notelist is null)
            {
                _notelist = new List<NoteCard>();
            }

            return _notelist;
        }


        public List<int> ReadAllNoteIds()
        {
            List<int> _idList = new List<int>();
            List<NoteCard> _noteCardsList = new List<NoteCard>();

            


            return _idList;
        }

        private void SaveAllNotesToDatabase(List<NoteCard> notesList)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<NoteCard>));
            TextWriter tw = new StreamWriter(NOTE_CARD_DB_FILE);
            xmlSerializer.Serialize(tw, notesList);
            tw.Close();
        }



    }
}
