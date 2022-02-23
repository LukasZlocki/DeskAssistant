namespace DeskAssistant.Models.StickyNote
{
    public class NoteCard
    {
        public int Id { get; set; }
        public string NoteText { get; set; }
        public NotePosition notePossition { get; set; }
        // NoteProperty noteProperty { get; set; }
    }
}
