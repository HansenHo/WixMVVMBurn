using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WixMVVMBurnUI.Core
{
    /// <summary>
    /// The states of detection.
    /// </summary>
    public enum DetectionState
    {
        Absent,
        Present,
        Newer,
    }

    /// <summary>
    /// The states of installation.
    /// </summary>
    public enum InstallationState
    {
        Initializing,
        Detecting,
        Waiting,
        Planning,
        Applying,
        Applied,
        Failed,
    }
}
