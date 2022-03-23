using DeskAssistant.Models.MenuWindow;
using DeskAssistant.Models.StickyNote;
using DeskAssistant.Services.Note_Service;
using DeskAssistant.Windows.NoteWindows;
using Services.DeskAssistant.DataBaseEngine;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace DeskAssistant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Services
        private readonly LocalFilesEngine _positionService = new LocalFilesEngine();
        private readonly NoteService _noteService = new NoteService();

        // This form position parameters
        WindowPosition thisWindowPosition = new WindowPosition();

        // Windows objects list
        List <Note> noteWindowList = new List<Note>();


        public MainWindow()
        {
            InitializeComponent();

            // Positioning of this window
            thisWindowPosition = _positionService.ReadMainWindowPosition();
            SetThisWindowPosition(thisWindowPosition);

            // Initializing notes
            NoteWindowsInitializer();
        }


        #region Buttons
        private void btnAddNote_Click(object sender, RoutedEventArgs e)
        {
            int _id = SetIdForNewNote(_noteService);

            Note note = new Note();
            note._noteCard.Id = _id; // set new id for note window and card
            noteWindowList.Add(note);

            int index = noteWindowList.IndexOf(note);

            noteWindowList[index].Show();
        }

        private void btnCloseAndShowNotes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCloseAndShowTasks_Click(object sender, RoutedEventArgs e)
        {

        }


        // Closing this window
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion


        #region Positioning of main window

        // Moving This form by mouse    
        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();

            thisWindowPosition.Xpos = this.Left;
            thisWindowPosition.Ypos = this.Top;

            // update this window possition in database
            _positionService.UpdateMainWindowPosition(thisWindowPosition);
        }

        private void SetThisWindowPosition(WindowPosition _position)
        {
            this.Left = _position.Xpos;
            this.Top = _position.Ypos;
        }

        #endregion


        #region Initializing of windows

        public void NoteWindowsInitializer()
        {
            NoteService _nService = new NoteService();
            List<NoteCard> _noteList = new List<NoteCard>();

            // load all notes
            _noteList = _nService.GetAllNotes();

            foreach (var note in _noteList)
            {
                Note _noteWindow = new Note(note);
                _noteWindow.Show();
            }

        }

        #endregion


        #region Rendering Id for new note

        private int SetIdForNewNote(NoteService _noteService)
        {
            int _id;
            List<int> _idsList;
            bool _idDoubled = false;

            do
            {
                // generate new id
                _id = RenderId();
                // code getting all ids from database
                _idsList = _noteService.GetAllNoteIds();

                // code checking if id exists
                foreach (int id in _idsList)
                {
                    if (id == _id)
                    {
                        _idDoubled = true;
                    }
                }
              // if nok render id again if OK return new id
            } while (_idDoubled == true);
            return _id;
        }

        private int RenderId()
        {
            Random random = new Random();
            int _id = random.Next(0, 10000);
            return _id;
        }

        #endregion


    }
}
