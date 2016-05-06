using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

namespace WixMVVMBurnUI.Core
{
    [DebuggerDisplay("Display: {DisplayName}, Id: {ProductCode}, Version: {Version}")]
    public class BundlePackage
    {
        private XElement xNode;

        public BundlePackage(XElement xNode)
        {
            this.xNode = xNode;
            this.AllFeatures = new List<PackageFeature>();
        }

        public List<PackageFeature> AllFeatures { get; internal set; }

        public PackageFeature RootFeature { get; internal set; }

        public string Package
        {
            get
            {
                return xNode.Attribute(nameof(Package))?.Value;
            }
        }

        public string DisplayName
        {
            get
            {
                return xNode.Attribute(nameof(DisplayName))?.Value;
            }
        }

        public string Description
        {
            get
            {
                return xNode.Attribute(nameof(Description))?.Value;
            }
        }

        public Guid ProductCode
        {
            get
            {
                XAttribute attr = xNode.Attribute(nameof(ProductCode));
                if (attr != null)
                {
                    return Guid.Parse(attr.Value);
                }
                else
                {
                    return Guid.Empty;
                }
            }
        }

        public Guid UpgradeCode
        {
            get
            {
                XAttribute attr = xNode.Attribute(nameof(UpgradeCode));
                if (attr != null)
                {
                    return Guid.Parse(attr.Value);
                }
                else
                {
                    return Guid.Empty;
                }
            }
        }

        public Version Version
        {
            get
            {
                return new Version(xNode.Attribute(nameof(Version))?.Value);
            }
        }

        public string PackageType
        {
            get
            {
                return xNode.Attribute(nameof(PackageType))?.Value;
            }
        }

        public PackageState CurrentInstallState { get; internal set; }

        public RequestState RequestedInstallState { get; internal set; }
    }
}