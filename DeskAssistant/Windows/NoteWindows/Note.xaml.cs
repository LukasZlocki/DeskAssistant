using DeskAssistant.Models.StickyNote;
using DeskAssistant.Services.Note_Service;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
            noteCardNullCheck(ref _noteCard);

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
            // set fontSize
            txtNote.FontSize = _note.noteProperty.FontSize;

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

        #region Saving Note Card instantly
        private void InstantSaveText(object sender, KeyEventArgs e)
        {
            NotePosition np = new NotePosition();
            _noteCard.notePossition = np; // add possition of note card
            
            _noteCard.NoteText = txtNote.Text;
            
            SaveNoteCardToDatabase(_noteCard);
        }

        private void SaveNoteCardToDatabase(NoteCard noteCard)
        {
            _noteService.UpdateNote(noteCard);
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

            SaveNoteCardToDatabase(_noteCard);
        }

        #endregion



        #region Buttons - change font size
        private void btnLetterDown_Click(object sender, RoutedEventArgs e)
        {
            SetFontSizeOfNote("DOWN");
            RefreshScreen(_noteCard);
            SaveNoteCardToDatabase(_noteCard);

        }

        private void btnLetterUp_Click(object sender, RoutedEventArgs e)
        {
            SetFontSizeOfNote("UP");
            RefreshScreen(_noteCard);
            SaveNoteCardToDatabase(_noteCard);
        }
        #endregion


        #region Buttons - change note colour
        // ToDo: Code buttons to change note color

        private void btnColorGreen_Click(object sender, RoutedEventArgs e)
        {
            SetColorForNote("DARK");
        }

        private void btnColorYellow_Click(object sender, RoutedEventArgs e)
        {
            SetColorForNote("YELLOW");
        }

        private void btnColorBlue_Click(object sender, RoutedEventArgs e)
        {
            SetColorForNote("BLUE");
        }

        private void btnColorOrange_Click(object sender, RoutedEventArgs e)
        {
            SetColorForNote("ORANGE");
        }

        #endregion



        #region

        private void SetColorForNote(string color)
        {
            byte _r = 00;
            byte _g = 00;
            byte _b = 00;

            byte _r1 = 64;
            byte _g1 = 64;
            byte _b1 = 64;

            switch (color)
            {
                case "DARK":
                    _r = 64;
                    _g = 64;
                    _b = 64;
                    break;

                case "YELLOW":
                    _r = 195;
                    _g = 234;
                    _b = 19;
                    break;

                case "BLUE":
                    _r = 17;
                    _g = 123;
                    _b = 224;
                    break;

                case "ORANGE":
                    _r = 228;
                    _g = 184;
                    _b = 24;
                    break;
            }

            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush();
            myLinearGradientBrush.StartPoint = new Point(0.5, 0);
            myLinearGradientBrush.EndPoint = new Point(0.5, 1);

            myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(_r1, _g1, _b1), 1));
            myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(_r, _g, _b), 0));

            Point startPoint = new Point(0.5, 0);
            Point endPoint = new Point(0.5, 1);

            RectangleMain.Fill = myLinearGradientBrush;

            // ToDo : code saving color settings to database  
            //SaveNoteCardToDatabase(NoteCard noteCard);
        }

        #endregion


        #region Set Font Size
        private void SetFontSizeOfNote(string command)
        {
            double _changedFontSize = 0.0;
            double _presentFontSize = _noteCard.noteProperty.FontSize;
            double _fontIncrement = _noteCard.noteProperty.GetFontIncrement();

            if (command == "UP")
            {
                _changedFontSize = _presentFontSize + _fontIncrement;
            }
            if (command == "DOWN")
            {
                _changedFontSize = _presentFontSize - _fontIncrement;
            }
            _noteCard.noteProperty.FontSize = _changedFontSize;
        }

        #endregion

        private void RefreshScreen(NoteCard note)
        {
            txtNote.Text = note.NoteText;
            txtNote.FontSize = note.noteProperty.FontSize;

        }

        // null handling
        private void noteCardNullCheck(ref NoteCard note)
        {
            if (note.notePossition == null)
            {
                note.notePossition = new NotePosition();
                note.notePossition.Xpos = 0.0;
                note.notePossition.Ypos = 0.0;
            }

            if (note.noteProperty == null)
            {
                note.noteProperty = new NoteProperty();
                note.noteProperty.FontSize = 12.0;
            }

        }


    }
}
