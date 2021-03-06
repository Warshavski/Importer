﻿using System;

namespace Escyug.Importer.Presentations.BETA.ViewModels
{
    /// <summary>
    /// class for extended properties
    /// </summary>
    [Serializable]
    public class PropertyInfo
    {
        // display name of each extended property;
        private string _displayName = string.Empty;
        public string DisplayName { get { return _displayName; } }

        // value of each extended property
        private object _value = null;
        public object Value { get { return _value; } }

        // default constructor
        internal PropertyInfo(string displayName, object value)
        {
            _displayName = displayName;
            _value = value;
        }
    }
}
