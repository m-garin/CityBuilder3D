
namespace PlacementArea
{
    /// <summary>
    /// Enum representing the state of how a building fits into a placement area
    /// </summary>
    public enum FitStatus
    {
        /// <summary>
        /// building fits in this location
        /// </summary>
        Fits,

        /// <summary>
        /// Tower overlaps another building in the placement area
        /// </summary>
        Overlaps,

        /// <summary>
        /// Building exceeds bounds of the placement area
        /// </summary>
        OutOfBounds
    }
}