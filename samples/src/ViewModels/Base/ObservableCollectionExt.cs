using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace VControl.Samples.ViewModels;

public class ObservableCollectionExt<T> : ObservableCollection<T>
{
    public ObservableCollectionExt() : base()
    {
    }

    public ObservableCollectionExt(IEnumerable<T> collection) : base(collection)
    {
    }

    public ObservableCollectionExt(List<T> list) : base(list)
    {
    }

    public void ReloadData(IEnumerable<T> items)
    {
        ReloadData(
            innerList =>
            {
                foreach (var item in items)
                {
                    innerList.Add(item);
                }
            });
    }

    public void ReloadData(Action<IList<T>> innerListAction)
    {
        Items.Clear();

        innerListAction(Items);

        OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
        OnPropertyChanged(new PropertyChangedEventArgs("Items[]"));
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }

    public async Task ReloadDataAsync(Func<IList<T>, Task> innerListAction)
    {
        Items.Clear();

        await innerListAction(Items);

        OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
        OnPropertyChanged(new PropertyChangedEventArgs("Items[]"));
        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }
}
