using DeskAssistant.Models.MenuWindow;
using Services.DeskAssistant.DataBaseEngine;
using Services.DeskAssistant.Services.MainWindowService;

namespace Services.DeskAssistant.Services.MainWindow_Service
{
    public class MainWindowService : IMainWindowService
    {
        private readonly LocalFilesEngine _fileEngine = new LocalFilesEngine();

        // READ
        public WindowPosition GetMainWindowPosition()
        {
            var service = _fileEngine.ReadMainWindowPosition();
            return service;
        }

        // UPDATE
        public void UpdateMainWindowPosition(WindowPosition position)
        {
            _fileEngine.UpdateMainWindowPosition(position);
        }
    }
}
