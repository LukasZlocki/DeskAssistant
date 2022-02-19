using DeskAssistant.Models.MenuWindow;
using DeskAssistant.Models.StickyNote;
using DeskAssistant.Windows.NoteWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeskAssistant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // this form position parameters
        WindowPosition thisWindowPosition = new WindowPosition();

        // Windows objects list
        List <Note> noteWindowList = new List<Note>();


        public MainWindow()
        {
            InitializeComponent();
        }



        private void btnAddNote_Click(object sender, RoutedEventArgs e)
        {
            int _id = RenderId();

            Note note = new Note();
            note.noteCard.Id = _id; // set new id for note window and card
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

            thisWindowPosition.fpSetYPos(this.Left);
            thisWindowPosition.fpSetYPos(this.Top);
        }



        // Rendering Id number
        private int RenderId()
        {
            Random random = new Random();
            int _id = random.Next(0, 10000);
            return _id;
        }


    }
}
