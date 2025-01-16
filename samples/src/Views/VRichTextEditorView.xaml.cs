using System.Collections.ObjectModel;

namespace VControl.Samples.Views;

public class TextSize
{
    public string Name { get; set; }
    public double Value { get; set; }
}

public partial class VRichTextEditorView : ContentPageBase<VRichTextEditorViewModel>
{
    public static List<Color> DefaultTextColorList = new List<Color>() {
            Color.FromArgb("#F9371C"),
            Color.FromArgb("#F97C1C"),
            Color.FromArgb("#F9C81C"),
            Color.FromArgb("#41D0B6"),
            Color.FromArgb("#2CADF6"),
            Color.FromArgb("#6562FC")
        };

    public static List<TextSize> DefaultTextSizeList = new List<TextSize>() {
          new TextSize(){Name="Large", Value=22},
          new TextSize(){Name="Middle", Value=18},
          new TextSize(){Name="Small", Value=12},
        };

    public VRichTextEditor()
    {
        InitializeComponent();
        PropertyChanged+=RichTextEditor_PropertyChanged;

        this.ColorCollectionView.ItemsSource=DefaultTextColorList;
        //this.ColorCollectionView.SelectedItem=DefaultTextColorList[0];
        this.TextSizeCollectionView.ItemsSource=DefaultTextSizeList;
        //this.TextSizeCollectionView.SelectedItem=DefaultTextSizeList[0];


    }

    private void RichTextEditor_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {

    }

    public static readonly BindableProperty TextProperty =
      BindableProperty.Create("Text", typeof(string), typeof(VRichTextEditor), default, propertyChanged: (bindable, oldValue, newValue) =>
      {
          var obj = (VRichTextEditor)bindable;
          obj.MainEditor.Text=newValue as string;
      });

    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }


    public static readonly BindableProperty TextColorSelectorSourceProperty =
      BindableProperty.Create("TextColorSelectorSource", typeof(IEnumerable<Color>), typeof(VRichTextEditor), DefaultTextColorList, propertyChanged: (bindable, oldValue, newValue) =>
      {
          var obj = (VRichTextEditor)bindable;
          obj.TextColorSelectorSource=newValue as IEnumerable<Color>;
          obj.ColorCollectionView.ItemsSource=obj.TextColorSelectorSource;
      });

    public IEnumerable<Color> TextColorSelectorSource
    {
        get { return (IEnumerable<Color>)GetValue(TextColorSelectorSourceProperty); }
        set { SetValue(TextColorSelectorSourceProperty, value); }
    }



    public static readonly BindableProperty TextSizeSelectorSourceProperty =
      BindableProperty.Create("TextSizeSelectorSource", typeof(IEnumerable<TextSize>), typeof(VRichTextEditor), DefaultTextSizeList, propertyChanged: (bindable, oldValue, newValue) =>
      {
          var obj = (VRichTextEditor)bindable;
          obj.TextSizeSelectorSource=newValue as IEnumerable<Color>;
          obj.ColorCollectionView.ItemsSource=obj.TextSizeSelectorSource;
      });

    public IEnumerable<Color> TextSizeSelectorSource
    {
        get { return (IEnumerable<Color>)GetValue(TextSizeSelectorSourceProperty); }
        set { SetValue(TextSizeSelectorSourceProperty, value); }
    }



    public static readonly BindableProperty PlaceholderProperty =
      BindableProperty.Create("Placeholder", typeof(string), typeof(VRichTextEditor), default, propertyChanged: (bindable, oldValue, newValue) =>
      {
          var obj = (VRichTextEditor)bindable;
          obj.MainEditor.Placeholder=newValue as string;
      });

    public string Placeholder
    {
        get { return (string)GetValue(PlaceholderProperty); }
        set { SetValue(PlaceholderProperty, value); }
    }

    private void BoldButton_Clicked(object sender, EventArgs e)
    {
        this.MainEditor.BoldChanged();
    }

    private void ItalicButton_Clicked(object sender, EventArgs e)
    {
        this.MainEditor.ItalicChanged();

    }

    private void UnderLineButton_Clicked(object sender, EventArgs e)
    {
        this.MainEditor.UnderlineChanged();

    }

    private void ColorCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var currentColor = this.ColorCollectionView.SelectedItem as Color;
        this.MainEditor.ColorChanged(currentColor.ToArgbHex());

    }

    private void TextSizeButton_Clicked(object sender, EventArgs e)
    {
        ColorCollectionView.IsVisible = false;
        TextSizeCollectionView.IsVisible =  !TextSizeCollectionView.IsVisible;
    }

    private void TextColorButton_Clicked(object sender, EventArgs e)
    {
        TextSizeCollectionView.IsVisible = false;
        ColorCollectionView.IsVisible =  !ColorCollectionView.IsVisible;

    }

    private void TextSizeCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var textSize = (TextSize)this.TextSizeCollectionView.SelectedItem ;
        this.MainEditor.TextSizeChanged(textSize.Value.ToString("0"));


    }
}