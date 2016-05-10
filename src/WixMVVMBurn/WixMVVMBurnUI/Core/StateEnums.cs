namespace WixMVVMBurnUI.Core
{
    /// <summary>
    /// The states of installation.
    /// </summary>
    public enum InstallationState
    {
        Initializing = 0,
        Detecting,
        Detected,
        Planning,
        Applying,
        Applied,
        Canceled,
        Failed,
    }

    [System.Serializable]
    public enum ProductInstallationState
    {
        Unknown,
        OlderVersionInstalled,
        NotInstalled,
        SameVersionInstalled,
        NewerVersionInstalled
    }
}