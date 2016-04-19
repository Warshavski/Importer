
namespace Escyug.Importer.Presentations.Common
{
    public class ViewContainer<TArg, TContainer>
        where TContainer : IView
    {
        public TArg Argument { get; private set; }
        public TContainer Container { get; private set; }

        public ViewContainer(TArg argument, TContainer container)
        {
            Argument = argument;
            Container = container;
        }
    }
}
