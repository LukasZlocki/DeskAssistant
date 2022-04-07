using DeskAssistant.Models.MenuWindow;

namespace Services.DeskAssistant.Services.MainWindowService
{
    internal interface IMainWindowService
    {
        // READ
        public WindowPosition GetMainWindowPosition();

        // UPDATE
        public void UpdateMainWindowPosition(WindowPosition possition);
    }
}
