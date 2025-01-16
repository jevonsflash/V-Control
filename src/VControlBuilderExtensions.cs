
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
#if ANDROID
using Android.Content.Res;
#endif

namespace VControl
{
    public static class VControlBuilderExtensions
    {

        public static MauiAppBuilder UseVControl(this MauiAppBuilder builder)
        {
            builder.Services.AddVControlProductivityService();
            builder.ConfigureFonts(fonts =>
            {
                fonts.AddFont("Font_Awesome_6_Free-Regular-400.otf", "FontAwesome-Regular");
                fonts.AddFont("Font_Awesome_6_Free-Solid-900.otf", "FontAwesome-Solid");
                fonts.AddFont("Font_Awesome_6_Brands-Regular-400.otf", "FontAwesome-Brands");
            });
            builder.ConfigureMauiHandlers(handlers =>
            {
               InitControls();
            });
            return builder;
        }


        public static IServiceCollection AddVControlProductivityService(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }

        public static void InitControls()
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("MyCustomizationEntry", (h, v) =>
            {
#if ANDROID
                h.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
                //h.PlatformView.BackgroundTintList = ColorStateList.ValueOf((new Color(196, 196, 196)).ToPlatform());
#endif
            });

            Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping("MyCustomizationEditor", (h, v) =>
            {
#if ANDROID
                h.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
                //h.PlatformView.BackgroundTintList = ColorStateList.ValueOf((new Color(196, 196, 196)).ToPlatform());
#endif
            });

            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("MyCustomizationPicker", (h, v) =>
            {
#if ANDROID
                h.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
                //h.PlatformView.BackgroundTintList = ColorStateList.ValueOf((new Color(196, 196, 196)).ToPlatform());
#endif
            });

            Microsoft.Maui.Handlers.DatePickerHandler.Mapper.AppendToMapping("MyCustomizationDatePicker", (h, v) =>
            {
#if ANDROID
                h.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
                //h.PlatformView.BackgroundTintList = ColorStateList.ValueOf((new Color(196, 196, 196)).ToPlatform());
#endif
            });

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("SetUpEntry", (h, v) =>
            {
#if IOS
			h.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            });

            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("SetUpPicker", (h, v) =>
            {
#if IOS
			h.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            });

            Microsoft.Maui.Handlers.DatePickerHandler.Mapper.AppendToMapping("SetUpDatePicker", (h, v) =>
            {
#if IOS
            h.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            });
        }



    }
}