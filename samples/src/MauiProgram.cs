using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using Microsoft.Maui.LifecycleEvents;
using VControl.Controls;
using VControl.Samples.Services.Navigation;
using VControl.Samples.ViewModels;
using VControl.Samples.Views;
using VControl.Samples.Views.Base;


namespace VControl.Samples
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseVControl()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .ConfigureLifecycleEvents(builder => { });
            builder.RegisterAppServices().RegisterViewsAndViewModels();

            var mauiApp = builder.Build();
            Ioc.Default.ConfigureServices(mauiApp.Services);
            return mauiApp;
        }

        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<INavigationService, MauiNavigationService>();

            return mauiAppBuilder;
        }

        static MauiAppBuilder RegisterViewsAndViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<HomePage, HomeViewModel>();
            builder.Services.AddTransientWithRoute<StyleSamplesPage, StyleSamplesViewModel>();
            builder.Services.AddTransientWithRoute<ColorsPage, ColorsPageViewModel>();
            builder.Services.AddTransientWithRoute<IconsPage, IconsPageViewModel>();
            builder.Services.AddTransientWithRoute<VButtonView, VButtonViewModel>();
            builder.Services.AddTransientWithRoute<VCardView, VCardViewModel>();
            builder.Services.AddTransientWithRoute<VRadioButtonView, VRadioButtonViewModel>();
            builder.Services.AddTransientWithRoute<VRadioButtonGroupView, VRadioButtonGroupViewModel>();
            builder.Services.AddTransientWithRoute<VTouchContentViewView, VTouchContentViewViewModel>();
            builder.Services.AddTransientWithRoute<
                AnimationWithScrollerView,
                AnimationWithScrollerViewModel
            >();
            builder.Services.AddTransientWithRoute<VTopAppBarView, VTopAppBarViewModel>();
            builder.Services.AddTransientWithRoute<VPlaceholderViewView, VPlaceholderViewViewModel>();
            builder.Services.AddTransientWithRoute<
                VCheckableCollectionView,
                VCheckableCollectionViewModel
            >();
            builder.Services.AddTransientWithRoute<VCheckBoxView, VCheckBoxViewModel>();
            builder.Services.AddTransientWithRoute<VEditorView, VEditorViewModel>();
            builder.Services.AddTransientWithRoute<VEntryView, VEntryViewModel>();
            builder.Services.AddTransientWithRoute<VMenuCellView, VMenuCellViewModel>();
            builder.Services.AddTransientWithRoute<VValidatingEntryView, VValidatingEntryViewModel>();
            builder.Services.AddTransientWithRoute<VDatePickerView, VDatePickerViewModel>();
            builder.Services.AddTransientWithRoute<VExpanderView, VExpanderViewModel>();
            builder.Services.AddTransientWithRoute<VNumberEntryView, VNumberEntryViewModel>();
            builder.Services.AddTransientWithRoute<VSearchBarView, VSearchBarViewModel>();
            builder.Services.AddTransientWithRoute<VTimeLineView, VTimeLineViewModel>();
            builder.Services.AddTransientWithRoute<VTagPickerView, VTagPickerViewModel>();
            builder.Services.AddTransientWithRoute<VRichTextEditorView, VRichTextEditorViewModel>();
            builder.Services.AddTransientWithRoute<VCheckBoxButtonView, VCheckBoxButtonViewModel>();
            builder.Services.AddTransientWithRoute<VCollectionView, VCollectionViewModel>();
            builder.Services.AddTransientWithRoute<VDateNativePickerView, VDateNativePickerViewModel>();
            builder.Services.AddTransientWithRoute<VCheckBoxGroupView, VCheckBoxGroupViewModel>();
            builder.Services.AddTransientWithRoute<VFormItemView, VFormItemViewModel>();
            builder.Services.AddTransientWithRoute<VIndicatorView, VIndicatorViewModel>();
            builder.Services.AddTransientWithRoute<VPickerView, VPickerViewModel>();
            builder.Services.AddTransientWithRoute<VUploaderView, VUploaderViewModel>();
            builder.Services.AddTransientWithRoute<VValidatingPickerView, VValidatingPickerViewModel>();
            return builder;
        }

        static IServiceCollection AddTransientWithRoute<TPage, TViewModel>(
            this IServiceCollection services,
            string prefix = ""
        )
            where TPage : ContentPageBase<TViewModel>
            where TViewModel : ViewModelBase
        {
            if (string.IsNullOrEmpty(prefix))
            {
                //toolkit extensions
                return services.AddTransientWithShellRoute<TPage, TViewModel>(typeof(TPage).Name);
            }
            else
            {
                var route = Path.Combine(prefix, typeof(TPage).Name);
                return services.AddTransientWithShellRoute<TPage, TViewModel>(route);
            }
        }
    }
}
