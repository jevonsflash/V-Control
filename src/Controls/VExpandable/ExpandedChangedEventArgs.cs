namespace VControl.Controls.VExpandable
{
    public class ExpandedChangedEventArgs(bool isExpanded) : EventArgs
    {
        /// <summary>
        /// True if Is Expanded.
        /// </summary>
        public bool IsExpanded { get; } = isExpanded;
    }
}