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
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.ApplyBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ApplyBeginEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnApplyBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnApplyBegin(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine has completed installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnApplyComplete(Wix.ApplyCompleteEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.ApplyCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ApplyCompleteEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnApplyComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnApplyComplete(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called right after OnApplyBegin.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        protected override void OnApplyPhaseCount(Wix.ApplyPhaseCountArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.ApplyPhaseCountArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ApplyPhaseCountArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnApplyPhaseCount(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnApplyPhaseCount(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine begins to cache the container or payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCacheAcquireBegin(Wix.CacheAcquireBeginEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.CacheAcquireBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CacheAcquireBeginEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnCacheAcquireBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnCacheAcquireBegin(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine completes caching of the container or payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCacheAcquireComplete(Wix.CacheAcquireCompleteEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.CacheAcquireCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CacheAcquireCompleteEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnCacheAcquireComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnCacheAcquireComplete(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine has progressed on caching the container or payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCacheAcquireProgress(Wix.CacheAcquireProgressEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.CacheAcquireProgressEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CacheAcquireProgressEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnCacheAcquireProgress(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnCacheAcquireProgress(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine begins to cache the installation sources.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCacheBegin(Wix.CacheBeginEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.CacheBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CacheBeginEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnCacheBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnCacheBegin(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called after the engine has cached the installation sources.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCacheComplete(Wix.CacheCompleteEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.CacheCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CacheCompleteEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnCacheComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnCacheComplete(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called by the engine when it begins to cache a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCachePackageBegin(Wix.CachePackageBeginEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.CachePackageBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CachePackageBeginEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnCachePackageBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnCachePackageBegin(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine completes caching a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCachePackageComplete(Wix.CachePackageCompleteEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.CachePackageCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CachePackageCompleteEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnCachePackageComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnCachePackageComplete(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine has started verify the payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCacheVerifyBegin(Wix.CacheVerifyBeginEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.CacheVerifyBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CacheVerifyBeginEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnCacheVerifyBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnCacheVerifyBegin(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine completes verification of the payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnCacheVerifyComplete(Wix.CacheVerifyCompleteEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.CacheVerifyCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.CacheVerifyCompleteEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnCacheVerifyComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnCacheVerifyComplete(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the overall detection phase has begun.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectBegin(Wix.DetectBeginEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.DetectBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectBeginEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnDetectBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectBegin(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when a package was not detected but a package using the same provider key was.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        protected override void OnDetectCompatiblePackage(Wix.DetectCompatiblePackageEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.DetectCompatiblePackageEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectCompatiblePackageEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnDetectCompatiblePackage(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectCompatiblePackage(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the detection phase has completed.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectComplete(Wix.DetectCompleteEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.DetectCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectCompleteEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnDetectComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectComplete(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine has begun installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectForwardCompatibleBundle(Wix.DetectForwardCompatibleBundleEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.DetectForwardCompatibleBundleEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectForwardCompatibleBundleEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnDetectForwardCompatibleBundle(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectForwardCompatibleBundle(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when an MSI feature has been detected for a package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectMsiFeature(Wix.DetectMsiFeatureEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.DetectMsiFeatureEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectMsiFeatureEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnDetectMsiFeature(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectMsiFeature(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the detection for a specific package has begun.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectPackageBegin(Wix.DetectPackageBeginEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.DetectPackageBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectPackageBeginEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnDetectPackageBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectPackageBegin(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the detection for a specific package has completed.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectPackageComplete(Wix.DetectPackageCompleteEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.DetectPackageCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectPackageCompleteEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnDetectPackageComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectPackageComplete(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the detection for a prior bundle has begun.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectPriorBundle(Wix.DetectPriorBundleEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.DetectPriorBundleEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectPriorBundleEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnDetectPriorBundle(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectPriorBundle(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when a related bundle has been detected for a bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectRelatedBundle(Wix.DetectRelatedBundleEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.DetectRelatedBundleEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectRelatedBundleEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnDetectRelatedBundle(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectRelatedBundle(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when a related MSI package has been detected for a package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectRelatedMsiPackage(Wix.DetectRelatedMsiPackageEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.DetectRelatedMsiPackageEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectRelatedMsiPackageEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnDetectRelatedMsiPackage(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectRelatedMsiPackage(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when an MSP package detects a target MSI has been detected.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectTargetMsiPackage(Wix.DetectTargetMsiPackageEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.DetectTargetMsiPackageEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectTargetMsiPackageEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnDetectTargetMsiPackage(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectTargetMsiPackage(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Fired when the update detection has found a potential update candidate.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        protected override void OnDetectUpdate(Wix.DetectUpdateEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.DetectUpdateEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectUpdateEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnDetectUpdate(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectUpdate(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine has begun installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectUpdateBegin(Wix.DetectUpdateBeginEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.DetectUpdateBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectUpdateBeginEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnDetectUpdateBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectUpdateBegin(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine has begun installing the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnDetectUpdateComplete(Wix.DetectUpdateCompleteEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.DetectUpdateCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.DetectUpdateCompleteEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnDetectUpdateComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnDetectUpdateComplete(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine is about to start the elevated process.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnElevate(Wix.ElevateEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.ElevateEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ElevateEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnElevate(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnElevate(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine has encountered an error.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnError(Wix.ErrorEventArgs args)
        {
            this.LogError("Bootstrapper.OnError [ErrorType={0}|ErrorCode={1}|ErrorMessage={2}]", args.ErrorType, args.ErrorCode, args.ErrorMessage);
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.ErrorEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ErrorEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnError(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnError(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine has begun installing packages.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecuteBegin(Wix.ExecuteBeginEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.ExecuteBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecuteBeginEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnExecuteBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnExecuteBegin(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine has completed installing packages.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecuteComplete(Wix.ExecuteCompleteEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.ExecuteCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecuteCompleteEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnExecuteComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnExecuteComplete(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when Windows Installer sends a file in use installation message.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecuteFilesInUse(Wix.ExecuteFilesInUseEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.ExecuteFilesInUseEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecuteFilesInUseEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnExecuteFilesInUse(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnExecuteFilesInUse(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when Windows Installer sends an installation message.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecuteMsiMessage(Wix.ExecuteMsiMessageEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.ExecuteMsiMessageEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecuteMsiMessageEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnExecuteMsiMessage(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnExecuteMsiMessage(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine has begun installing a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecutePackageBegin(Wix.ExecutePackageBeginEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.ExecutePackageBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecutePackageBeginEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnExecutePackageBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnExecutePackageBegin(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine has completed installing a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecutePackageComplete(Wix.ExecutePackageCompleteEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.ExecutePackageCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecutePackageCompleteEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnExecutePackageComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnExecutePackageComplete(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine executes one or more patches targeting a product.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecutePatchTarget(Wix.ExecutePatchTargetEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.ExecutePatchTargetEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecutePatchTargetEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnExecutePatchTarget(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnExecutePatchTarget(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called by the engine while executing on payload.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnExecuteProgress(Wix.ExecuteProgressEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.ExecuteProgressEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ExecuteProgressEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnExecuteProgress(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnExecuteProgress(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called by the engine before trying to launch the preapproved executable.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        protected override void OnLaunchApprovedExeBegin(Wix.LaunchApprovedExeBeginArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.LaunchApprovedExeBeginArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.LaunchApprovedExeBeginArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnLaunchApprovedExeBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnLaunchApprovedExeBegin(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called by the engine after trying to launch the preapproved executable.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        protected override void OnLaunchApprovedExeComplete(Wix.LaunchApprovedExeCompleteArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.LaunchApprovedExeCompleteArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.LaunchApprovedExeCompleteArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnLaunchApprovedExeComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnLaunchApprovedExeComplete(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine has begun planning the installation.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnPlanBegin(Wix.PlanBeginEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.PlanBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanBeginEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnPlanBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnPlanBegin(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine plans a new, compatible package using the same provider key.</summary>
        /// <param name="args">Additional arguments for this event.</param>
        protected override void OnPlanCompatiblePackage(Wix.PlanCompatiblePackageEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.PlanCompatiblePackageEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanCompatiblePackageEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnPlanCompatiblePackage(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnPlanCompatiblePackage(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine has completed planning the installation.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnPlanComplete(Wix.PlanCompleteEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.PlanCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanCompleteEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnPlanComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnPlanComplete(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine is about to plan an MSI feature of a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnPlanMsiFeature(Wix.PlanMsiFeatureEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.PlanMsiFeatureEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanMsiFeatureEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnPlanMsiFeature(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnPlanMsiFeature(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine has begun planning the installation of a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnPlanPackageBegin(Wix.PlanPackageBeginEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.PlanPackageBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanPackageBeginEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnPlanPackageBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnPlanPackageBegin(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when then engine has completed planning the installation of a specific package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnPlanPackageComplete(Wix.PlanPackageCompleteEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.PlanPackageCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanPackageCompleteEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnPlanPackageComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnPlanPackageComplete(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine has begun planning for a prior bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnPlanRelatedBundle(Wix.PlanRelatedBundleEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.PlanRelatedBundleEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanRelatedBundleEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnPlanRelatedBundle(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnPlanRelatedBundle(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine is about to plan the target MSI of a MSP package.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnPlanTargetMsiPackage(Wix.PlanTargetMsiPackageEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.PlanTargetMsiPackageEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.PlanTargetMsiPackageEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnPlanTargetMsiPackage(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnPlanTargetMsiPackage(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine has changed progress for the bundle installation.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnProgress(Wix.ProgressEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.ProgressEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ProgressEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnProgress(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnProgress(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine has begun registering the location and visibility of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnRegisterBegin(Wix.RegisterBeginEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.RegisterBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.RegisterBeginEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnRegisterBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnRegisterBegin(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine has completed registering the location and visilibity of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnRegisterComplete(Wix.RegisterCompleteEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.RegisterCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.RegisterCompleteEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnRegisterComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnRegisterComplete(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called by the engine to allow the user experience to change the source using <see cref="M:Engine.SetLocalSource"/> or <see cref="M:Engine.SetDownloadSource"/>.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnResolveSource(Wix.ResolveSourceEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.ResolveSourceEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ResolveSourceEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnResolveSource(cancelArgs); }));
            if (!cancelArgs.Cancel)
            {
                args.Result = !string.IsNullOrEmpty(args.DownloadSource) ? Wix.Result.Download : Wix.Result.Ok;
                base.OnResolveSource(cancelArgs.Arguments);
            }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called by the engine to request a restart now or inform the user a manual restart is required later.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnRestartRequired(Wix.RestartRequiredEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.RestartRequiredEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.RestartRequiredEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnRestartRequired(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnRestartRequired(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called by the engine to uninitialize the user experience.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnShutdown(Wix.ShutdownEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.ShutdownEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.ShutdownEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model?.OnShutdown(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnShutdown(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called by the engine on startup of the bootstrapper application.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnStartup(Wix.StartupEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.StartupEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.StartupEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model?.OnStartup(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnStartup(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the system is shutting down or the user is logging off.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnSystemShutdown(Wix.SystemShutdownEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.SystemShutdownEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.SystemShutdownEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model?.OnSystemShutdown(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnSystemShutdown(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine has begun removing the registration for the location and visibility of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnUnregisterBegin(Wix.UnregisterBeginEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.UnregisterBeginEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.UnregisterBeginEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnUnregisterBegin(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnUnregisterBegin(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>Called when the engine has completed removing the registration for the location and visibility of the bundle.</summary>
        /// <param name="args">The arguments of the event.</param>
        protected override void OnUnregisterComplete(Wix.UnregisterCompleteEventArgs args)
        {
            this.LogBootstrapperEnterEvent(args);
            WPFBootstrapperEventArgs<Wix.UnregisterCompleteEventArgs> cancelArgs = new WPFBootstrapperEventArgs<Wix.UnregisterCompleteEventArgs>(args);
            this.TryInvoke(new Action(() => { this.model.OnUnregisterComplete(cancelArgs); }));
            if (!cancelArgs.Cancel)
            { base.OnUnregisterComplete(cancelArgs.Arguments); }
            this.LogBootstrapperLeaveEvent(args);
        }

        /// <summary>
        /// Called when the a message should be logged.
        /// </summary>
        /// <param name="level">The log level.</param>
        /// <param name="message">The message.</param>
        protected void OnLogMessage(Wix.LogLevel level, string message)
        {
            this.TryInvoke(new Action(() => { this.model.OnLogMessage(level, message); }));
        }

        /// <summary>
        /// Called when command line is parsing.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if arguments was handled, <c>false</c> otherwise.</returns>
        protected bool OnCommandLineParsing(string name, string value, CommandLineArgumentType type)
        {
            CommandLineParseEventArgs args = new CommandLineParseEventArgs(name, value, type);
            this.TryInvoke(new Action(() => { this.model.OnCommandLineParsing(args); }));
            return args.Handled;
        }

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
    }
}