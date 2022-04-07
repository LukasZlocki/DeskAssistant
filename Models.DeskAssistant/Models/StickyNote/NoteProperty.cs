namespace DeskAssistant.Models.StickyNote
{
    public class NoteProperty
    {
        private double _FONT_INCREMENT = 1;

        public int Id { get; set; }
        public double FontSize { get; set; }

        // note card colors
        public byte Color_r { get; set; }
        public byte Color_g { get; set; }
        public byte Color_b { get; set; }


        // GETERs
        public double GetFontIncrement()
        {
            return _FONT_INCREMENT;
        }

        public void SetNoteCardColors(byte r, byte g, byte b)
        {
            this.Color_r = r;
            this.Color_g = g;
            this.Color_b = b;
        }

    }
}
