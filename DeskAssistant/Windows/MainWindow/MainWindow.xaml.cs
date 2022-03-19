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
        // Service
        private readonly LocalFilesEngine positionService = new LocalFilesEngine();

        // this form position parameters
        WindowPosition thisWindowPosition = new WindowPosition();

        // Windows objects list
        List <Note> noteWindowList = new List<Note>();


        public MainWindow()
        {
            InitializeComponent();

            // positioning of this window
            thisWindowPosition = positionService.ReadMainWindowPosition();
            SetThisWindowPosition(thisWindowPosition);

            // initializing
            NoteWindowsInitializer();
        }


        private void btnAddNote_Click(object sender, RoutedEventArgs e)
        {
            int _id = RenderId();

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



        // Moving This form by mouse    
        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();

            thisWindowPosition.Xpos = this.Left;
            thisWindowPosition.Ypos = this.Top;

            // update this window possition in database
            // ToDo: code update this wind pos in database
            positionService.UpdateMainWindowPosition(thisWindowPosition);
        }


        // Rendering Id number
        private int RenderId()
        {
            // ToDo : check id nb to avoid duplication of ids 
            Random random = new Random();
            int _id = random.Next(0, 10000);
            return _id;
        }


        #region Initializing of windows
        public void NoteWindowsInitializer()
        {
            NoteService _nService = new NoteService();
            List<NoteCard> _noteList = new List<NoteCard>();

            // load all notes
            _noteList = _nService.GetAllNotes();

            foreach(var note in _noteList)
            {
                Note _noteWindow = new Note(note);
                _noteWindow.Show();
            }
            
        }

        #endregion


        private void SetThisWindowPosition(WindowPosition _position)
        {
            this.Left = _position.Xpos;
            this.Top = _position.Ypos;
        }



    }
}
