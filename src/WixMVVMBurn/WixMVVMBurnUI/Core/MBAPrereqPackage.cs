using System.Diagnostics;
using System.Xml.Linq;

namespace WixMVVMBurnUI.Core
{
    [DebuggerDisplay("Id: {PackageId}")]
    public class MBAPrereqPackage
    {
        private XElement xNode;

        public MBAPrereqPackage(XElement xNode)
        {
            this.xNode = xNode;
        }

        public string PackageId
        {
            get
            {
                return xNode.Attribute(nameof(PackageId))?.Value;
            }
        }

        public string LicenseUrl {
            get
            {
                return xNode.Attribute(nameof(LicenseUrl))?.Value;
            }
        }
    }
}