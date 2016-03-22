using System;
using WixMVVMBurnUI.Models;
using Wix = Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

namespace WixMVVMBurnUI
{
    public partial class WPFBootstrapper
    {
        /// <summary>Called when the engine has begun installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnApplyBegin(Wix.ApplyBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnApplyBegin");
            WPFBootstrapperEventArgs<Wix.ApplyBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ApplyBeginEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnApplyBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnApplyBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnApplyBegin");
        }

        /// <summary>Called when the engine has completed installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnApplyComplete(Wix.ApplyCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnApplyComplete");
            WPFBootstrapperEventArgs<Wix.ApplyCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ApplyCompleteEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnApplyComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnApplyComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnApplyComplete");
        }

        /// <summary>Called right after OnApplyBegin.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        protected override void OnApplyPhaseCount(Wix.ApplyPhaseCountArgs args)
        {
            LogVerbose("Enter Method: OnApplyPhaseCount");
            WPFBootstrapperEventArgs<Wix.ApplyPhaseCountArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ApplyPhaseCountArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnApplyPhaseCount(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnApplyPhaseCount(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnApplyPhaseCount");
        }

        /// <summary>Called when the engine begins to cache the container or payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCacheAcquireBegin(Wix.CacheAcquireBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnCacheAcquireBegin");
            WPFBootstrapperEventArgs<Wix.CacheAcquireBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CacheAcquireBeginEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnCacheAcquireBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnCacheAcquireBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnCacheAcquireBegin");
        }

        /// <summary>Called when the engine completes caching of the container or payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCacheAcquireComplete(Wix.CacheAcquireCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnCacheAcquireComplete");
            WPFBootstrapperEventArgs<Wix.CacheAcquireCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CacheAcquireCompleteEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnCacheAcquireComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnCacheAcquireComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnCacheAcquireComplete");
        }

        /// <summary>Called when the engine has progressed on caching the container or payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCacheAcquireProgress(Wix.CacheAcquireProgressEventArgs args)
        {
            LogVerbose("Enter Method: OnCacheAcquireProgress");
            WPFBootstrapperEventArgs<Wix.CacheAcquireProgressEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CacheAcquireProgressEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnCacheAcquireProgress(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnCacheAcquireProgress(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnCacheAcquireProgress");
        }

        /// <summary>Called when the engine begins to cache the installation sources.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCacheBegin(Wix.CacheBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnCacheBegin");
            WPFBootstrapperEventArgs<Wix.CacheBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CacheBeginEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnCacheBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnCacheBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnCacheBegin");
        }

        /// <summary>Called after the engine has cached the installation sources.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCacheComplete(Wix.CacheCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnCacheComplete");
            WPFBootstrapperEventArgs<Wix.CacheCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CacheCompleteEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnCacheComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnCacheComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnCacheComplete");
        }

        /// <summary>Called by the engine when it begins to cache a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCachePackageBegin(Wix.CachePackageBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnCachePackageBegin");
            WPFBootstrapperEventArgs<Wix.CachePackageBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CachePackageBeginEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnCachePackageBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnCachePackageBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnCachePackageBegin");
        }

        /// <summary>Called when the engine completes caching a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCachePackageComplete(Wix.CachePackageCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnCachePackageComplete");
            WPFBootstrapperEventArgs<Wix.CachePackageCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CachePackageCompleteEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnCachePackageComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnCachePackageComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnCachePackageComplete");
        }

        /// <summary>Called when the engine has started verify the payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCacheVerifyBegin(Wix.CacheVerifyBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnCacheVerifyBegin");
            WPFBootstrapperEventArgs<Wix.CacheVerifyBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CacheVerifyBeginEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnCacheVerifyBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnCacheVerifyBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnCacheVerifyBegin");
        }

        /// <summary>Called when the engine completes verification of the payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCacheVerifyComplete(Wix.CacheVerifyCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnCacheVerifyComplete");
            WPFBootstrapperEventArgs<Wix.CacheVerifyCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CacheVerifyCompleteEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnCacheVerifyComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnCacheVerifyComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnCacheVerifyComplete");
        }

        /// <summary>Called when the overall detection phase has begun.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectBegin(Wix.DetectBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectBegin");
            WPFBootstrapperEventArgs<Wix.DetectBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectBeginEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnDetectBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectBegin");
        }

        /// <summary>Called when a package was not detected but a package using the same provider key was.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        protected override void OnDetectCompatiblePackage(Wix.DetectCompatiblePackageEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectCompatiblePackage");
            WPFBootstrapperEventArgs<Wix.DetectCompatiblePackageEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectCompatiblePackageEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnDetectCompatiblePackage(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectCompatiblePackage(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectCompatiblePackage");
        }

        /// <summary>Called when the detection phase has completed.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectComplete(Wix.DetectCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectComplete");
            WPFBootstrapperEventArgs<Wix.DetectCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectCompleteEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnDetectComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectComplete");
        }

        /// <summary>Called when the engine has begun installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectForwardCompatibleBundle(Wix.DetectForwardCompatibleBundleEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectForwardCompatibleBundle");
            WPFBootstrapperEventArgs<Wix.DetectForwardCompatibleBundleEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectForwardCompatibleBundleEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnDetectForwardCompatibleBundle(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectForwardCompatibleBundle(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectForwardCompatibleBundle");
        }

        /// <summary>Called when an MSI feature has been detected for a package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectMsiFeature(Wix.DetectMsiFeatureEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectMsiFeature");
            WPFBootstrapperEventArgs<Wix.DetectMsiFeatureEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectMsiFeatureEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnDetectMsiFeature(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectMsiFeature(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectMsiFeature");
        }

        /// <summary>Called when the detection for a specific package has begun.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectPackageBegin(Wix.DetectPackageBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectPackageBegin");
            WPFBootstrapperEventArgs<Wix.DetectPackageBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectPackageBeginEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnDetectPackageBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectPackageBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectPackageBegin");
        }

        /// <summary>Called when the detection for a specific package has completed.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectPackageComplete(Wix.DetectPackageCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectPackageComplete");
            WPFBootstrapperEventArgs<Wix.DetectPackageCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectPackageCompleteEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnDetectPackageComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectPackageComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectPackageComplete");
        }

        /// <summary>Called when the detection for a prior bundle has begun.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectPriorBundle(Wix.DetectPriorBundleEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectPriorBundle");
            WPFBootstrapperEventArgs<Wix.DetectPriorBundleEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectPriorBundleEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnDetectPriorBundle(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectPriorBundle(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectPriorBundle");
        }

        /// <summary>Called when a related bundle has been detected for a bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectRelatedBundle(Wix.DetectRelatedBundleEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectRelatedBundle");
            WPFBootstrapperEventArgs<Wix.DetectRelatedBundleEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectRelatedBundleEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnDetectRelatedBundle(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectRelatedBundle(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectRelatedBundle");
        }

        /// <summary>Called when a related MSI package has been detected for a package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectRelatedMsiPackage(Wix.DetectRelatedMsiPackageEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectRelatedMsiPackage");
            WPFBootstrapperEventArgs<Wix.DetectRelatedMsiPackageEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectRelatedMsiPackageEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnDetectRelatedMsiPackage(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectRelatedMsiPackage(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectRelatedMsiPackage");
        }

        /// <summary>Called when an MSP package detects a target MSI has been detected.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectTargetMsiPackage(Wix.DetectTargetMsiPackageEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectTargetMsiPackage");
            WPFBootstrapperEventArgs<Wix.DetectTargetMsiPackageEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectTargetMsiPackageEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnDetectTargetMsiPackage(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectTargetMsiPackage(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectTargetMsiPackage");
        }

        /// <summary>Fired when the update detection has found a potential update candidate.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        protected override void OnDetectUpdate(Wix.DetectUpdateEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectUpdate");
            WPFBootstrapperEventArgs<Wix.DetectUpdateEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectUpdateEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnDetectUpdate(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectUpdate(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectUpdate");
        }

        /// <summary>Called when the engine has begun installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectUpdateBegin(Wix.DetectUpdateBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectUpdateBegin");
            WPFBootstrapperEventArgs<Wix.DetectUpdateBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectUpdateBeginEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnDetectUpdateBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectUpdateBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectUpdateBegin");
        }

        /// <summary>Called when the engine has begun installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectUpdateComplete(Wix.DetectUpdateCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnDetectUpdateComplete");
            WPFBootstrapperEventArgs<Wix.DetectUpdateCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectUpdateCompleteEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnDetectUpdateComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectUpdateComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnDetectUpdateComplete");
        }

        /// <summary>Called when the engine is about to start the elevated process.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnElevate(Wix.ElevateEventArgs args)
        {
            LogVerbose("Enter Method: OnElevate");
            WPFBootstrapperEventArgs<Wix.ElevateEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ElevateEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnElevate(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnElevate(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnElevate");
        }

        /// <summary>Called when the engine has encountered an error.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnError(Wix.ErrorEventArgs args)
        {
            LogVerbose("Enter Method: OnError");
            WPFBootstrapperEventArgs<Wix.ErrorEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ErrorEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnError(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnError(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnError");
        }

        /// <summary>Called when the engine has begun installing packages.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecuteBegin(Wix.ExecuteBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnExecuteBegin");
            WPFBootstrapperEventArgs<Wix.ExecuteBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecuteBeginEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnExecuteBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnExecuteBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnExecuteBegin");
        }

        /// <summary>Called when the engine has completed installing packages.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecuteComplete(Wix.ExecuteCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnExecuteComplete");
            WPFBootstrapperEventArgs<Wix.ExecuteCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecuteCompleteEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnExecuteComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnExecuteComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnExecuteComplete");
        }

        /// <summary>Called when Windows Installer sends a file in use installation message.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecuteFilesInUse(Wix.ExecuteFilesInUseEventArgs args)
        {
            LogVerbose("Enter Method: OnExecuteFilesInUse");
            WPFBootstrapperEventArgs<Wix.ExecuteFilesInUseEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecuteFilesInUseEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnExecuteFilesInUse(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnExecuteFilesInUse(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnExecuteFilesInUse");
        }

        /// <summary>Called when Windows Installer sends an installation message.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecuteMsiMessage(Wix.ExecuteMsiMessageEventArgs args)
        {
            LogVerbose("Enter Method: OnExecuteMsiMessage");
            WPFBootstrapperEventArgs<Wix.ExecuteMsiMessageEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecuteMsiMessageEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnExecuteMsiMessage(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnExecuteMsiMessage(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnExecuteMsiMessage");
        }

        /// <summary>Called when the engine has begun installing a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecutePackageBegin(Wix.ExecutePackageBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnExecutePackageBegin");
            WPFBootstrapperEventArgs<Wix.ExecutePackageBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecutePackageBeginEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnExecutePackageBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnExecutePackageBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnExecutePackageBegin");
        }

        /// <summary>Called when the engine has completed installing a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecutePackageComplete(Wix.ExecutePackageCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnExecutePackageComplete");
            WPFBootstrapperEventArgs<Wix.ExecutePackageCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecutePackageCompleteEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnExecutePackageComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnExecutePackageComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnExecutePackageComplete");
        }

        /// <summary>Called when the engine executes one or more patches targeting a product.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecutePatchTarget(Wix.ExecutePatchTargetEventArgs args)
        {
            LogVerbose("Enter Method: OnExecutePatchTarget");
            WPFBootstrapperEventArgs<Wix.ExecutePatchTargetEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecutePatchTargetEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnExecutePatchTarget(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnExecutePatchTarget(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnExecutePatchTarget");
        }

        /// <summary>Called by the engine while executing on payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecuteProgress(Wix.ExecuteProgressEventArgs args)
        {
            LogVerbose("Enter Method: OnExecuteProgress");
            WPFBootstrapperEventArgs<Wix.ExecuteProgressEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecuteProgressEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnExecuteProgress(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnExecuteProgress(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnExecuteProgress");
        }

        /// <summary>Called by the engine before trying to launch the preapproved executable.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        protected override void OnLaunchApprovedExeBegin(Wix.LaunchApprovedExeBeginArgs args)
        {
            LogVerbose("Enter Method: OnLaunchApprovedExeBegin");
            WPFBootstrapperEventArgs<Wix.LaunchApprovedExeBeginArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.LaunchApprovedExeBeginArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnLaunchApprovedExeBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnLaunchApprovedExeBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnLaunchApprovedExeBegin");
        }

        /// <summary>Called by the engine after trying to launch the preapproved executable.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        protected override void OnLaunchApprovedExeComplete(Wix.LaunchApprovedExeCompleteArgs args)
        {
            LogVerbose("Enter Method: OnLaunchApprovedExeComplete");
            WPFBootstrapperEventArgs<Wix.LaunchApprovedExeCompleteArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.LaunchApprovedExeCompleteArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnLaunchApprovedExeComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnLaunchApprovedExeComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnLaunchApprovedExeComplete");
        }

        /// <summary>Called when the engine has begun planning the installation.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnPlanBegin(Wix.PlanBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnPlanBegin");
            WPFBootstrapperEventArgs<Wix.PlanBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanBeginEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnPlanBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnPlanBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnPlanBegin");
        }

        /// <summary>Called when the engine plans a new, compatible package using the same provider key.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        protected override void OnPlanCompatiblePackage(Wix.PlanCompatiblePackageEventArgs args)
        {
            LogVerbose("Enter Method: OnPlanCompatiblePackage");
            WPFBootstrapperEventArgs<Wix.PlanCompatiblePackageEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanCompatiblePackageEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnPlanCompatiblePackage(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnPlanCompatiblePackage(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnPlanCompatiblePackage");
        }

        /// <summary>Called when the engine has completed planning the installation.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnPlanComplete(Wix.PlanCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnPlanComplete");
            WPFBootstrapperEventArgs<Wix.PlanCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanCompleteEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnPlanComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnPlanComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnPlanComplete");
        }

        /// <summary>Called when the engine is about to plan an MSI feature of a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnPlanMsiFeature(Wix.PlanMsiFeatureEventArgs args)
        {
            LogVerbose("Enter Method: OnPlanMsiFeature");
            WPFBootstrapperEventArgs<Wix.PlanMsiFeatureEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanMsiFeatureEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnPlanMsiFeature(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnPlanMsiFeature(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnPlanMsiFeature");
        }

        /// <summary>Called when the engine has begun planning the installation of a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnPlanPackageBegin(Wix.PlanPackageBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnPlanPackageBegin");
            WPFBootstrapperEventArgs<Wix.PlanPackageBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanPackageBeginEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnPlanPackageBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnPlanPackageBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnPlanPackageBegin");
        }

        /// <summary>Called when then engine has completed planning the installation of a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnPlanPackageComplete(Wix.PlanPackageCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnPlanPackageComplete");
            WPFBootstrapperEventArgs<Wix.PlanPackageCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanPackageCompleteEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnPlanPackageComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnPlanPackageComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnPlanPackageComplete");
        }

        /// <summary>Called when the engine has begun planning for a prior bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnPlanRelatedBundle(Wix.PlanRelatedBundleEventArgs args)
        {
            LogVerbose("Enter Method: OnPlanRelatedBundle");
            WPFBootstrapperEventArgs<Wix.PlanRelatedBundleEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanRelatedBundleEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnPlanRelatedBundle(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnPlanRelatedBundle(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnPlanRelatedBundle");
        }

        /// <summary>Called when the engine is about to plan the target MSI of a MSP package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnPlanTargetMsiPackage(Wix.PlanTargetMsiPackageEventArgs args)
        {
            LogVerbose("Enter Method: OnPlanTargetMsiPackage");
            WPFBootstrapperEventArgs<Wix.PlanTargetMsiPackageEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanTargetMsiPackageEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnPlanTargetMsiPackage(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnPlanTargetMsiPackage(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnPlanTargetMsiPackage");
        }

        /// <summary>Called when the engine has changed progress for the bundle installation.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnProgress(Wix.ProgressEventArgs args)
        {
            LogVerbose("Enter Method: OnProgress");
            WPFBootstrapperEventArgs<Wix.ProgressEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ProgressEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnProgress(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnProgress(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnProgress");
        }

        /// <summary>Called when the engine has begun registering the location and visibility of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnRegisterBegin(Wix.RegisterBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnRegisterBegin");
            WPFBootstrapperEventArgs<Wix.RegisterBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.RegisterBeginEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnRegisterBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnRegisterBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnRegisterBegin");
        }

        /// <summary>Called when the engine has completed registering the location and visilibity of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnRegisterComplete(Wix.RegisterCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnRegisterComplete");
            WPFBootstrapperEventArgs<Wix.RegisterCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.RegisterCompleteEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnRegisterComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnRegisterComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnRegisterComplete");
        }

        /// <summary>Called by the engine to allow the user experience to change the source using <see cref="M:Engine.SetLocalSource"/> or <see cref="M:Engine.SetDownloadSource"/>.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnResolveSource(Wix.ResolveSourceEventArgs args)
        {
            LogVerbose("Enter Method: OnResolveSource");
            WPFBootstrapperEventArgs<Wix.ResolveSourceEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ResolveSourceEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnResolveSource(cancelArgs); }));
            if (!cancelArgs.Cancel)
            {
                args.Result = !string.IsNullOrEmpty(args.DownloadSource) ? Wix.Result.Download : Wix.Result.Ok;
                base.OnResolveSource(cancelArgs.Arguments);
            }
            LogVerbose("Leaving Method: OnResolveSource");
        }

        /// <summary>Called by the engine to request a restart now or inform the user a manual restart is required later.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnRestartRequired(Wix.RestartRequiredEventArgs args)
        {
            LogVerbose("Enter Method: OnRestartRequired");
            WPFBootstrapperEventArgs<Wix.RestartRequiredEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.RestartRequiredEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnRestartRequired(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnRestartRequired(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnRestartRequired");
        }

        /// <summary>Called by the engine to uninitialize the user experience.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnShutdown(Wix.ShutdownEventArgs args)
        {
            LogVerbose("Enter Method: OnShutdown");
            WPFBootstrapperEventArgs<Wix.ShutdownEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ShutdownEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnShutdown(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnShutdown(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnShutdown");
        }

        /// <summary>Called by the engine on startup of the bootstrapper application.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnStartup(Wix.StartupEventArgs args)
        {
            LogVerbose("Enter Method: OnStartup");
            WPFBootstrapperEventArgs<Wix.StartupEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.StartupEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnStartup(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnStartup(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnStartup");
        }

        /// <summary>Called when the system is shutting down or the user is logging off.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnSystemShutdown(Wix.SystemShutdownEventArgs args)
        {
            LogVerbose("Enter Method: OnSystemShutdown");
            WPFBootstrapperEventArgs<Wix.SystemShutdownEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.SystemShutdownEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnSystemShutdown(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnSystemShutdown(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnSystemShutdown");
        }

        /// <summary>Called when the engine has begun removing the registration for the location and visibility of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnUnregisterBegin(Wix.UnregisterBeginEventArgs args)
        {
            LogVerbose("Enter Method: OnUnregisterBegin");
            WPFBootstrapperEventArgs<Wix.UnregisterBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.UnregisterBeginEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnUnregisterBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnUnregisterBegin(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnUnregisterBegin");
        }

        /// <summary>Called when the engine has completed removing the registration for the location and visibility of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnUnregisterComplete(Wix.UnregisterCompleteEventArgs args)
        {
            LogVerbose("Enter Method: OnUnregisterComplete");
            WPFBootstrapperEventArgs<Wix.UnregisterCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.UnregisterCompleteEventArgs>(args);
            TryInvoke(new Action(() => { viewModel.OnUnregisterComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnUnregisterComplete(cancelArgs.Arguments); }
            LogVerbose("Leaving Method: OnUnregisterComplete");
        }
    }
}