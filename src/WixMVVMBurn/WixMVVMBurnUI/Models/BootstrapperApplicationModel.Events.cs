namespace WixMVVMBurnUI.Models
{
    using System;
    using Wix = Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

    public partial class BootstrapperApplicationModel
    {
        /// <summary>
        /// Called when the engine has begun installing the bundle.
        /// </summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnApplyBegin(WPFBootstrapperEventArgs<Wix.ApplyBeginEventArgs> args)
        {
            ApplyBegin?.Invoke(this, args);
        }

        /// <summary>
        /// Called when the engine has begun installing the bundle.
        /// </summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.ApplyBeginEventArgs>> ApplyBegin;

        /// <summary>Called when the engine has completed installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnApplyComplete(WPFBootstrapperEventArgs<Wix.ApplyCompleteEventArgs> args)
        {
            ApplyComplete?.Invoke(this, args);
        }

        /// <summary>Called when the engine has completed installing the bundle.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.ApplyCompleteEventArgs>> ApplyComplete;

        /// <summary>Called right after OnApplyBegin.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        public virtual void OnApplyPhaseCount(WPFBootstrapperEventArgs<Wix.ApplyPhaseCountArgs> args) { }

        /// <summary>Called when the engine begins to cache the container or payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnCacheAcquireBegin(WPFBootstrapperEventArgs<Wix.CacheAcquireBeginEventArgs> args) { }

        /// <summary>Called when the engine completes caching of the container or payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnCacheAcquireComplete(WPFBootstrapperEventArgs<Wix.CacheAcquireCompleteEventArgs> args) { }

        /// <summary>Called when the engine has progressed on caching the container or payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnCacheAcquireProgress(WPFBootstrapperEventArgs<Wix.CacheAcquireProgressEventArgs> args) { }

        /// <summary>Called when the engine begins to cache the installation sources.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnCacheBegin(WPFBootstrapperEventArgs<Wix.CacheBeginEventArgs> args) { }

        /// <summary>Called after the engine has cached the installation sources.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnCacheComplete(WPFBootstrapperEventArgs<Wix.CacheCompleteEventArgs> args) { }

        /// <summary>Called by the engine when it begins to cache a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnCachePackageBegin(WPFBootstrapperEventArgs<Wix.CachePackageBeginEventArgs> args) { }

        /// <summary>Called when the engine completes caching a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnCachePackageComplete(WPFBootstrapperEventArgs<Wix.CachePackageCompleteEventArgs> args) { }

        /// <summary>Called when the engine has started verify the payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnCacheVerifyBegin(WPFBootstrapperEventArgs<Wix.CacheVerifyBeginEventArgs> args) { }

        /// <summary>Called when the engine completes verification of the payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnCacheVerifyComplete(WPFBootstrapperEventArgs<Wix.CacheVerifyCompleteEventArgs> args) { }

        /// <summary>Called when the overall detection phase has begun.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnDetectBegin(WPFBootstrapperEventArgs<Wix.DetectBeginEventArgs> args) { }

        /// <summary>Called when a package was not detected but a package using the same provider key was.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        public virtual void OnDetectCompatiblePackage(WPFBootstrapperEventArgs<Wix.DetectCompatiblePackageEventArgs> args) { }

        /// <summary>Called when the detection phase has completed.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnDetectComplete(WPFBootstrapperEventArgs<Wix.DetectCompleteEventArgs> args) { }

        /// <summary>Called when the engine has begun installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnDetectForwardCompatibleBundle(WPFBootstrapperEventArgs<Wix.DetectForwardCompatibleBundleEventArgs> args) { }

        /// <summary>Called when an MSI feature has been detected for a package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnDetectMsiFeature(WPFBootstrapperEventArgs<Wix.DetectMsiFeatureEventArgs> args) { }

        /// <summary>Called when the detection for a specific package has begun.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnDetectPackageBegin(WPFBootstrapperEventArgs<Wix.DetectPackageBeginEventArgs> args) { }

        /// <summary>Called when the detection for a specific package has completed.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnDetectPackageComplete(WPFBootstrapperEventArgs<Wix.DetectPackageCompleteEventArgs> args) { }

        /// <summary>Called when the detection for a prior bundle has begun.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnDetectPriorBundle(WPFBootstrapperEventArgs<Wix.DetectPriorBundleEventArgs> args) { }

        /// <summary>Called when a related bundle has been detected for a bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnDetectRelatedBundle(WPFBootstrapperEventArgs<Wix.DetectRelatedBundleEventArgs> args) { }

        /// <summary>Called when a related MSI package has been detected for a package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnDetectRelatedMsiPackage(WPFBootstrapperEventArgs<Wix.DetectRelatedMsiPackageEventArgs> args) { }

        /// <summary>Called when an MSP package detects a target MSI has been detected.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnDetectTargetMsiPackage(WPFBootstrapperEventArgs<Wix.DetectTargetMsiPackageEventArgs> args) { }

        /// <summary>Fired when the update detection has found a potential update candidate.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        public virtual void OnDetectUpdate(WPFBootstrapperEventArgs<Wix.DetectUpdateEventArgs> args) { }

        /// <summary>Called when the engine has begun installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnDetectUpdateBegin(WPFBootstrapperEventArgs<Wix.DetectUpdateBeginEventArgs> args) { }

        /// <summary>Called when the engine has begun installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnDetectUpdateComplete(WPFBootstrapperEventArgs<Wix.DetectUpdateCompleteEventArgs> args) { }

        /// <summary>Called when the engine is about to start the elevated process.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnElevate(WPFBootstrapperEventArgs<Wix.ElevateEventArgs> args) { }

        /// <summary>Called when the engine has encountered an error.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnError(WPFBootstrapperEventArgs<Wix.ErrorEventArgs> args) { }

        /// <summary>Called when the engine has begun installing packages.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnExecuteBegin(WPFBootstrapperEventArgs<Wix.ExecuteBeginEventArgs> args) { }

        /// <summary>Called when the engine has completed installing packages.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnExecuteComplete(WPFBootstrapperEventArgs<Wix.ExecuteCompleteEventArgs> args) { }

        /// <summary>Called when Windows Installer sends a file in use installation message.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnExecuteFilesInUse(WPFBootstrapperEventArgs<Wix.ExecuteFilesInUseEventArgs> args) { }

        /// <summary>Called when Windows Installer sends an installation message.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnExecuteMsiMessage(WPFBootstrapperEventArgs<Wix.ExecuteMsiMessageEventArgs> args) { }

        /// <summary>Called when the engine has begun installing a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnExecutePackageBegin(WPFBootstrapperEventArgs<Wix.ExecutePackageBeginEventArgs> args) { }

        /// <summary>Called when the engine has completed installing a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnExecutePackageComplete(WPFBootstrapperEventArgs<Wix.ExecutePackageCompleteEventArgs> args) { }

        /// <summary>Called when the engine executes one or more patches targeting a product.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnExecutePatchTarget(WPFBootstrapperEventArgs<Wix.ExecutePatchTargetEventArgs> args) { }

        /// <summary>Called by the engine while executing on payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnExecuteProgress(WPFBootstrapperEventArgs<Wix.ExecuteProgressEventArgs> args) { }

        /// <summary>Called by the engine before trying to launch the preapproved executable.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        public virtual void OnLaunchApprovedExeBegin(WPFBootstrapperEventArgs<Wix.LaunchApprovedExeBeginArgs> args) { }

        /// <summary>Called by the engine after trying to launch the preapproved executable.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        public virtual void OnLaunchApprovedExeComplete(WPFBootstrapperEventArgs<Wix.LaunchApprovedExeCompleteArgs> args) { }

        /// <summary>Called when the engine has begun planning the installation.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnPlanBegin(WPFBootstrapperEventArgs<Wix.PlanBeginEventArgs> args) { }

        /// <summary>Called when the engine plans a new, compatible package using the same provider key.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        public virtual void OnPlanCompatiblePackage(WPFBootstrapperEventArgs<Wix.PlanCompatiblePackageEventArgs> args) { }

        /// <summary>Called when the engine has completed planning the installation.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnPlanComplete(WPFBootstrapperEventArgs<Wix.PlanCompleteEventArgs> args) { }

        /// <summary>Called when the engine is about to plan an MSI feature of a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnPlanMsiFeature(WPFBootstrapperEventArgs<Wix.PlanMsiFeatureEventArgs> args) { }

        /// <summary>Called when the engine has begun planning the installation of a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnPlanPackageBegin(WPFBootstrapperEventArgs<Wix.PlanPackageBeginEventArgs> args) { }

        /// <summary>Called when then engine has completed planning the installation of a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnPlanPackageComplete(WPFBootstrapperEventArgs<Wix.PlanPackageCompleteEventArgs> args) { }

        /// <summary>Called when the engine has begun planning for a prior bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnPlanRelatedBundle(WPFBootstrapperEventArgs<Wix.PlanRelatedBundleEventArgs> args) { }

        /// <summary>Called when the engine is about to plan the target MSI of a MSP package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnPlanTargetMsiPackage(WPFBootstrapperEventArgs<Wix.PlanTargetMsiPackageEventArgs> args) { }

        /// <summary>Called when the engine has changed progress for the bundle installation.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnProgress(WPFBootstrapperEventArgs<Wix.ProgressEventArgs> args) { }

        /// <summary>Called when the engine has begun registering the location and visibility of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnRegisterBegin(WPFBootstrapperEventArgs<Wix.RegisterBeginEventArgs> args) { }

        /// <summary>Called when the engine has completed registering the location and visilibity of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnRegisterComplete(WPFBootstrapperEventArgs<Wix.RegisterCompleteEventArgs> args) { }

        /// <summary>Called by the engine to allow the user experience to change the source using <see cref="M:Engine.SetLocalSource"/> or <see cref="M:Engine.SetDownloadSource"/>.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnResolveSource(WPFBootstrapperEventArgs<Wix.ResolveSourceEventArgs> args) { }

        /// <summary>Called by the engine to request a restart now or inform the user a manual restart is required later.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnRestartRequired(WPFBootstrapperEventArgs<Wix.RestartRequiredEventArgs> args) { }

        /// <summary>Called by the engine to uninitialize the user experience.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnShutdown(WPFBootstrapperEventArgs<Wix.ShutdownEventArgs> args) { }

        /// <summary>Called by the engine on startup of the bootstrapper application.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnStartup(WPFBootstrapperEventArgs<Wix.StartupEventArgs> args) { }

        /// <summary>Called when the system is shutting down or the user is logging off.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnSystemShutdown(WPFBootstrapperEventArgs<Wix.SystemShutdownEventArgs> args) { }

        /// <summary>Called when the engine has begun removing the registration for the location and visibility of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnUnregisterBegin(WPFBootstrapperEventArgs<Wix.UnregisterBeginEventArgs> args) { }

        /// <summary>Called when the engine has completed removing the registration for the location and visibility of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public virtual void OnUnregisterComplete(WPFBootstrapperEventArgs<Wix.UnregisterCompleteEventArgs> args) { }

        /// <summary>
        /// Called when the a message should be logged.
        /// </summary>
        /// <param name="level">The log level.</param>
        /// <param name="message">The message.</param>
        public virtual void OnLogMessage(Wix.LogLevel level, string message) { }

        /// <summary>Determines if the specified <paramref name="arguments"/> is valid.</summary>
        /// <typeparam name="T">The type of arguments.</typeparam>
        /// <param name="arguments">The arguments.</param>
        /// <returns>True if the arguments are valid, otherwise false.</returns>
        protected bool IsValid<T>(WPFBootstrapperEventArgs<T> arguments) where T : EventArgs
        {
            return (arguments != null && arguments.Arguments != null);
        }
    }
}