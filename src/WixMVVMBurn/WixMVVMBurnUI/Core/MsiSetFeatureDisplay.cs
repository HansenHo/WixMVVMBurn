namespace WixMVVMBurnUI.Core
{
    /// <summary>
    /// Determines the initial display of this feature in the feature tree.
    /// </summary>
    public enum MsiSetFeatureDisplay
    {
        /// <summary>
        /// Initially shows the feature collapsed. This is the default value.
        /// </summary>
        Collapse = 0,

        /// <summary>
        /// Initially shows the feature expanded.
        /// </summary>
        Expand = 1,

        /// <summary>
        /// The hiddenPrevents the feature from displaying in the user interface.
        /// </summary>
        Hidden = 2
    }
}