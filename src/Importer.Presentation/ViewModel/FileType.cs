using Escyug.Importer.Common;

namespace Escyug.Importer.Presentations.ViewModel
{
    public class FileType
    {   
        private Constants.DataInstanceTypes? _dataInstanceType;
        public Constants.DataInstanceTypes? DataInstanceType
        {
            get { return _dataInstanceType; }
        }

        private string _displayName;
        public string Name
        {
            get { return _displayName; }
        }

        internal FileType(Constants.DataInstanceTypes? dataInstanceType, string displayName)
        {
            _dataInstanceType = dataInstanceType;
            _displayName = displayName;
        }
    }
}
