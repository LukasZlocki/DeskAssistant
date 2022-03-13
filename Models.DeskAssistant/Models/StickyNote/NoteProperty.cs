namespace DeskAssistant.Models.StickyNote
{
    public class NoteProperty
    {
        private double _FONT_INCREMENT = 1;

        public int Id { get; set; }
        public double FontSize { get; set; }


        // GETERs
        public double GetFontIncrement()
        {
            return _FONT_INCREMENT;
        }

    }
}
