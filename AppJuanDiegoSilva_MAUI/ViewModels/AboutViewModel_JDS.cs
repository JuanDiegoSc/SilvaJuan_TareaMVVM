using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppJuanDiegoSilva_MAUI.ViewModels
{
    public class AboutViewModel_JDS
    {
        public string Title_JDS => AppInfo.Name;
        public string Version_JDS => AppInfo.VersionString;
        public string MoreInfoUrl_JDS => "https://aka.ms/maui";
        public string Message_JDS => "This app is written in XAML and C# with .NET MAUI.";
        public ICommand ShowMoreInfoCommand_JDS { get; }

        public AboutViewModel_JDS()
        {
            ShowMoreInfoCommand_JDS = new AsyncRelayCommand(ShowMoreInfo);
        }

        async Task ShowMoreInfo() =>
            await Launcher.Default.OpenAsync(MoreInfoUrl_JDS);
    }
}
