namespace VControl.Samples.Core.ViewModels
{
    public interface ISearchViewModel
    {
        Command SearchCommand { get; set; }

        string SearchKeywords { get; set; }
    }
}
