using System;
using System.IO;
using AppJaveriana.Droid.Services;
using MVVMXamarin.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseDatosAndroid))]
namespace AppJaveriana.Droid.Services
{
    public class BaseDatosAndroid : IDataBase
    {
        public string GetDatabasePath()
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), Constantes.NombreBD);
        }

        public BaseDatosAndroid()
        {
        }
    }
}
