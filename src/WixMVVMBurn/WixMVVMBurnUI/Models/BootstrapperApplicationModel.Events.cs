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
        public void OnApplyBegin(WPFBootstrapperEventArgs<Wix.ApplyBeginEventArgs> args) { ApplyBegin?.Invoke(this, args); }

        /// <summary>
        /// Called when the engine has begun installing the bundle.
        /// </summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.ApplyBeginEventArgs>> ApplyBegin;

        /// <summary>Called when the engine has completed installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnApplyComplete(WPFBootstrapperEventArgs<Wix.ApplyCompleteEventArgs> args) { ApplyComplete?.Invoke(this, args); }

        /// <summary>Called when the engine has completed installing the bundle.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.ApplyCompleteEventArgs>> ApplyComplete;

        /// <summary>Called right after OnApplyBegin.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        public void OnApplyPhaseCount(WPFBootstrapperEventArgs<Wix.ApplyPhaseCountArgs> args) { ApplyPhaseCount?.Invoke(this, args); }

        /// <summary>Called right after OnApplyBegin.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.ApplyPhaseCountArgs>> ApplyPhaseCount;

        /// <summary>Called when the engine begins to cache the container or payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnCacheAcquireBegin(WPFBootstrapperEventArgs<Wix.CacheAcquireBeginEventArgs> args) { CacheAcquireBegin?.Invoke(this, args); }

        /// <summary>Called when the engine begins to cache the container or payload.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.CacheAcquireBeginEventArgs>> CacheAcquireBegin;

        /// <summary>Called when the engine completes caching of the container or payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnCacheAcquireComplete(WPFBootstrapperEventArgs<Wix.CacheAcquireCompleteEventArgs> args) { CacheAcquireComplete?.Invoke(this, args); }

        /// <summary>Called when the engine completes caching of the container or payload.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.CacheAcquireCompleteEventArgs>> CacheAcquireComplete;

        /// <summary>Called when the engine has progressed on caching the container or payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnCacheAcquireProgress(WPFBootstrapperEventArgs<Wix.CacheAcquireProgressEventArgs> args) { CacheAcquireProgress?.Invoke(this, args); }

        /// <summary>Called when the engine has progressed on caching the container or payload.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.CacheAcquireProgressEventArgs>> CacheAcquireProgress;

        /// <summary>Called when the engine begins to cache the installation sources.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnCacheBegin(WPFBootstrapperEventArgs<Wix.CacheBeginEventArgs> args) { CacheBegin?.Invoke(this, args); }

        /// <summary>Called when the engine begins to cache the installation sources.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.CacheBeginEventArgs>> CacheBegin;

        /// <summary>Called after the engine has cached the installation sources.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnCacheComplete(WPFBootstrapperEventArgs<Wix.CacheCompleteEventArgs> args) { CacheComplete?.Invoke(this, args); }

        /// <summary>Called after the engine has cached the installation sources.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.CacheCompleteEventArgs>> CacheComplete;

        /// <summary>Called by the engine when it begins to cache a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnCachePackageBegin(WPFBootstrapperEventArgs<Wix.CachePackageBeginEventArgs> args) { CachePackageBegin?.Invoke(this, args); }

        /// <summary>Called by the engine when it begins to cache a specific package.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.CachePackageBeginEventArgs>> CachePackageBegin;

        /// <summary>Called when the engine completes caching a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnCachePackageComplete(WPFBootstrapperEventArgs<Wix.CachePackageCompleteEventArgs> args) { CachePackageComplete?.Invoke(this, args); }

        /// <summary>Called when the engine completes caching a specific package.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.CachePackageCompleteEventArgs>> CachePackageComplete;

        /// <summary>Called when the engine has started verify the payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnCacheVerifyBegin(WPFBootstrapperEventArgs<Wix.CacheVerifyBeginEventArgs> args) { CacheVerifyBegin?.Invoke(this, args); }

        /// <summary>Called when the engine has started verify the payload.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.CacheVerifyBeginEventArgs>> CacheVerifyBegin;

        /// <summary>Called when the engine completes verification of the payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnCacheVerifyComplete(WPFBootstrapperEventArgs<Wix.CacheVerifyCompleteEventArgs> args) { CacheVerifyComplete?.Invoke(this, args); }

        /// <summary>Called when the engine completes verification of the payload.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.CacheVerifyCompleteEventArgs>> CacheVerifyComplete;

        /// <summary>Called when the overall detection phase has begun.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnDetectBegin(WPFBootstrapperEventArgs<Wix.DetectBeginEventArgs> args) { DetectBegin?.Invoke(this, args); }

        /// <summary>Called when the overall detection phase has begun.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.DetectBeginEventArgs>> DetectBegin;

        /// <summary>Called when a package was not detected but a package using the same provider key was.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        public void OnDetectCompatiblePackage(WPFBootstrapperEventArgs<Wix.DetectCompatiblePackageEventArgs> args) { DetectCompatiblePackage?.Invoke(this, args); }

        /// <summary>Called when a package was not detected but a package using the same provider key was.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.DetectCompatiblePackageEventArgs>> DetectCompatiblePackage;

        /// <summary>Called when the detection phase has completed.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnDetectComplete(WPFBootstrapperEventArgs<Wix.DetectCompleteEventArgs> args) { DetectComplete?.Invoke(this, args); }

        /// <summary>Called when the detection phase has completed.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.DetectCompleteEventArgs>> DetectComplete;

        /// <summary>Called when the engine has begun installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnDetectForwardCompatibleBundle(WPFBootstrapperEventArgs<Wix.DetectForwardCompatibleBundleEventArgs> args) { DetectForwardCompatibleBundle?.Invoke(this, args); }

        /// <summary>Called when the engine has begun installing the bundle.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.DetectForwardCompatibleBundleEventArgs>> DetectForwardCompatibleBundle;

        /// <summary>Called when an MSI feature has been detected for a package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnDetectMsiFeature(WPFBootstrapperEventArgs<Wix.DetectMsiFeatureEventArgs> args)
        {
            this.SetFeatureDetectedState(args.Arguments);
            DetectMsiFeature?.Invoke(this, args);
        }

        /// <summary>Called when an MSI feature has been detected for a package.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.DetectMsiFeatureEventArgs>> DetectMsiFeature;

        /// <summary>Called when the detection for a specific package has begun.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnDetectPackageBegin(WPFBootstrapperEventArgs<Wix.DetectPackageBeginEventArgs> args) { DetectPackageBegin?.Invoke(this, args); }

        /// <summary>Called when the detection for a specific package has begun.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.DetectPackageBeginEventArgs>> DetectPackageBegin;

        /// <summary>Called when the detection for a specific package has completed.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnDetectPackageComplete(WPFBootstrapperEventArgs<Wix.DetectPackageCompleteEventArgs> args)
        {
            this.SetPackageDetectedState(args.Arguments);
            DetectPackageComplete?.Invoke(this, args);
        }

        /// <summary>Called when the detection for a specific package has completed.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.DetectPackageCompleteEventArgs>> DetectPackageComplete;

        /// <summary>Called when the detection for a prior bundle has begun.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnDetectPriorBundle(WPFBootstrapperEventArgs<Wix.DetectPriorBundleEventArgs> args) { DetectPriorBundle?.Invoke(this, args); }

        /// <summary>Called when the detection for a prior bundle has begun.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.DetectPriorBundleEventArgs>> DetectPriorBundle;

        /// <summary>Called when a related bundle has been detected for a bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnDetectRelatedBundle(WPFBootstrapperEventArgs<Wix.DetectRelatedBundleEventArgs> args) { DetectRelatedBundle?.Invoke(this, args); }

        /// <summary>Called when a related bundle has been detected for a bundle.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.DetectRelatedBundleEventArgs>> DetectRelatedBundle;

        /// <summary>Called when a related MSI package has been detected for a package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnDetectRelatedMsiPackage(WPFBootstrapperEventArgs<Wix.DetectRelatedMsiPackageEventArgs> args) { DetectRelatedMsiPackage?.Invoke(this, args); }

        /// <summary>Called when a related MSI package has been detected for a package.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.DetectRelatedMsiPackageEventArgs>> DetectRelatedMsiPackage;

        /// <summary>Called when an MSP package detects a target MSI has been detected.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnDetectTargetMsiPackage(WPFBootstrapperEventArgs<Wix.DetectTargetMsiPackageEventArgs> args) { DetectTargetMsiPackage?.Invoke(this, args); }

        /// <summary>Called when an MSP package detects a target MSI has been detected.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.DetectTargetMsiPackageEventArgs>> DetectTargetMsiPackage;

        /// <summary>Fired when the update detection has found a potential update candidate.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        public void OnDetectUpdate(WPFBootstrapperEventArgs<Wix.DetectUpdateEventArgs> args) { DetectUpdate?.Invoke(this, args); }

        /// <summary>Fired when the update detection has found a potential update candidate.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.DetectUpdateEventArgs>> DetectUpdate;

        /// <summary>Called when the engine has begun installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnDetectUpdateBegin(WPFBootstrapperEventArgs<Wix.DetectUpdateBeginEventArgs> args) { DetectUpdateBegin?.Invoke(this, args); }

        /// <summary>Called when the engine has begun installing the bundle.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.DetectUpdateBeginEventArgs>> DetectUpdateBegin;

        /// <summary>Called when the engine has begun installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnDetectUpdateComplete(WPFBootstrapperEventArgs<Wix.DetectUpdateCompleteEventArgs> args) { DetectUpdateComplete?.Invoke(this, args); }

        /// <summary>Called when the engine has begun installing the bundle.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.DetectUpdateCompleteEventArgs>> DetectUpdateComplete;

        /// <summary>Called when the engine is about to start the elevated process.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnElevate(WPFBootstrapperEventArgs<Wix.ElevateEventArgs> args) { Elevate?.Invoke(this, args); }

        /// <summary>Called when the engine is about to start the elevated process.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.ElevateEventArgs>> Elevate;

        /// <summary>Called when the engine has encountered an error.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnError(WPFBootstrapperEventArgs<Wix.ErrorEventArgs> args) { Error?.Invoke(this, args); }

        /// <summary>Called when the engine has encountered an error.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.ErrorEventArgs>> Error;

        /// <summary>Called when the engine has begun installing packages.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnExecuteBegin(WPFBootstrapperEventArgs<Wix.ExecuteBeginEventArgs> args) { ExecuteBegin?.Invoke(this, args); }

        /// <summary>Called when the engine has begun installing packages.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.ExecuteBeginEventArgs>> ExecuteBegin;

        /// <summary>Called when the engine has completed installing packages.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnExecuteComplete(WPFBootstrapperEventArgs<Wix.ExecuteCompleteEventArgs> args) { ExecuteComplete?.Invoke(this, args); }

        /// <summary>Called when the engine has completed installing packages.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.ExecuteCompleteEventArgs>> ExecuteComplete;

        /// <summary>Called when Windows Installer sends a file in use installation message.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnExecuteFilesInUse(WPFBootstrapperEventArgs<Wix.ExecuteFilesInUseEventArgs> args) { ExecuteFilesInUse?.Invoke(this, args); }

        /// <summary>Called when Windows Installer sends a file in use installation message.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.ExecuteFilesInUseEventArgs>> ExecuteFilesInUse;

        /// <summary>Called when Windows Installer sends an installation message.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnExecuteMsiMessage(WPFBootstrapperEventArgs<Wix.ExecuteMsiMessageEventArgs> args) { ExecuteMsiMessage?.Invoke(this, args); }

        /// <summary>Called when Windows Installer sends an installation message.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.ExecuteMsiMessageEventArgs>> ExecuteMsiMessage;

        /// <summary>Called when the engine has begun installing a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnExecutePackageBegin(WPFBootstrapperEventArgs<Wix.ExecutePackageBeginEventArgs> args) { ExecutePackageBegin?.Invoke(this, args); }

        /// <summary>Called when the engine has begun installing a specific package.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.ExecutePackageBeginEventArgs>> ExecutePackageBegin;

        /// <summary>Called when the engine has completed installing a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnExecutePackageComplete(WPFBootstrapperEventArgs<Wix.ExecutePackageCompleteEventArgs> args) { ExecutePackageComplete?.Invoke(this, args); }

        /// <summary>Called when the engine has completed installing a specific package.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.ExecutePackageCompleteEventArgs>> ExecutePackageComplete;

        /// <summary>Called when the engine executes one or more patches targeting a product.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnExecutePatchTarget(WPFBootstrapperEventArgs<Wix.ExecutePatchTargetEventArgs> args) { ExecutePatchTarget?.Invoke(this, args); }

        /// <summary>Called when the engine executes one or more patches targeting a product.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.ExecutePatchTargetEventArgs>> ExecutePatchTarget;

        /// <summary>Called by the engine while executing on payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnExecuteProgress(WPFBootstrapperEventArgs<Wix.ExecuteProgressEventArgs> args) { ExecuteProgress?.Invoke(this, args); }

        /// <summary>Called by the engine while executing on payload.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.ExecuteProgressEventArgs>> ExecuteProgress;

        /// <summary>Called by the engine before trying to launch the preapproved executable.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        public void OnLaunchApprovedExeBegin(WPFBootstrapperEventArgs<Wix.LaunchApprovedExeBeginArgs> args) { LaunchApprovedExeBegin?.Invoke(this, args); }

        /// <summary>Called by the engine before trying to launch the preapproved executable.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.LaunchApprovedExeBeginArgs>> LaunchApprovedExeBegin;

        /// <summary>Called by the engine after trying to launch the preapproved executable.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        public void OnLaunchApprovedExeComplete(WPFBootstrapperEventArgs<Wix.LaunchApprovedExeCompleteArgs> args) { LaunchApprovedExeComplete?.Invoke(this, args); }

        /// <summary>Called by the engine after trying to launch the preapproved executable.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.LaunchApprovedExeCompleteArgs>> LaunchApprovedExeComplete;

        /// <summary>Called when the engine has begun planning the installation.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnPlanBegin(WPFBootstrapperEventArgs<Wix.PlanBeginEventArgs> args) { PlanBegin?.Invoke(this, args); }

        /// <summary>Called when the engine has begun planning the installation.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.PlanBeginEventArgs>> PlanBegin;

        /// <summary>Called when the engine plans a new, compatible package using the same provider key.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        public void OnPlanCompatiblePackage(WPFBootstrapperEventArgs<Wix.PlanCompatiblePackageEventArgs> args) { PlanCompatiblePackage?.Invoke(this, args); }

        /// <summary>Called when the engine plans a new, compatible package using the same provider key.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.PlanCompatiblePackageEventArgs>> PlanCompatiblePackage;

        /// <summary>Called when the engine has completed planning the installation.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnPlanComplete(WPFBootstrapperEventArgs<Wix.PlanCompleteEventArgs> args) { PlanComplete?.Invoke(this, args); }

        /// <summary>Called when the engine has completed planning the installation.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.PlanCompleteEventArgs>> PlanComplete;

        /// <summary>Called when the engine is about to plan an MSI feature of a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnPlanMsiFeature(WPFBootstrapperEventArgs<Wix.PlanMsiFeatureEventArgs> args)
        {
            this.SetFeaturePlannedState(args.Arguments);
            PlanMsiFeature?.Invoke(this, args);
        }

        /// <summary>Called when the engine is about to plan an MSI feature of a specific package.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.PlanMsiFeatureEventArgs>> PlanMsiFeature;

        /// <summary>Called when the engine has begun planning the installation of a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnPlanPackageBegin(WPFBootstrapperEventArgs<Wix.PlanPackageBeginEventArgs> args)
        {
            this.SetPackagePlannedState(args.Arguments);
            PlanPackageBegin?.Invoke(this, args);
        }

        /// <summary>Called when the engine has begun planning the installation of a specific package.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.PlanPackageBeginEventArgs>> PlanPackageBegin;

        /// <summary>Called when then engine has completed planning the installation of a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnPlanPackageComplete(WPFBootstrapperEventArgs<Wix.PlanPackageCompleteEventArgs> args) { PlanPackageComplete?.Invoke(this, args); }

        /// <summary>Called when then engine has completed planning the installation of a specific package.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.PlanPackageCompleteEventArgs>> PlanPackageComplete;

        /// <summary>Called when the engine has begun planning for a prior bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnPlanRelatedBundle(WPFBootstrapperEventArgs<Wix.PlanRelatedBundleEventArgs> args) { PlanRelatedBundle?.Invoke(this, args); }

        /// <summary>Called when the engine has begun planning for a prior bundle.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.PlanRelatedBundleEventArgs>> PlanRelatedBundle;

        /// <summary>Called when the engine is about to plan the target MSI of a MSP package.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnPlanTargetMsiPackage(WPFBootstrapperEventArgs<Wix.PlanTargetMsiPackageEventArgs> args) { PlanTargetMsiPackage?.Invoke(this, args); }

        /// <summary>Called when the engine is about to plan the target MSI of a MSP package.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.PlanTargetMsiPackageEventArgs>> PlanTargetMsiPackage;

        /// <summary>Called when the engine has changed progress for the bundle installation.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnProgress(WPFBootstrapperEventArgs<Wix.ProgressEventArgs> args) { Progress?.Invoke(this, args); }

        /// <summary>Called when the engine has changed progress for the bundle installation.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.ProgressEventArgs>> Progress;

        /// <summary>Called when the engine has begun registering the location and visibility of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnRegisterBegin(WPFBootstrapperEventArgs<Wix.RegisterBeginEventArgs> args) { RegisterBegin?.Invoke(this, args); }

        /// <summary>Called when the engine has begun registering the location and visibility of the bundle.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.RegisterBeginEventArgs>> RegisterBegin;

        /// <summary>Called when the engine has completed registering the location and visilibity of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnRegisterComplete(WPFBootstrapperEventArgs<Wix.RegisterCompleteEventArgs> args) { RegisterComplete?.Invoke(this, args); }

        /// <summary>Called when the engine has completed registering the location and visilibity of the bundle.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.RegisterCompleteEventArgs>> RegisterComplete;

        /// <summary>Called by the engine to allow the user experience to change the source using <see cref="M:Engine.SetLocalSource"/> or <see cref="M:Engine.SetDownloadSource"/>.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnResolveSource(WPFBootstrapperEventArgs<Wix.ResolveSourceEventArgs> args) { ResolveSource?.Invoke(this, args); }

        /// <summary>Called by the engine to allow the user experience to change the source using <see cref="M:Engine.SetLocalSource"/> or <see cref="M:Engine.SetDownloadSource"/>.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.ResolveSourceEventArgs>> ResolveSource;

        /// <summary>Called by the engine to request a restart now or inform the user a manual restart is required later.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnRestartRequired(WPFBootstrapperEventArgs<Wix.RestartRequiredEventArgs> args) { RestartRequired?.Invoke(this, args); }

        /// <summary>Called by the engine to request a restart now or inform the user a manual restart is required later.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.RestartRequiredEventArgs>> RestartRequired;

        /// <summary>Called by the engine to uninitialize the user experience.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnShutdown(WPFBootstrapperEventArgs<Wix.ShutdownEventArgs> args) { Shutdown?.Invoke(this, args); }

        /// <summary>Called by the engine to uninitialize the user experience.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.ShutdownEventArgs>> Shutdown;

        /// <summary>Called by the engine on startup of the bootstrapper application.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnStartup(WPFBootstrapperEventArgs<Wix.StartupEventArgs> args) { Startup?.Invoke(this, args); }

        /// <summary>Called by the engine on startup of the bootstrapper application.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.StartupEventArgs>> Startup;

        /// <summary>Called when the system is shutting down or the user is logging off.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnSystemShutdown(WPFBootstrapperEventArgs<Wix.SystemShutdownEventArgs> args) { SystemShutdown?.Invoke(this, args); }

        /// <summary>Called when the system is shutting down or the user is logging off.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.SystemShutdownEventArgs>> SystemShutdown;

        /// <summary>Called when the engine has begun removing the registration for the location and visibility of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnUnregisterBegin(WPFBootstrapperEventArgs<Wix.UnregisterBeginEventArgs> args) { UnregisterBegin?.Invoke(this, args); }

        /// <summary>Called when the engine has begun removing the registration for the location and visibility of the bundle.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.UnregisterBeginEventArgs>> UnregisterBegin;

        /// <summary>Called when the engine has completed removing the registration for the location and visibility of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        public void OnUnregisterComplete(WPFBootstrapperEventArgs<Wix.UnregisterCompleteEventArgs> args) { UnregisterComplete?.Invoke(this, args); }

        /// <summary>Called when the engine has completed removing the registration for the location and visibility of the bundle.</summary>
        public event EventHandler<WPFBootstrapperEventArgs<Wix.UnregisterCompleteEventArgs>> UnregisterComplete;

        /// <summary>
        /// Called when the a message should be logged.
        /// </summary>
        /// <param name="level">The log level.</param>
        /// <param name="message">The message.</param>
        public void OnLogMessage(Wix.LogLevel level, string message) { LogMessage?.Invoke(this, new LogEventArgs(level, message)); }

        /// <summary>alled when the a message should be logged.</summary>
        public event EventHandler<LogEventArgs> LogMessage;

        /// <summary>
        /// Called when command line is parsing.
        /// </summary>
        /// <param name="args">The arguments of the event.</param>
        /// <returns><c>true</c> if arguments was handled, <c>false</c> otherwise.</returns>
        public void OnCommandLineParsing(CommandLineParseEventArgs args) { CommandLineParsing?.Invoke(this, args); }

        /// <summary>alled when the a message should be logged.</summary>
        public event EventHandler<CommandLineParseEventArgs> CommandLineParsing;
    }

    public class LogEventArgs : EventArgs
    {
        public Wix.LogLevel Level { get; private set; }

        public string Message { get; private set; }

        public LogEventArgs(Wix.LogLevel level, string message)
        {
            this.Level = level;
            this.Message = message;
        }
    }

    public class CommandLineParseEventArgs : EventArgs
    {
        public string Name { get; private set; }

        public string Value { get; private set; }

        public CommandLineArgumentType Type { get; private set; }

        /// <summary>True to cancel the event, otherwise false.</summary>
        public bool Handled { get; set; }

        public CommandLineParseEventArgs(string name, string value, CommandLineArgumentType type)
        {
            this.Name = name;
            this.Value = value;
            this.Type = type;
            this.Handled = false;
        }
    }

    public enum CommandLineArgumentType
    {
        Parameter,
        SecuredParameter,
        Command
    }
}