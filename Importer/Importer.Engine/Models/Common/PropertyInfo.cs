using System;
namespace Importer.Engine.Models
{
    /// <summary>
    /// class for extended properties
    /// </summary>
    [Serializable]
    public sealed class PropertyInfo
    {
        // display name of each extended property;
        private string _displayName = string.Empty;
        public string DisplayName { get { return _displayName; } }

        // value of each extended property
        private string _value = string.Empty;
        public string Value { get { return _value; } }

        // default constructor
        internal PropertyInfo(string displayName, string value)
        {
            _displayName = displayName;
            _value = value;
        }
    }
}
