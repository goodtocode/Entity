namespace GoodToCode.Framework.Flow
{
    /// <summary>
    /// Flow route info
    /// </summary>
    public interface IFlowRoute
    {
        /// <summary>
        /// Name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// ControllerName
        /// </summary>
        string ControllerName { get; }

        /// <summary>
        /// Path
        /// </summary>
        string Path { get; }

        /// <summary>
        /// RootUrl
        /// </summary>
        string RootUrl { get; set; }
    }
}
