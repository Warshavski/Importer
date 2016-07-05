namespace Escyug.Importer.Data.Metadata
{
    public sealed class Column
    {
        public string Name { get; private set; }

        // ?? object ??
        public string Type { get; private set; }
        
        public int Length { get; private set; }

        public Column(string columnName, string columnType, int columnLength) 
        {
            Name = columnName;
            Type = columnType;
            Length = columnLength;
        }
    }
}
