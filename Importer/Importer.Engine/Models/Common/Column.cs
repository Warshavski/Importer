
namespace Importer.Engine.Models
{
    /* TODO : 
     *   1. - done - Add constructor that initialize all properties by variables 
     *   2. - done - Rework empty column propery (return Column instance);
     */

    /// <summary>
    /// class that offers information about collumn in table 
    /// </summary>
    public class Column
    {
        private const string EMPTY_DATA = "empty data";

        // Empty column value
        private static readonly Column _emptyColumn = new Column("<empty>", 0);
        public static Column EmptyColumn
        {
            get
            {
                return _emptyColumn;
            }
        }

        #region Properties

        // index of each column in collection
        private int _index = -1;
        public int Index
        {
            get { return _index; }
        }

        // name of each column in collection
        private string _columnName = string.Empty;
        public string Name
        {
            get { return _columnName; }
        }

        // type of each column in collection
        private string _dataType = string.Empty;
        public string DataType
        {
            get { return _dataType; }
        }

        // length of each column in collection
        private int _length = -1;
        public int Length
        {
            get { return _length; }
        }

        // shows if column is selected (for import)
        private bool _isSelected = false;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { _isSelected = value; }
        }

        #endregion

        #region Constructors

        // default constructor (for testing)
        internal Column()
        {
            _index = -1;
            _columnName = EMPTY_DATA;
            _dataType = EMPTY_DATA;
            _length = 0;
            _isSelected = true;
        }

        // main constructor     
        internal Column(string columnName, int index)
        {
            _index = index;
            _columnName = columnName;
            _dataType = EMPTY_DATA;
            _length = 0;
            _isSelected = true;
        }

        // release constructor
        internal Column(string columnName, int index, string dataType, int length)
        {
            _columnName = columnName;
            _index = index;
            _dataType = dataType;
            _length = length;
            IsSelected = true;
        }

        #endregion
    }
}
