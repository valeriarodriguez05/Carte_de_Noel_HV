using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows;

namespace Carte_de_Noel_HV
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MusicManager.Play();
        }
    }
}
