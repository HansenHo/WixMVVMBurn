using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Windows.Threading;
using System.Xml.Linq;
using WixMVVMBurnUI.Core;
using WixMVVMBurnUI.Models;
using WixMVVMBurnUI.ViewModels;
using WixMVVMBurnUI.Views;
using Wix = Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

namespace WixMVVMBurnUI
{
    public partial class WPFBootstrapper : Wix.BootstrapperApplication
    {
        public const string ManifestNamespace = "http://schemas.microsoft.com/wix/2010/BootstrapperApplicationData";

        public static Dispatcher Dispatcher { get; set; }

        ///
        /// Fetch BootstrapperApplicationData.xml and parse into XDocument.
        ///
        public XElement ApplicationData
        {
            get
            {
                var workingFolder = System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location);
                var bootstrapperDataFilePath = System.IO.Path.Combine(workingFolder, "BootstrapperApplicationData.xml");

                using (var reader = new System.IO.StreamReader(bootstrapperDataFilePath))
                {
                    var xml = reader.ReadToEnd();
                    var xDoc = XDocument.Parse(xml);
                    return xDoc.Element(XName.Get("BootstrapperApplicationData", ManifestNamespace));
                }
            }
        }

        public List<BundlePackage> BundlePackages { get; private set; }

        public string DisplayName { get; private set; }

        /// <summary>The main user interface for the bootstrap application.</summary>
        private BootstrapperApplicationModel model;

        private MainWindowViewModel viewModel;
        private BootstrapperApplicationWindow mainView;

        #region GetApplicationUI

        /// <summary>Gets the <see cref="BootstrapperApplicationWindow" /> derivation from the configured UI implementation assembly.</summary>
        /// <returns>A BaseBAWindow instance or null.</returns>
        private BootstrapperApplicationWindow GetApplicationUI()
        {
            BootstrapperApplicationWindow retVal = null;
            string implType = GetAppSetting("BootstrapperUI");
            Type type = null;

            if (!string.IsNullOrEmpty(implType))
            {
                this.LogVerbose("configured implementation = " + implType);
                try
                {
                    type = GetUITypeFromAssembly(implType);
                }
                catch (Exception e)
                {
                    this.LogError(e);
                }
            }

            if (type != null)
            {
                this.LogVerbose("full type name = " + type.AssemblyQualifiedName);
                try
                {
                    retVal = Activator.CreateInstance(type, this.viewModel) as BootstrapperApplicationWindow;
                }
                catch (Exception e)
                {
                    this.LogError(e);
                }
            }

            return retVal;
        }

