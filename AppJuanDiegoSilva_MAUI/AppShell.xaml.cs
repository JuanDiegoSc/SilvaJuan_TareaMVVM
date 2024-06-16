namespace AppJuanDiegoSilva_MAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.NotePage_JDS), typeof(Views.NotePage_JDS));
        }
    }
}
