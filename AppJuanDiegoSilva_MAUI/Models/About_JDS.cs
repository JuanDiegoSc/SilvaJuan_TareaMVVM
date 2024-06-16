using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppJuanDiegoSilva_MAUI.Models
{
    public class About_JDS
    {
        public string Title_JDS => AppInfo.Name;
        public string Version_JDS => AppInfo.VersionString;
        public string MoreInfoUrl_JDS => "https://aka.ms/maui";
        public string Message_JDS => "This app is written in XAML and C# with .NET MAUI.";
    }
}
