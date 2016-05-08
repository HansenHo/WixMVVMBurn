namespace WixMVVMBurnUI.Core
{
    /// <summary>
    /// The MsiSetFeatureAttributes function can modify the default attributes of a feature at runtime. Note that the default attributes of features are authored in the Attributes column of the Feature table.
    /// </summary>
    public enum MsiSetFeatureAttributes
    {
        /// <summary>
        /// No attributes set
        /// </summary>
        None = 0,

        /// <summary>
        /// Modifies default feature attributes to msidbFeatureAttributesFavorLocal at run time. See Attributes column of the Feature table for a description.
        /// </summary>
        FavorLocal = 1,

        /// <summary>
        /// Modifies default feature attributes to msidbFeatureAttributesFavorSource at run time. See Attributes column of the Feature table for a description.
        /// </summary>
        FavorSource = 2,

        /// <summary>
        /// Modifies default feature attributes to msidbFeatureAttributesFollowParent at run time. Note that this is not a valid attribute to be set for top-level features. See Attributes column of the Feature table for a description.
        /// </summary>
        FollowParent = 4,

        /// <summary>
        /// Modifies default feature attributes to msidbFeatureAttributesFavorAdvertise at run time. See Attributes column of the Feature table for a description.
        /// </summary>
        FavorAdvertise = 8,

        /// <summary>
        /// Modifies default feature attributes to msidbFeatureAttributesDisallowAdvertise at run time. See Attributes column of the Feature table for a description.
        /// </summary>
        DisallowAdvertise = 16,

        /// <summary>
        /// Modifies default feature attributes to msidbFeatureAttributesNoUnsupportedAdvertise at run time. See Attributes column of the Feature table for a description.
        /// </summary>
        NoUnsupportedAdvertise = 32
    }
}