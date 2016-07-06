using System;
using System.Threading.Tasks;

namespace Escyug.Importer.WinForms.App
{
    internal static class Invoker
    {
        public static void Invoke(Action action)
        {
            if (action != null)
            {
                action.Invoke();
            }
        }

        public static async Task InvokeAsync(Func<Task> func)
        {
            if (func != null)
            {
                await func.Invoke();
            }
        }
    }
}
