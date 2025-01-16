namespace VControl.Samples.Core.ViewModels
{
    public interface IDraggableViewModel
    {
        Command ItemDragged { get; set; }
        Command ItemDraggedOver { get; set; }
        Command ItemDragLeave { get; set; }
        Command ItemDropped { get; set; }
    }
}