using DeskAssistant.Models.MenuWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Services.DeskAssistant.DataBaseEngine
{
    public class LocalFilesEngine
    {
        private static string MAIN_WINDOW_POSITION_FILE = "MeWePos.xml";

        // READ Main Window position to file
        public WindowPosition ReadMainWindowPosition()
        {
            WindowPosition _position = new WindowPosition();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(WindowPosition));
            try
            {
                TextReader tr = new StreamReader(MAIN_WINDOW_POSITION_FILE);
                _position = (WindowPosition)xmlSerializer.Deserialize(tr);
                tr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("No data base found. Creating new data base.");
            }
            if (_position is null)
            {
                _position = new WindowPosition();

            }
            return _position;
        }

        // UPDATE Main Window position to file
        public void UpdateMainWindowPosition(WindowPosition position)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(WindowPosition));
            TextWriter tw = new StreamWriter(MAIN_WINDOW_POSITION_FILE);
            xmlSerializer.Serialize(tw, position);
            tw.Close();
        }


    }
}
