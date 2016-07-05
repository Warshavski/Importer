
namespace Escyug.Importer.Presentations.BETA.ViewModels
{
    public class FileType
    {
        public string Name { get; private set; }
        public object Type { get; private set; }

        internal FileType(string name, object type)
        {
            Name = name;
            Type = type;
        }
    }
}
