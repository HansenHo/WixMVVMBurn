using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

namespace WixMVVMBurnUI.Core
{
    [DebuggerDisplay("Display: {DisplayName}, Id: {Feature}, Parent: {Parent}")]
    public class PackageFeature
    {
        private XElement xNode;

        public PackageFeature(XElement xNode)
        {
            this.xNode = xNode;
            this.Features = new List<PackageFeature>();
        }

        public List<PackageFeature> Features { get; internal set; }

        public BundlePackage Package { get; internal set; }

        public string PackageId
        {
            get
            {
                return xNode.Attribute("Package")?.Value;
            }
        }

        public string DisplayName
        {
            get
            {
                return xNode.Attribute("Title")?.Value;
            }
        }

        public string Description
        {
            get
            {
                return xNode.Attribute(nameof(Description))?.Value;
            }
        }

        public string Feature
        {
            get
            {
                return xNode.Attribute(nameof(Feature))?.Value;
            }
        }

        public PackageFeature Parent
        {
            get; internal set;
        }

        public string ParentId
        {
            get
            {
                return xNode.Attribute("Parent")?.Value;
            }
        }

        public int Level
        {
            get
            {
                return int.Parse(xNode.Attribute(nameof(Level))?.Value);
            }
        }

        public string Directory
        {
            get
            {
                return xNode.Attribute(nameof(Directory))?.Value;
            }
        }

        public MsiSetFeatureAttributes Attributes
        {
            get
            {
                XAttribute attr = xNode.Attribute(nameof(Attributes));
                if (attr != null)
                {
                    return (MsiSetFeatureAttributes)int.Parse(attr.Value);
                }
                else
                {
                    return MsiSetFeatureAttributes.None;
                }
            }
        }

        public MsiSetFeatureDisplay Display
        {
            get
            {
                XAttribute attr = xNode.Attribute(nameof(Display));
                if (attr != null)
                {
                    return (MsiSetFeatureDisplay)int.Parse(attr.Value);
                }
                else
                {
                    return MsiSetFeatureDisplay.Collapse;
                }
            }
        }

        public FeatureState CurrentInstallState { get; internal set; }
        public FeatureState? RequestedState { get; internal set; }
    }
}