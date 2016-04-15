using Escyug.Importer.Common;

namespace Escyug.Importer.Presentations.ViewModel
{
    public class FileTypeVM
    {
        private string _displayName;
        public string Name
        {
            get { return _displayName; }
        }

        private Constants.FilesTypes _fileTypeValue;
        public Constants.FilesTypes Value
        {
            get { return _fileTypeValue; }
        }

        internal FileTypeVM(Constants.FilesTypes fileTypeValue, string displayName)
        {
            _fileTypeValue = fileTypeValue;
            _displayName = displayName;
        }
    }
}
