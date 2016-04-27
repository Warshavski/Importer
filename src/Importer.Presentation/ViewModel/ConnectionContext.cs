
namespace Escyug.Importer.Presentations.ViewModel
{
    public class ConnectionContext
    {
        public string ConnectionString { get; set; }
        public bool IsDestination { get; private set; }

        public ConnectionContext() 
        {
            IsDestination = false;
            ConnectionString = string.Empty;
        }

        public ConnectionContext(bool inDestination)
        {
            IsDestination = inDestination;
            ConnectionString = string.Empty;
        }

        public ConnectionContext(string conectionString)
        {
            IsDestination = true;
            ConnectionString = conectionString;
        }
    }
}
