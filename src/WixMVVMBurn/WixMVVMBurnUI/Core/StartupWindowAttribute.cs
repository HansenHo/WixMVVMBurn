using System;

namespace WixMVVMBurnUI.Core
{
    /// <summary>Used to identify the startup window class.</summary>
    [AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
    public class StartupWindowAttribute : Attribute
    {
        #region Member Variables

        /// <summary>The <see cref="Type"/> of the startup window.</summary>
        private Type _startupWindowType = null;

        /// <summary>The <see cref="Type"/> of the startup main view model.</summary>
        private Type _startupMainViewModelType = null;

        #endregion Member Variables

        #region Constructors

        /// <summary>Creates a new instance of <see cref="StartupWindowAttribute"/>></summary>
        /// <param name="startupWindowType">The <see cref="Type"/> of the startup window.</param>
        public StartupWindowAttribute(Type startupWindowType)
        {
            _startupWindowType = startupWindowType;
        }

        /// <summary>Creates a new instance of <see cref="StartupWindowAttribute"/>></summary>
        /// <param name="startupWindowType">The <see cref="Type"/> of the startup window.</param>
        /// <param name="startupMainViewModelType">The <see cref="Type"/> of the main view model.</param>
        public StartupWindowAttribute(Type startupWindowType, Type startupMainViewModelType)
        {
            _startupWindowType = startupWindowType;
            _startupMainViewModelType = startupMainViewModelType;
        }

        #endregion Constructors

        #region Properties

        /// <summary>The <see cref="Type"/> of the startup window.</summary>
        public Type StartupWindowType { get { return _startupWindowType; } }

        /// <summary>The <see cref="Type"/> of the startup window.</summary>
        public Type StartupMainViewModelType { get { return _startupMainViewModelType; } }

        #endregion Properties
    }
}