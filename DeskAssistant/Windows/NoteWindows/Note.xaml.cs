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

        public NoteCard _noteCard = new NoteCard();
        
        // constructor #1
        public Note(NoteCard note)
        {
            _noteCard = note;

            InitializeComponent();
            
            NoteWindowInit(_noteCard);
        }
        
        // constructor #2
        public Note()
        {
            InitializeComponent();
        }


        public void NoteWindowInit(NoteCard _note)
        {
            // set text
            txtNote.Text = _note.NoteText;

            // set window position
            this.Top = _note.notePossition.Ypos;
            this.Left = _note.notePossition.Xpos;
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

        #region Saving txt instantly
        private void InstantSaveText(object sender, KeyEventArgs e)
        {
            NotePosition np = new NotePosition();
            _noteCard.notePossition = np; // add possition of note card

            _noteCard.NoteText = txtNote.Text;
            
            _noteService.UpdateNote(_noteCard);
        }
        #endregion


        #region This window positioning
        //  get position of noteCard window and write it to file.
        private void Grid_MouseDow_2(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();

            _noteCard.notePossition.Xpos = this.Left;
            _noteCard.notePossition.Ypos = this.Top;

            _noteService.UpdateNote(_noteCard);
        }

        #endregion



        #region Buttons - change font size

        // ToDo: Code buttons with font size

        private void btnLetterDown_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLetterUp_Click(object sender, RoutedEventArgs e)
        {
            
        }


        #region Buttons - change note colour
        // ToDo: Code buttons to change note color

        private void btnColorGreen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnColorYellow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnColorBlue_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnColorOrange_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion


    }
}
