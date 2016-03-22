using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Windows.Threading;
using WixMVVMBurnUI.Core;
using WixMVVMBurnUI.Models;
using WixMVVMBurnUI.ViewModels;
using WixMVVMBurnUI.Views;
using Wix = Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

namespace WixMVVMBurnUI
{
    public partial class WPFBootstrapper : Wix.BootstrapperApplication
    {
        public static Dispatcher Dispatcher { get; set; }

        /// <summary>The main user interface for the bootstrap application.</summary>
        private BootstrapperApplicationModel model;

        private BootstrapperApplicationViewModelBase viewModel;
        private BootstrapperApplicationWindow mainView;

        #region GetApplicationUI

        /// <summary>Gets the <see cref="BaseBAWindow" /> derivation from the configured UI implementation assembly.</summary>
        /// <returns>A BaseBAWindow instance or null.</returns>
        private BootstrapperApplicationWindow GetApplicationUI()
        {
            BootstrapperApplicationWindow retVal = null;
            string implType = GetAppSetting("BootstrapperUI");
            Type type = null;

            if (!string.IsNullOrEmpty(implType))
            {
                LogVerbose("configured implementation = " + implType);
                try
                {
                    type = GetUITypeFromAssembly(implType);
                }
                catch (Exception e) { LogError(e); }
            }

            if (type != null)
            {
                LogVerbose("full type name = " + type.AssemblyQualifiedName);
                try
                {
                    retVal = Activator.CreateInstance(type) as BootstrapperApplicationWindow;
                }
                catch (Exception e) { LogError(e); }
            }

            if (retVal != null)
            {
                retVal.View = this;
            }

            return retVal;
        }

        #endregion GetApplicationUI

        #region GetApplicationUIType

        /// <summary>Gets the application user interface implementation type.</summary>
        /// <param name="assemblyName">The name of the assembly that should defines the <see cref="StartupWindowAttribute"/>.</param>
        /// <returns>The type specified by the first assembly that has the <see cref="StartupWindowAttribute"/>.</returns>
        private Type GetUITypeFromAssembly(string assemblyName)
        {
            Type baType = null;
            Assembly asm = null;
            StartupWindowAttribute[] attrs = null;

            if (!string.IsNullOrEmpty(assemblyName))
            {
                try
                {
                    asm = AppDomain.CurrentDomain.Load(assemblyName);
                }
                catch (Exception ex)
                {
                    LogError("An error occurred loading assembly {0}. Details: {1}", assemblyName, ex);
                }
            }

            if (asm != null)
            {
                attrs = (StartupWindowAttribute[])asm.GetCustomAttributes(typeof(StartupWindowAttribute), false);
                if (attrs != null && attrs.Length > 0 && attrs[0] != null)
                {
                    baType = attrs[0].StartupWindowType;
                }
            }

            return baType;
        }

        #endregion GetApplicationUIType

        #region GetAppSetting

        /// <summary>Attempts to get the value of the application settings with the specified <paramref name="key" />.</summary>
        /// <param name="key">The key of the setting.</param>
        /// <returns>The value of the settings or null.</returns>
        private string GetAppSetting(string key)
        {
            string value = null;

            if (ConfigurationManager.AppSettings != null && !string.IsNullOrEmpty(key))
            {
                try
                { value = ConfigurationManager.AppSettings[key]; }
                catch { value = null; }
            }

            return value;
        }

        #endregion GetAppSetting

        #region SetMainWindow

        /// <summary>Sets the main window to the specified <paramref name="window"/>.</summary>
        /// <param name="window">The new main window.</param>
        public void SetMainWindow(BootstrapperApplicationWindow window)
        {
            if (window == null)
            {
                Exception error = new ArgumentNullException("window");
                LogError(error);
                throw error;
            }
            mainView.Closed -= OnWindowClosed;
            mainView = window;
            mainView.Closed += OnWindowClosed;
            UIDispatcher = mainView.Dispatcher;
        }

        #endregion SetMainWindow

        #region Run

        /// <summary>Called when the bootstrap application is run.</summary>
        protected override void Run()
        {
            this.model = new BootstrapperApplicationModel(this);
            this.viewModel = new BootstrapperApplicationViewModelBase(this.model);

            this.mainView = GetApplicationUI();

            if (mainView != null)
            {
                if (Dispatcher.CurrentDispatcher != null)
                {
                    try
                    {
                        if (this.model.Command.Display == Wix.Display.Passive || this.model.Command.Display == Wix.Display.Full)
                        {
                            this.model.SetBurnVariable
                            UIDispatcher = mainView.Dispatcher;
                            mainView.Closed += OnWindowClosed;
                            mainView.Show();
                        }

                        this.Engine.Detect();

                        Dispatcher.Run();
                        this.Engine.Quit(this.model.FinalResult);
                    }
                    catch (Exception ex)
                    {
                        this.LogError(ex);
                        this.Engine.Quit(400);
                    }
                }
                else
                {
                    this.LogError("No current dispatcher.");
                    this.Engine.Quit(400);
                }
            }
            else
            {
                this.LogError("Failed to get an UI implementation.");
                this.Engine.Quit(404);
            }
        }

        #endregion Run

        #region Logging

        /// <summary>Writes the specified <paramref name="message"/> to the log file.</summary>
        /// <param name="message">The message to write.</param>
        public void LogVerbose(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                WriteToLog(Wix.LogLevel.Verbose, message);
            }
        }

        /// <summary>Writes a log entry for the specified <paramref name="error"/>.</summary>
        /// <param name="error">The error.</param>
        public void LogError(Exception error)
        {
            if (error != null)
            {
                LogError(string.Format("An error occurred. Detail: {0}", error));
            }
        }

        /// <summary>Writes a log entry for the specified <paramref name="args"/> using the specified <paramref name="format"/>.</summary>
        /// <param name="format">The string format.</param>
        /// <param name="args">The arguments.</param>
        public void LogError(string format, params object[] args)
        {
            if (!string.IsNullOrEmpty(format) && args != null)
            {
                try
                { LogError(string.Format(format, args)); }
                catch (Exception e)
                {
                    LogError(string.Format("An error occurred formatting the original message. Detail: {0}\r\nOriginal Error: {1}",
                      e, string.Join(";", (from a in args select a.ToString()).ToArray())));
                }
            }
        }

        /// <summary>Writes the specified <paramref name="message"/> to the log file.</summary>
        /// <param name="message">The message to write.</param>
        public void LogError(string message)
        {
            WriteToLog(Wix.LogLevel.Error, message ?? "An unknown error occurred in WPFBootstrapper");
        }

        /// <summary>Write the specified <paramref name="message"/> to the log using the specified log <paramref name="level"/>.</summary>
        /// <param name="level">The log level.</param>
        /// <param name="message">The message to log.</param>
        public void WriteToLog(Wix.LogLevel level, string message)
        {
            Engine.Log(level, string.Format("WixWPF: {0}", message ?? string.Empty));
        }

        #endregion Logging

        #region TryInvoke

        /// <summary>Attempts to invoke the specified <paramref name="action" /> on the main window dispatcher.</summary>
        /// <param name="action">The action to invoke.</param>
        internal void TryInvoke(Action action)
        {
            try
            {
                if (Dispatcher != null)
                {
                    Dispatcher.Invoke(action, null);
                }
            }
            catch (Exception e) { LogError("An error occurred invoking an action. Details: {0}", e); }
        }

        #endregion TryInvoke
    }
}