        /// <summary>Gets the <see cref="BootstrapperApplicationWindow" /> derivation from the configured UI implementation assembly.</summary>
        /// <returns>A BaseBAWindow instance or null.</returns>
        private MainWindowViewModel GetApplicationMainViewModel()
        {
            MainWindowViewModel retVal = null;
            string implType = GetAppSetting("BootstrapperUI");
            Type type = null;

            if (!string.IsNullOrEmpty(implType))
            {
                this.LogVerbose("configured implementation = " + implType);
                try
                {
                    type = GetMainViewModelTypeFromAssembly(implType);
                }
                catch (Exception e)
                {
                    this.LogError(e);
                }
            }

            if (type != null)
            {
                this.LogVerbose("full type name = " + type.AssemblyQualifiedName);
                try
                {
                    retVal = Activator.CreateInstance(type) as MainWindowViewModel;
                }
                catch (Exception e)
                {
                    this.LogError(e);
                }
            }
            else
            {
                retVal = new MainWindowViewModel();
            }
            retVal.Initialize(this.model);
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
                    this.LogError("An error occurred loading assembly {0}. Details: {1}", assemblyName, ex);
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

        /// <summary>Gets the application main view model implementation type.</summary>
        /// <param name="assemblyName">The name of the assembly that should defines the <see cref="StartupWindowAttribute"/>.</param>
        /// <returns>The type specified by the first assembly that has the <see cref="StartupWindowAttribute"/>.</returns>
        private Type GetMainViewModelTypeFromAssembly(string assemblyName)
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
                    this.LogError("An error occurred loading assembly {0}. Details: {1}", assemblyName, ex);
                }
            }

            if (asm != null)
            {
                attrs = (StartupWindowAttribute[])asm.GetCustomAttributes(typeof(StartupWindowAttribute), false);
                if (attrs != null && attrs.Length > 0 && attrs[0] != null)
                {
                    baType = attrs[0].StartupMainViewModelType;
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

        #region OnWindowClosed

        /// <summary>Raised when the main window of the bootstrapper is closed.</summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void OnWindowClosed(object sender, EventArgs e)
        {
            Engine.Quit(0);
        }

        #endregion OnWindowClosed

        #region Run

        public WPFBootstrapper()
        {
            this.model = new BootstrapperApplicationModel(this);
        }

        /// <summary>Called when the bootstrap application is run.</summary>
        protected override void Run()
        {
            System.Diagnostics.Debugger.Launch();
            this.Initialize();
            this.viewModel = GetApplicationMainViewModel();

            //
            // Call Engine.Detect, asking the engine to figure out what's on the machine.
            // The engine will run async and use callbacks for reporting results.
            //

            if (this.model.Command.Display == Wix.Display.Passive || this.model.Command.Display == Wix.Display.Full)
            {
                this.mainView = this.GetApplicationUI();
                if (mainView != null)
                {
                    if (Dispatcher.CurrentDispatcher != null)
                    {
                        try
                        {
                            Dispatcher = this.mainView.Dispatcher;
                            this.mainView.Closed += OnWindowClosed;
                            this.mainView.Show();

                            this.Engine.Detect();
                            this.Engine.CloseSplashScreen();

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
            else
            {
                //Slient Mode
                try
                {
                    this.Engine.Detect();
                    this.Engine.Quit(this.model.FinalResult);
                }
                catch (Exception ex)
                {
                    this.LogError(ex);
                    this.Engine.Quit(400);
                }
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

        /// <summary>Writes the specified <paramref name="message"/> to the log file.</summary>
        /// <param name="message">The message to write.</param>
        public void LogStandard(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                WriteToLog(Wix.LogLevel.Standard, message);
            }
        }

        /// <summary>Writes the specified <paramref name="message"/> to the log file.</summary>
        /// <param name="message">The message to write.</param>
        public void LogDebug(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                WriteToLog(Wix.LogLevel.Debug, message);
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
            this.Engine.Log(level, string.Format("WixBurnUI: {0}", message ?? string.Empty));

            if (this.model != null)
            {
                this.TryInvoke(new Action(() => { this.model.OnLogMessage(level, message); }));
            }
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
                else
                {
                    action();
                }
            }
            catch (Exception e) { this.LogError("An error occurred invoking an action. Details: {0}", e); }
        }

        #endregion TryInvoke

        #region Initialize

        public void Initialize()
        {
            //
            // parse the ApplicationData to find included packages and features
            //
            var bundleManifestData = this.ApplicationData;
            this.DisplayName = bundleManifestData
                                      .Element(XName.Get("WixBundleProperties", ManifestNamespace))
                                      .Attribute("DisplayName")
                                      .Value;

            var mbaPrereqs = bundleManifestData.Descendants(XName.Get("WixMbaPrereqInformation", ManifestNamespace))
                                               .Select(x => new MBAPrereqPackage(x))
                                               .ToList();

            //
            //exclude the MBA prereq packages, such as the .Net 4 installer
            //
            var pkgs = bundleManifestData.Descendants(XName.Get("WixPackageProperties", ManifestNamespace))
                                         .Select(x => new BundlePackage(x))
                                         .Where(pkg => !mbaPrereqs.Any(preReq => preReq.PackageId == pkg.Package));

            this.BundlePackages = new List<BundlePackage>();

            //
            // Add the packages to a collection of BundlePackages
            //
            this.BundlePackages.AddRange(pkgs);

            //
            // check for features and associate them with their parent packages
            //
            var featureNodes = bundleManifestData.Descendants(XName.Get("WixPackageFeatureInfo", ManifestNamespace));
            foreach (var featureNode in featureNodes)
            {
                var feature = new PackageFeature(featureNode);
                var parentPkg = this.BundlePackages.First(pkg => pkg.Package == feature.PackageId);
                parentPkg.AllFeatures.Add(feature);
                feature.Package = parentPkg;
            }

            foreach (var bundle in this.BundlePackages)
            {
                foreach (var featureNode in bundle.AllFeatures)
                {
                    if (string.IsNullOrWhiteSpace(featureNode.ParentId))
                    {
                        bundle.RootFeature = featureNode;
                    }
                    else
                    {
                        var parent = bundle.AllFeatures.First(p => p.Feature == featureNode.ParentId);
                        parent.Features.Add(featureNode);
                        featureNode.Parent = parent;
                    }
                }
            }
        }

        #endregion Initialize
    }
}