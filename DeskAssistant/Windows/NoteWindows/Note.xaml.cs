using DeskAssistant.Models.StickyNote;
using DeskAssistant.Services.Note_Service;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DeskAssistant.Windows.NoteWindows
{
    /// <summary>
    /// Interaction logic for Note.xaml
    /// </summary>
    public partial class Note : Window
    {
        // Service
        private NoteService _noteService = new NoteService();

        public NoteCard noteCard = new NoteCard();
        
        public Note()
        {
            InitializeComponent();
        }

        private void RectangleTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnCloseNote_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtNote_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        #region Sving txt instantly
        private void InstantSaveText(object sender, KeyEventArgs e)
        {
            NotePosition np = new NotePosition();
            noteCard.notePossition = np; // add possition of note card

            noteCard.NoteText = txtNote.Text;
            
            _noteService.UpdateNote(noteCard);
        }
        #endregion


        #region This window positioning
        private void Grid_MouseDow_2(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();

            // TODO: code setting position in noteCard object with instant writing it to file.
            noteCard.notePossition.Xpos = this.Left;
            noteCard.notePossition.Ypos = this.Top;

            _noteService.UpdateNote(noteCard);
        }
        #endregion 


    }
}
