namespace VControl.Controls.VExpandable
{
    public interface IExpanderAnimation
    {
        Task OnExpand(View expanderView);

        Task OnCollapse(View expanderView);
    }
}
