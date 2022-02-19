using DeskAssistant.Models.StickyNote;
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
using System.Windows.Shapes;

namespace DeskAssistant.Windows.NoteWindows
{
    /// <summary>
    /// Interaction logic for Note.xaml
    /// </summary>
    public partial class Note : Window
    {
        NotePosition thisWindowPosition = new NotePosition();

        // Object
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

        private void InstantSaveText(object sender, KeyEventArgs e)
        {

        }

        #region This window positioning
        private void Grid_MouseDow_2(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();

            thisWindowPosition.fpSetYPos(this.Left);
            thisWindowPosition.fpSetYPos(this.Top);
        }
        #endregion 
    }
}
