
namespace Importer.Engine.Models
{
    // How file shall be open
    public enum FileBrowse { None, File, Folder };

    public interface ICreator
    {
        /// <summary>
        /// Display name property
        /// </summary>
        string DisplayName { get; }
        /// <summary>
        /// File browser type property (open file, folder or nothing)
        /// </summary>
        FileBrowse FileBrowse { get; }

        /// <summary>
        /// Get property for each file type
        /// </summary>
        /// <returns>PropertyInfo arrray</returns>
        PropertyInfo[] GetProperties();

        /// <summary>
        /// Initialize instace of file
        /// </summary>
        /// <param name="filePath">path to file</param>
        /// <param name="property">extended property for each file type</param>
        /// <returns>IFile instance</returns>
        IFile CreateInstance(string filePath, PropertyInfo property);
    }
}
