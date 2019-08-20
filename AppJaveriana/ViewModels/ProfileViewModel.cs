using AppJaveriana.Modelos;
using AppJaveriana.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppJaveriana.ViewModels
{
    public class ProfileViewModel : UserModel
    {
        private ProfileServices ProfileService = new ProfileServices();
        public UserModel UserLogged { get; set; }

        public ProfileViewModel() { }

        public async Task loadUser()
        {
            UserLogged = await ProfileService.getLogged();
            Nombreuser = UserLogged.Nombreuser + " " + UserLogged.Apellidouser;
            Correouser = UserLogged.Correouser;
            Codigouser = UserLogged.Codigouser;
        }
    }
}
