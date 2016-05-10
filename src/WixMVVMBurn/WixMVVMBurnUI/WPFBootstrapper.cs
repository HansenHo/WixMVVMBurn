using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Security;
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

        private IMainWindowViewModel viewModel;

        [ImportMany(typeof(IBootstrapperMainWindow))]
        private IBootstrapperMainWindow[] mainViews;

        private IBootstrapperMainWindow mainView;

        #region GetApplicationMainViewModel

        private void InitializeApplicationMainViewModel()
        {
            try
            {
                DirectoryCatalog catalog = new DirectoryCatalog(".");
                CompositionContainer container = new CompositionContainer(catalog);
                container.ComposeParts(this);

                this.mainView = mainViews.FirstOrDefault();
                if (this.mainView != null)
                {
                    this.viewModel = this.mainView.ViewModel;
                }
                else
                {
                    this.viewModel = new SilentViewModel();
                }

                this.viewModel.Initialize(this.model);
            }
            catch (System.Exception ex)
            {
                this.LogError(ex);
                this.LogError("Failed to get an UI implementation.");
                this.Engine.Quit(404);
            }
        }

        #endregion GetApplicationMainViewModel

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
            this.InitializeApplicationMainViewModel();

            //
            // Call Engine.Detect, asking the engine to figure out what's on the machine.
            // The engine will run async and use callbacks for reporting results.
            //

            if (mainView != null && (this.model.Command.Display == Wix.Display.Passive || this.model.Command.Display == Wix.Display.Full))
            {
                if (Dispatcher.CurrentDispatcher != null)
                {
                    try
                    {
                        Dispatcher = this.mainView.Window.Dispatcher;
                        this.mainView.Window.Closed += OnWindowClosed;
                        this.mainView.Window.Show();

                        this.ParseCommandLine();

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
                //Slient Mode
                try
                {
                    this.ParseCommandLine();

                    this.Engine.Detect();
                    this.Engine.CloseSplashScreen();
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

        /// <summary>
        /// Logs the bootstrapper event.
        /// </summary>
        /// <param name="eventArgs">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <param name="text">The text.</param>
        public void LogBootstrapperLeaveEvent(EventArgs eventArgs, string text)
        {
            text = "Leave Method: Bootstrapper." + text;
            if (eventArgs != null)
            {
                text += " [";

                var properties = eventArgs.GetType().GetProperties();
                if (properties.Length == 0)
                {
                    text += "<no properties>";
                }

                for (int i = 0; i < properties.Length; i++)
                {
                    var propValue = GetPropertyValue(properties[i], eventArgs);
                    text += properties[i].Name + "=" + propValue + " | ";
                }

                text = text.Trim().TrimEnd('|').Trim();
                text += "]";
            }
            this.WriteToLog(Wix.LogLevel.Verbose, text);
        }

        /// <summary>
        /// Logs the bootstrapper event.
        /// </summary>
        /// <param name="eventArgs">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <param name="text">The text.</param>
        public void LogBootstrapperEnterEvent(EventArgs eventArgs, string text)
        {
            text = "Enter Method: Bootstrapper." + text;
            if (eventArgs != null)
            {
                text += " [";

                var properties = eventArgs.GetType().GetProperties();
                if (properties.Length == 0)
                {
                    text += "<no properties>";
                }

                for (int i = 0; i < properties.Length; i++)
                {
                    var propValue = GetPropertyValue(properties[i], eventArgs);
                    text += properties[i].Name + "=" + propValue + " | ";
                }

                text = text.Trim().TrimEnd('|').Trim();
                text += "]";
            }
            this.WriteToLog(Wix.LogLevel.Verbose, text);
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

        private static string GetPropertyValue(PropertyInfo propertyInfo, object obj)
        {
            var propertyValue = propertyInfo.GetValue(obj, null);
            if (propertyValue == null)
            {
                return string.Empty;
            }

            var propertyValueList = propertyValue as IEnumerable;
            if (propertyValueList == null || propertyValue is string)
            {
                return propertyValue.ToString();
            }

            var propertyValues = new List<string>();
            foreach (var propertyValueListItem in propertyValueList)
            {
                propertyValues.Add(propertyValueListItem.ToString());
            }

            return string.Join("#", propertyValues);
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
                this.OnLogMessage(level, message);
            }
        }

        #endregion Logging

        #region Initialize

        private void ParseCommandLine()
        {
            // Get array of arguments based on the system parsing algorithm.
            string[] args = this.Command.GetCommandLineArgs();
            if (args != null)
            {
                for (int i = 0; i < args.Length; ++i)
                {
                    //parseCommand
                    if (args[i].StartsWith("-", StringComparison.InvariantCultureIgnoreCase) || args[i].StartsWith("/", StringComparison.InvariantCultureIgnoreCase))
                    {
                        string[] param = args[i].Split(new char[] { '=' }, 2);
                        string commandName = param[0].Remove(0, 1);
                        string value = param.Length > 1 ? param[1].Trim() : string.Empty;

                        this.OnCommandLineParsing(commandName, value, CommandLineArgumentType.Command);
                    }
                    else
                    {
                        string[] param = args[i].Split(new char[] { '=' }, 2);
                        string parameter = param[0];
                        string value = param.Length > 1 ? param[1].Trim() : string.Empty;

                        bool handled = false;
                        bool secured = parameter.StartsWith("~", StringComparison.InvariantCultureIgnoreCase);
                        CommandLineArgumentType type = CommandLineArgumentType.Parameter;
                        if (secured)
                        {
                            type = CommandLineArgumentType.SecuredParameter;
                            parameter = parameter.Remove(0, 1);
                        }

                        handled = this.OnCommandLineParsing(parameter, value, type);

                        if (!handled)
                        {
                            if (secured)
                            {
                                if (this.Engine.SecureStringVariables.Contains(parameter))
                                {
                                    SecureString secString = new SecureString();
                                    foreach (char c in value)
                                    {
                                        secString.AppendChar(c);
                                    }
                                    secString.MakeReadOnly();
                                    this.Engine.SecureStringVariables[parameter] = secString;
                                }
                            }
                            else
                            {
                                if (this.Engine.StringVariables.Contains(parameter))
                                {
                                    this.Engine.StringVariables[parameter] = value;
                                }
                            }
                        }
                    }
                }
            }
        }

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

            this.model.PlannedAction = this.Command.Action;
        }

        #endregion Initialize
    }
}