using DeskAssistant.Models.StickyNote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DeskAssistant.Services.DataBaseEngine
{
    public class DbEngine
    {
        public void WriteNoteToFile(NoteCard _note)
        {
            // ToDo: Step 1: Code object note writing to file 
            // ToDo: Step 2: Object note write to file by id
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(NoteCard));
            TextWriter tw = new StreamWriter(@"c:\test.xml");
            xmlSerializer.Serialize(tw, _note);
            tw.Close();
        }

    }
}
